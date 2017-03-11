package com.forum.models.bindingModels;

import javax.validation.constraints.Pattern;

public class CreateUserModel {

    @Pattern(regexp = "^(?=.*[a-z])(?=.*\\d)[a-z\\d]{3,}$", message = "Incorrect Username!")
    private String username;

    @Pattern(regexp = "^(?=.*[@])[A-Za-z\\d@.]{5,}$", message = "Incorrect Email!")
    private String email;

    @Pattern(regexp = "^(?=.*\\d)[\\d]{4,4}$", message = "Incorrect Password!")
    private String password;

    private String confirmPassword;

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
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

    public String getConfirmPassword() {
        return confirmPassword;
    }

    public void setConfirmPassword(String confirmPassword) {
        this.confirmPassword = confirmPassword;
    }
}
