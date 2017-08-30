package com.demo;

import com.demo.entity.User;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

/**
 * Created by Edi on 30-Aug-17.
 */
public class Main {
    public static void main(String[] args) {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("example-db");
        EntityManager em = emf.createEntityManager();
        try {
            em.getTransaction().begin();
            User user = new User();
            user.setUsername("krasavchik");
            em.persist(user);
            em.getTransaction().commit();
            System.out.println(user.getId());
        } finally {
            em.close();
            emf.close();
        }
    }
}
