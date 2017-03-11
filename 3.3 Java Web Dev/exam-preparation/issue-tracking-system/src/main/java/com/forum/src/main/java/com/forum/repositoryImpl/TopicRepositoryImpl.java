package com.forum.repositoryImpl;

import com.forum.entities.Topic;
import com.forum.repositories.TopicRepository;

import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

@Stateless
public class TopicRepositoryImpl implements TopicRepository {

    @PersistenceContext
    private EntityManager entityManager;

    @Override
    public void create(Topic topic) {
        this.entityManager.persist(topic);
    }

    @Override
    public Set<Topic> findTop10Topics() {
        Query query = entityManager.createQuery("SELECT t FROM Topic AS t ");
        List<Topic> topics = query.getResultList();
        if(topics.size()> 10){
            topics = topics.subList(0,10);
        }
        return new HashSet<>(topics);
    }

    @Override
    public Topic findTopicByTopicId(long id) {
        Query query = entityManager.createQuery("SELECT t FROM Topic AS t WHERE t.id = :id");
        query.setParameter("id", id);
        List<Topic> topics = query.getResultList();
        return topics.stream().findFirst().orElse(null);
    }

    @Override
    public void deleteById(long id) {
        Query query = entityManager.createQuery("DELETE FROM Topic AS t WHERE t.id = :id");
        query.setParameter("id", id);
        query.executeUpdate();
    }

}
