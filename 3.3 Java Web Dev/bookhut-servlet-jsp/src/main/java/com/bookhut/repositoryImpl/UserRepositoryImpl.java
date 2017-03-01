package com.bookhut.repositoryImpl;

import com.bookhut.entity.User;
import com.bookhut.repository.UserRepository;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Edi on 26-Feb-17.
 */
public class UserRepositoryImpl implements UserRepository {
    private static UserRepository userRepository;

    private List<User> users;

    private UserRepositoryImpl() {
        this.users = new ArrayList<>();
    }

    public void createUser(User user) {
        users.add(user);
    }

    public User findByUsernameAndPassword(final String username, final String password) {
        User user = users
                .stream()
                .filter(u ->
                        u.getUsername().equals(username)
                                && u.getPassword().equals(password))
                .findFirst()
                .orElse(null);
        return user;
    }

    public static UserRepository getInstance(){
        if(userRepository == null) {
            userRepository = new UserRepositoryImpl();
        }

        return userRepository;
    }
}
