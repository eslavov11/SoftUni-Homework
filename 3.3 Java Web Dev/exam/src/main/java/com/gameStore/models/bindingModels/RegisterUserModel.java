package com.gameStore.models.bindingModels;

import javax.validation.constraints.Pattern;
import javax.validation.constraints.Size;
import javax.ws.rs.container.PreMatching;

public class RegisterUserModel {

    @Pattern(regexp = "^(.*@.*\\..*|.*\\..*@.*)$", message = "The email is invalid")
    private String email;

    private String fullName;

    @Pattern(regexp = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[A-Za-z\\d!@#$%^&*,.&]{6,}$",
            message = "Invalid Password. It should be at least 6 symbols long, containing 1 uppercase letter, 1 lowercase letter and 1 digit.")
    private String password;

    private String confirmPassword;

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getFullName() {
        return fullName;
    }

    public void setFullName(String fullName) {
        this.fullName = fullName;
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
