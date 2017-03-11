package com.forum.repositories;

import com.forum.entities.User;

public interface UserRepository {

    void create(User user);

    User findByUsernameAndPassword(String username, String password);

    User findByUsername(String authorUsername);

    User findById(long id);
}
