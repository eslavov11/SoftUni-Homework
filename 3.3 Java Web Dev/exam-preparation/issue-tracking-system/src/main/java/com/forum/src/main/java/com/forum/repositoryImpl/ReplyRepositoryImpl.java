package com.forum.repositoryImpl;

import com.forum.entities.Reply;
import com.forum.repositories.ReplyRepository;

import javax.ejb.Stateless;
import javax.inject.Inject;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

@Stateless
public class ReplyRepositoryImpl implements ReplyRepository {

    @PersistenceContext
    private EntityManager entityManager;

    @Override
    public void save(Reply reply) {
        this.entityManager.persist(reply);
    }
}
