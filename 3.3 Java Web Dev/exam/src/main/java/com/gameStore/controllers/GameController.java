package com.gameStore.controllers;

import com.gameStore.models.bindingModels.GameBindingModel;
import com.gameStore.models.bindingModels.GameEditBindingModel;
import com.gameStore.models.bindingModels.LoggedUserModel;
import com.gameStore.models.bindingModels.RegisterUserModel;
import com.gameStore.models.viewModels.GameEditViewModel;
import com.gameStore.models.viewModels.GameHomeViewModel;
import com.gameStore.models.viewModels.GameViewModel;
import com.gameStore.services.GameService;
import com.mvcFramework.annotations.controller.Controller;
import com.mvcFramework.annotations.parameters.ModelAttribute;
import com.mvcFramework.annotations.parameters.PathVariable;
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

@Stateless
@Controller
public class GameController {

    @Inject
    private GameService gameService;

    @GetMapping("/games")
    public String getPage(Model model){
        List<GameViewModel> gameViewModels = this.gameService.findAll();
        model.addAttribute("gameViewModels", gameViewModels);

        return "/templates/admin-games";
    }

    @GetMapping("/games/{id}")
    public String getPage(@PathVariable("id") long id, Model model){
        GameHomeViewModel gameHomeViewModel = this.gameService.getByIdDetailed(id);
        model.addAttribute("game", gameHomeViewModel);
        return "/templates/game-details";
    }


    @GetMapping("/games/add")
    public String getAddPage(Model model){
        return "/templates/add-game";
    }

    @PostMapping("/games/add")
    public String add(@ModelAttribute GameBindingModel gameBindingModel, Model model){
        Validator validator = Validation.buildDefaultValidatorFactory().getValidator();
        Set<ConstraintViolation<GameBindingModel>> constraints = validator.validate(gameBindingModel);
        List<String> errors = new ArrayList<>();
        for (ConstraintViolation<GameBindingModel> constraint : constraints) {
            errors.add(constraint.getMessage());
        }

        if (errors.size() > 0) {
            model.addAttribute("errors", errors);
            return "/templates/add-game";
        }

        this.gameService.create(gameBindingModel);

        return "redirect:/games";
    }

    @GetMapping("/games/edit/{id}")
    public String getEditPage(@PathVariable("id") long id, Model model){
        GameEditViewModel gameEditViewModel = this.gameService.getById(id);
        model.addAttribute("game", gameEditViewModel);
        return "/templates/edit-game";
    }

    @PostMapping("/games/edit/{id}")
    public String edit(@PathVariable("id") long id, @ModelAttribute GameEditBindingModel gameEditBindingModel, Model model){
        Validator validator = Validation.buildDefaultValidatorFactory().getValidator();
        Set<ConstraintViolation<GameEditBindingModel>> constraints = validator.validate(gameEditBindingModel);
        List<String> errors = new ArrayList<>();
        for (ConstraintViolation<GameEditBindingModel> constraint : constraints) {
            errors.add(constraint.getMessage());
        }

        if (errors.size() > 0) {
            model.addAttribute("errors", errors);

            GameEditViewModel gameEditViewModel = this.gameService.getById(id);
            model.addAttribute("game", gameEditViewModel);

            return "/templates/edit-game";
        }

        gameEditBindingModel.setId(id);
        gameService.update(gameEditBindingModel);

        return "redirect:/games";
    }

    @GetMapping("/games/delete/{id}")
    public String getDeletePage(@PathVariable("id") long id, Model model){
        GameEditViewModel gameEditViewModel = this.gameService.getById(id);
        model.addAttribute("game", gameEditViewModel);
        return "/templates/delete-game";
    }

    @PostMapping("/games/delete/{id}")
    public String edit(@PathVariable("id") long id){
        this.gameService.deleteById(id);

        return "redirect:/games";
    }
}
