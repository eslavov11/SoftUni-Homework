package com.issueTracker.model.viewModel;

/**
 * Created by Edi on 03-Mar-17.
 */
public class UserViewModel {
    private String username;

    public UserViewModel(String username) {
        this.username = username;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }
}
