package com.gameStore.models.bindingModels;

public class LoginUserModel {

    private String email;

    private String password;

    public LoginUserModel() {
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}
