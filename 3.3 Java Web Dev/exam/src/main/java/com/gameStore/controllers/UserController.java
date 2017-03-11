package com.gameStore.controllers;

import com.gameStore.entities.roles.Role;
import com.gameStore.models.bindingModels.LoggedUserModel;
import com.gameStore.models.bindingModels.LoginUserModel;
import com.gameStore.models.bindingModels.RegisterUserModel;
import com.gameStore.services.UserService;
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
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.stream.Collectors;

@Stateless
@Controller
public class UserController {

    @Inject
    private UserService userService;

    @GetMapping("/register")
    public String getRegisterPage() {
        return "/templates/register";
    }

    @PostMapping("/register")
    public String registerUser(@ModelAttribute RegisterUserModel registerUserModel, Model model) {
        Validator validator = Validation.buildDefaultValidatorFactory().getValidator();
        Set<ConstraintViolation<RegisterUserModel>> constraints = validator.validate(registerUserModel);
        List<String> errors = new ArrayList<>();
        for (ConstraintViolation<RegisterUserModel> constraint : constraints) {
            errors.add(constraint.getMessage());
        }

        if (!registerUserModel.getPassword().equals(registerUserModel.getConfirmPassword())) {
            errors.add("Password Mismatch.");
        }

        RegisterUserModel foundUser = this.userService.findByEmail(registerUserModel.getEmail());
        if (foundUser != null) {
            errors.add("The user already exists.");
        }

        if (errors.size() > 0) {
            model.addAttribute("errors", errors);
            return "/templates/register";
        }

        this.userService.create(registerUserModel);

        return "redirect:/login";
    }

    @GetMapping("/login")
    public String getLoginPage() {
        return "/templates/login";
    }

    @PostMapping("/login")
    public String loginUser(HttpSession session, @ModelAttribute LoginUserModel loginUserModel, Model model) {
        LoggedUserModel foundUser = this.userService.findByEmailAndPassword(
                loginUserModel.getEmail(),
                loginUserModel.getPassword());

        if (foundUser == null) {
            model.addAttribute("error", "Invalid Login Details.");
            return "/templates/login";
        }

        session.setAttribute("user", foundUser);
        session.setAttribute("isAdmin", (foundUser.getRole() == Role.ADMIN));

        return "redirect:/";
    }

    @GetMapping("/logout")
    public String logoutUser(HttpSession session) {
        session.removeAttribute("user");
        session.removeAttribute("isAdmin");
        return "redirect:/";
    }
}
