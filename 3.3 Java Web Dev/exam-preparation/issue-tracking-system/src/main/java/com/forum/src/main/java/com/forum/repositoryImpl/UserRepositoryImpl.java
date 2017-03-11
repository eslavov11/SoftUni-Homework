package com.forum.repositoryImpl;

import com.forum.entities.User;
import com.forum.repositories.UserRepository;

import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import java.util.List;

@Stateless
public class UserRepositoryImpl implements UserRepository {

    @PersistenceContext
    private EntityManager entityManager;

    @Override
    public void create(User user) {
        this.entityManager.persist(user);
    }

    @Override
    public User findByUsernameAndPassword(String username, String password) {
        Query query = this.entityManager.createQuery("SELECT u FROM User AS u " +
                "WHERE (u.username = :username OR u.email = :username) " +
                "AND u.password = :password");
        query.setParameter("username", username);
        query.setParameter("password", password);
        List<User> users = query.getResultList();
        return users.stream().findFirst().orElse(null);
    }

    @Override
    public User findByUsername(String authorUsername) {
        Query query = this.entityManager.createQuery("SELECT u FROM User AS u " +
                "WHERE (u.username = :username OR u.email = :username)");
        query.setParameter("username", authorUsername);
        List<User> users = query.getResultList();
        return users.stream().findFirst().orElse(null);
    }

    @Override
    public User findById(long id) {
        return this.entityManager.find(User.class, id);
    }
}
