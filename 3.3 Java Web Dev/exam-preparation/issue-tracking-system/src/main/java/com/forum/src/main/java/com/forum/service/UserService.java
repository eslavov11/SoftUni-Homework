package com.forum.service;

import com.forum.models.bindingModels.CreateUserModel;
import com.forum.models.bindingModels.LoginModel;
import com.forum.models.viewModels.UserTopicsViewModel;

public interface UserService {

    void save(CreateUserModel createUserModel);

    LoginModel findByUsernameAndPassword(String username, String password);

    UserTopicsViewModel findById(long id);
}
