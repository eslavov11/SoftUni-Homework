package com.issueTracker.serviceImpl;

import com.issueTracker.entity.Role;
import com.issueTracker.entity.User;
import com.issueTracker.model.bindingModel.CreateUserModel;
import com.issueTracker.model.bindingModel.LoginModel;
import com.issueTracker.model.viewModel.UserViewModel;
import com.issueTracker.repository.UserRepository;
import com.issueTracker.service.UserService;
import com.issueTracker.utils.parser.interfaces.ModelParser;

import javax.ejb.Stateless;
import javax.inject.Inject;

/**
 * Created by Edi on 03-Mar-17.
 */
@Stateless
public class UserServiceImpl implements UserService {
    @Inject
    UserRepository userRepository;

    @Inject
    ModelParser modelParser;

    @Override
    public void register(CreateUserModel createUserModel) {
        User user = this.modelParser.convert(createUserModel, User.class);
        long totalUsers = this.userRepository.getTotalUsers();
        if(totalUsers == 0) {
            user.setRole(Role.ADMIN);
        } else {
            user.setRole(Role.USER);
        }

        this.userRepository.save(user);
    }

    @Override
    public UserViewModel findLoggedInUser(LoginModel loginModel) {
        User user = this.userRepository.getByUsernameAndPassword(loginModel.getUsername(), loginModel.getPassword());

        UserViewModel userViewModel = this.modelParser.convert(user, UserViewModel.class);

        return userViewModel;
    }
}
