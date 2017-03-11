package com.forum.serviceImpl;

import com.forum.entities.User;
import com.forum.models.bindingModels.CreateUserModel;
import com.forum.models.bindingModels.LoginModel;
import com.forum.models.viewModels.UserTopicsViewModel;
import com.forum.repositories.UserRepository;
import com.forum.service.UserService;
import com.forum.utils.parser.interfaces.ModelParser;

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
    public void save(CreateUserModel createUserModel) {
        User user = this.modelParser.convert(createUserModel, User.class);
        this.userRepository.create(user);
    }

    @Override
    public LoginModel findByUsernameAndPassword(String username, String password) {
        User user = this.userRepository.findByUsernameAndPassword(username, password);
        LoginModel loginModel = null;
        if(user != null) {
            loginModel = this.modelParser.convert(user, LoginModel.class);
        }

        return loginModel;
    }

    @Transactional
    @Override
    public UserTopicsViewModel findById(long id) {
        User user = this.userRepository.findById(id);
        UserTopicsViewModel userTopicsViewModel = this.modelParser.convert(user, UserTopicsViewModel.class);
        return userTopicsViewModel;
    }
}
