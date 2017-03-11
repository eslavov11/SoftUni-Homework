package com.gameStore.controllers;

import com.gameStore.entities.roles.Role;
import com.gameStore.models.bindingModels.LoggedUserModel;
import com.gameStore.models.viewModels.GameEditViewModel;
import com.gameStore.models.viewModels.GameHomeViewModel;
import com.gameStore.models.viewModels.GameViewModel;
import com.gameStore.services.GameService;
import com.mvcFramework.annotations.controller.Controller;
import com.mvcFramework.annotations.request.GetMapping;
import com.mvcFramework.models.Model;

import javax.ejb.Stateless;
import javax.inject.Inject;
import javax.servlet.http.HttpSession;
import java.util.List;

@Stateless
@Controller
public class HomeController {
    @Inject
    private GameService gameService;

    @GetMapping("/")
    public String getHomePage(HttpSession httpSession, Model model) {
        List<GameHomeViewModel> gameViewModels = this.gameService.findAllDetailed();
        model.addAttribute("gameViewModels", gameViewModels);

        LoggedUserModel loggedUserModel = (LoggedUserModel) httpSession.getAttribute("user");
        if (loggedUserModel == null) {
            return "/templates/guest-home";
        } else if (loggedUserModel.getRole() == Role.ADMIN) {
            return "/templates/admin-home";
        } else if (loggedUserModel.getRole() == Role.USER) {
            return "/templates/user-home";
        }

        return "/templates/guest-home";
    }
}
