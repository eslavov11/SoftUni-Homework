package com.bookhut.repository;

import com.bookhut.entity.User;

/**
 * Created by Edi on 26-Feb-17.
 */
public interface UserRepository {
    void createUser(User user);

    User findByUsernameAndPassword(String username, String password);
}
