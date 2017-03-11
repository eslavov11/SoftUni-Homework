package com.issueTracker.repository;

import com.issueTracker.entity.User;

/**
 * Created by Edi on 03-Mar-17.
 */
public interface UserRepository {
    void save(User user);

    User getByUsernameAndPassword(String username, String password);

    long getTotalUsers();
}
