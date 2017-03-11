package com.gameStore.services;

import com.gameStore.models.bindingModels.LoggedUserModel;
import com.gameStore.models.bindingModels.RegisterUserModel;

public interface UserService {

    void create(RegisterUserModel registerUserModel);

    RegisterUserModel findByEmail(String email);

    LoggedUserModel findByEmailAndPassword(String email, String password);

}
