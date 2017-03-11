package com.gameStore.repositorties;

import com.gameStore.entities.users.User;

public interface UserRepository {

    void create(User user);

    User findByEmail(String username);

    User findByEmailAndPassword(String email, String password);

    long getTotalUsers();
}
