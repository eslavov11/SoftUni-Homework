package com.issueTracker.repositoryImpl;

import com.issueTracker.entity.User;
import com.issueTracker.repository.UserRepository;

import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import java.util.List;

/**
 * Created by Edi on 03-Mar-17.
 */
@Stateless
public class UserRepositoryImpl implements UserRepository {
    @PersistenceContext
    EntityManager entityManager;

    @Override
    public void save(User user) {
        entityManager.persist(user);
    }

    @Override
    public User getByUsernameAndPassword(String username, String password) {
        Query query = entityManager.createQuery("select u from User u where u.username = :username and u.password = :password");
        query.setParameter("username", username);
        query.setParameter("password", password);
        List<User> users = query.getResultList();
        User user = null;
        if (!users.isEmpty()) {
            user = users.stream().findFirst().get();
        }

        return user;
    }

    @Override
    public long getTotalUsers() {
        Query query = this.entityManager.createQuery("SELECT COUNT(u) FROM User AS u ");
        long totalUsers = query.getFirstResult();
        return totalUsers;
    }
}
