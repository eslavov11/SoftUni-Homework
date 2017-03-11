package com.gameStore.serviceImpl;

import com.gameStore.entities.roles.Role;
import com.gameStore.entities.users.User;
import com.gameStore.models.bindingModels.LoggedUserModel;
import com.gameStore.models.bindingModels.RegisterUserModel;
import com.gameStore.repositorties.UserRepository;
import com.gameStore.services.UserService;
import com.gameStore.utils.parser.interfaces.ModelParser;

import javax.ejb.Stateless;
import javax.inject.Inject;
import javax.transaction.Transactional;

@Stateless
public class UserServiceImpl implements UserService {

    @Inject
    private UserRepository userRepository;

    @Inject
    private ModelParser modelParser;

    @Override
    public void create(RegisterUserModel registerUserModel) {
        User user = this.modelParser.convert(registerUserModel, User.class);
        long totalUsers = this.userRepository.getTotalUsers();
        if(totalUsers == 0) {
            user.setRole(Role.ADMIN);
        } else {
            user.setRole(Role.USER);
        }

        this.userRepository.create(user);
    }

    @Override
    public RegisterUserModel findByEmail(String email) {
        User user = this.userRepository.findByEmail(email);
        RegisterUserModel registerUserModel = null;
        if(user != null){
            registerUserModel = this.modelParser.convert(user, RegisterUserModel.class);
        }

        return registerUserModel;
    }

    @Transactional
    @Override
    public LoggedUserModel findByEmailAndPassword(String email, String password) {
        User user = this.userRepository.findByEmailAndPassword(email, password);
        LoggedUserModel loginUserModel = null;
        if(user != null){
            loginUserModel = this.modelParser.convert(user, LoggedUserModel.class);
        }

        return loginUserModel;
    }
}
