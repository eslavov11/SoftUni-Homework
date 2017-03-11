package com.forum.controller;

import com.forum.models.bindingModels.CreateUserModel;
import com.forum.models.bindingModels.LoginModel;
import com.forum.models.viewModels.TopicViewModel;
import com.forum.models.viewModels.UserTopicsViewModel;
import com.forum.service.TopicService;
import com.forum.service.UserService;
import com.mvcFramework.annotations.controller.Controller;
import com.mvcFramework.annotations.parameters.ModelAttribute;
import com.mvcFramework.annotations.parameters.RequestParam;
import com.mvcFramework.annotations.request.GetMapping;
import com.mvcFramework.annotations.request.PostMapping;
import com.mvcFramework.models.Model;
import com.sun.org.apache.xpath.internal.operations.Mod;

import javax.ejb.Stateless;
import javax.inject.Inject;
import javax.servlet.http.HttpSession;
import javax.validation.ConstraintViolation;
import javax.validation.Validation;
import javax.validation.Validator;
import java.util.List;
import java.util.Set;

@Stateless
@Controller
public class UserController {

    @Inject
    private UserService userService;

    @Inject
    private TopicService topicService;

    @GetMapping("/register")
    public String getRegisterPage() {
        return "/templates/register";
    }

    @PostMapping("/register")
    public String registerUser(@ModelAttribute CreateUserModel createUserModel, Model model) {
        Validator validator = Validation.buildDefaultValidatorFactory().getValidator();
        Set<ConstraintViolation<CreateUserModel>> violations = validator.validate(createUserModel);
        if(violations.size() > 0){
            model.addAttribute("violations", violations);
            return "/templates/register";
        }

        if(!createUserModel.getPassword().equals(createUserModel.getConfirmPassword())){
            model.addAttribute("passwordMismatch", "passwordMismatch");
            return "/templates/register";
        }

        LoginModel loginModel = this.userService.findByUsernameAndPassword(createUserModel.getUsername(), createUserModel.getPassword());
        if(loginModel != null){
            model.addAttribute("userExists", "userExists");
            return "/templates/register";
        }

        this.userService.save(createUserModel);
        return "redirect:/";
    }

    @GetMapping("/login")
    public String getloginPage() {
        return "/templates/login";
    }

    @PostMapping("/login")
    public String loginUser(@ModelAttribute LoginModel loginModel,HttpSession session) {
        LoginModel user = this.userService.findByUsernameAndPassword(loginModel.getUsername(), loginModel.getPassword());
        session.setAttribute("user", user);
        return "redirect:/";
    }

    @GetMapping("/logout")
    public String logout(HttpSession session) {
        session.invalidate();
        return "redirect:/";
    }

    @GetMapping("/user/profile")
    public String getUserProfile(@RequestParam("profileId") long profileId, Model model) {
        UserTopicsViewModel userTopicsViewModel = this.userService.findById(profileId);
        model.addAttribute("userTopicsViewModel",userTopicsViewModel);
        model.addAttribute("profileId", profileId);

        return "/templates/profile";
    }

}
