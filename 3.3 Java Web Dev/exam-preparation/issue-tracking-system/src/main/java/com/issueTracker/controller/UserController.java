package com.issueTracker.controller;

import com.issueTracker.model.bindingModel.CreateUserModel;
import com.issueTracker.model.bindingModel.LoginModel;
import com.issueTracker.model.viewModel.UserViewModel;
import com.issueTracker.service.UserService;
import com.mvcFramework.annotations.controller.Controller;
import com.mvcFramework.annotations.parameters.ModelAttribute;
import com.mvcFramework.annotations.request.GetMapping;
import com.mvcFramework.annotations.request.PostMapping;
import com.mvcFramework.models.Model;

import javax.ejb.Stateless;
import javax.inject.Inject;
import javax.servlet.http.HttpSession;
import javax.validation.ConstraintViolation;
import javax.validation.Validation;
import javax.validation.Validator;
import java.util.List;
import java.util.Set;
import java.util.stream.Collectors;

/**
 * Created by Edi on 03-Mar-17.
 */
@Stateless
@Controller
public class UserController {
    @Inject
    private UserService userService;

    @GetMapping("/login")
    public String getLoginPage() {
        return "/templates/login";
    }

    @PostMapping("/login")
    public String login(@ModelAttribute LoginModel loginModel, Model model, HttpSession session) {
        UserViewModel userViewModel = this.userService.findLoggedInUser(loginModel);

        if (userViewModel == null) {
            model.addAttribute("loginError", "loginError");
            return "/templates/login";
        }

        session.setAttribute("currentUser", userViewModel);

        return "redirect:/";
    }

    @GetMapping("/create")
    public String getRegisterPage() {
        return "/templates/create-user";
    }



    @PostMapping("/create")
    public String registerUser(@ModelAttribute CreateUserModel createUserModel, Model model) {
        Validator validator = Validation.buildDefaultValidatorFactory().getValidator();
        Set<ConstraintViolation<CreateUserModel>> constraints = validator.validate(createUserModel);
        List<String> errors = constraints.stream().map(ConstraintViolation::getMessage).collect(Collectors.toList());

        if (!createUserModel.getPassword().equals(createUserModel.getConfirmPassword())) {
            errors.add("Password Mismatch");
        }

        if (errors.size() > 0) {
            model.addAttribute("errors", errors);
            return "/templates/register";
        }

        this.userService.register(createUserModel);

        return "redirect:/login";
    }

    @GetMapping("/logout")
    public String logoutUser(HttpSession session) {
        session.invalidate();

        return "redirect:/";
    }
}
