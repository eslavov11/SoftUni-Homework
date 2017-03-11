package com.issueTracker.service;

import com.issueTracker.model.bindingModel.CreateUserModel;
import com.issueTracker.model.bindingModel.LoginModel;
import com.issueTracker.model.viewModel.UserViewModel;

/**
 * Created by Edi on 03-Mar-17.
 */
public interface UserService {
    void register(CreateUserModel createUserModel);

    UserViewModel findLoggedInUser(LoginModel loginModel);
}
