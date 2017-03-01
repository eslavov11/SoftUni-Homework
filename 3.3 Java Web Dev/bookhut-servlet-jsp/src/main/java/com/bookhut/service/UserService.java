package com.bookhut.service;

import com.bookhut.model.bindingModel.LoginModel;

/**
 * Created by Edi on 26-Feb-17.
 */
public interface UserService {
    void createUser(LoginModel loginModel);

    LoginModel findByUsernameAndPassword(String username, String password);
}
