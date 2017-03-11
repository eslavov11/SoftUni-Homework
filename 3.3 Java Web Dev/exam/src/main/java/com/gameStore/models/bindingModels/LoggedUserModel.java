package com.gameStore.models.bindingModels;

import com.gameStore.entities.games.Game;
import com.gameStore.entities.roles.Role;

import java.util.List;

public class LoggedUserModel {

    private String email;

    private Role role;

    private List<Game> games;

    public LoggedUserModel() {
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public Role getRole() {
        return role;
    }

    public void setRole(Role role) {
        this.role = role;
    }

    public List<Game> getGames() {
        return games;
    }

    public void setGames(List<Game> games) {
        this.games = games;
    }
}
