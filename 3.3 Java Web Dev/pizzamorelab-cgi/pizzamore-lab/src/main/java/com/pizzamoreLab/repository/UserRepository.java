package com.pizzamoreLab.repository;

import com.pizzamoreLab.models.user.User;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;

/**
 * Created by Edi on 19-Feb-17.
 */
public class UserRepository {
    public void crateUser(User user) {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("pizzaMore");
        EntityManager em = emf.createEntityManager();
        em.getTransaction().begin();
        em.persist(user);
        em.getTransaction().commit();
        em.close();
        emf.close();
    }

    public User findByUserAndPassword(String username, String password) {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("pizzaMore");
        EntityManager em = emf.createEntityManager();
        em.getTransaction().begin();
        Query query = em.createQuery("select u from User u where u.username = :username and u.password = :password");
        query.setParameter("username", username);
        query.setParameter("password", password);
        User user = null;
        if (!(query.getResultList().size() == 0)) {
            user = (User) query.getSingleResult();
        }

        em.getTransaction().commit();
        em.close();
        emf.close();

        return user;
    }
}
