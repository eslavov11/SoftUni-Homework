package com.pizzamoreLab.repository;

import com.pizzamoreLab.models.session.Session;
import com.pizzamoreLab.models.user.User;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;

/**
 * Created by Edi on 23-Feb-17.
 */
public class SessionRepository {

    public long createSession(Session session) {
        long id;
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("pizzaMore");
        EntityManager em = emf.createEntityManager();
        em.getTransaction().begin();
        em.persist(session);
        id = session.getId();
        em.getTransaction().commit();
        em.close();
        emf.close();

        return id;
    }

    public Session findById(long id) {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("pizzaMore");
        EntityManager em = emf.createEntityManager();
        em.getTransaction().begin();
        Query query = em.createQuery("select s from Session as s where s.id = :id");
        query.setParameter("id", id);
        Session session = null;
        if (!(query.getResultList().size() == 0)) {
            session = (Session) query.getSingleResult();
        }

        em.getTransaction().commit();
        em.close();
        emf.close();

        return session;
    }

    public void delete(long id) {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("pizzaMore");
        EntityManager em = emf.createEntityManager();
        em.getTransaction().begin();
        Query query = em.createQuery("delete from Session as s where s.id = :id");
        query.setParameter("id", id);
        query.executeUpdate();
        em.getTransaction().commit();
        em.close();
        emf.close();
    }


}
