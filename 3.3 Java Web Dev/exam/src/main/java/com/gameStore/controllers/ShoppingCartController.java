package com.gameStore.controllers;

import com.gameStore.entities.games.Game;
import com.gameStore.models.bindingModels.LoggedUserModel;
import com.gameStore.models.viewModels.GameHomeViewModel;
import com.gameStore.services.GameService;
import com.mvcFramework.annotations.controller.Controller;
import com.mvcFramework.annotations.parameters.PathVariable;
import com.mvcFramework.annotations.request.GetMapping;
import com.mvcFramework.annotations.request.PostMapping;
import com.mvcFramework.models.Model;

import javax.ejb.Stateless;
import javax.inject.Inject;
import javax.servlet.http.HttpSession;
import java.util.ArrayList;
import java.util.List;

@Stateless
@Controller
public class ShoppingCartController {
    @Inject
    private GameService gameService;

    @GetMapping("/cart")
    public String get(HttpSession httpSession, Model model){
        String cartStr = (String)httpSession.getAttribute("cart");

        if (cartStr != null && !cartStr.equals("")) {
            String[] cartGamesIdsStr = cartStr.split(",");
            List<Long> cartGamesIds = new ArrayList<>();
            for (String gameId : cartGamesIdsStr) {
                cartGamesIds.add(Long.valueOf(gameId));
            }

            List<GameHomeViewModel> cart = new ArrayList<>();
            for (Long cartGamesId : cartGamesIds) {
                GameHomeViewModel gameHomeViewModel = this.gameService.getByIdDetailed(cartGamesId);
                cart.add(gameHomeViewModel);
            }

            model.addAttribute("cart", cart);
        }

        return "/templates/cart";
    }

    @PostMapping("/cart")
    public String order(HttpSession httpSession, Model model){
        LoggedUserModel loggedUserModel = (LoggedUserModel) httpSession.getAttribute("user");
        if (loggedUserModel == null) {
            return "redirect:/login";
        }

        return "/templates/cart";
    }

    @GetMapping("/cart/add/{id}")
    public String add(@PathVariable("id") long id, HttpSession httpSession){
        String cartStr = (String)httpSession.getAttribute("cart");

        if (cartStr == null || cartStr.equals("")) {
            httpSession.setAttribute("cart", (String.valueOf(id)));
        } else {
            //Already added in cart
            if (!cartStr.contains(String.valueOf(id))) {
                LoggedUserModel loggedUserModel = (LoggedUserModel) httpSession.getAttribute("user");

                boolean boughtGame = false;
                //User already bought game
                if (loggedUserModel != null) {
                    for (Game game : loggedUserModel.getGames()) {
                        if (game.getId() == id) {
                            boughtGame = true;
                        }
                    }
                }

                if (!boughtGame) {
                    httpSession.setAttribute("cart", (cartStr + "," + id));
                }
            }

        }

        return "redirect:/";
    }

    @GetMapping("/cart/remove/{id}")
    public String remove(@PathVariable("id") long id, HttpSession httpSession){
        String cartStr = (String)httpSession.getAttribute("cart");

        if (cartStr != null && cartStr.contains(String.valueOf(id))) {
            cartStr = cartStr.replaceFirst((id + ","), "");
            cartStr = cartStr.replaceFirst(String.valueOf(id), "");

            httpSession.setAttribute("cart", cartStr);
        }

        return "redirect:/cart";
    }
}
