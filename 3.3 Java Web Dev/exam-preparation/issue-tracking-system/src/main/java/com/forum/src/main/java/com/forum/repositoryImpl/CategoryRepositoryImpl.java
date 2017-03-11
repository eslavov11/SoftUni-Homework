package com.forum.repositoryImpl;

import com.forum.entities.Category;
import com.forum.repositories.CategoryRepository;

import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import java.util.List;

@Stateless
public class CategoryRepositoryImpl implements CategoryRepository {

    @PersistenceContext
    private EntityManager entityManager;


    @Override
    public void create(Category category) {
        this.entityManager.persist(category);
    }

    @Override
    public void update(Category category) {
        this.entityManager.merge(category);
    }

    @Override
    public List<Category> findAll() {
        Query query = this.entityManager.createQuery("SELECT c FROM Category AS c ");
        List<Category> categories = query.getResultList();
        return categories;
    }

    @Override
    public Category findByName(String categoryName) {
        Query query = this.entityManager.createQuery("SELECT c FROM Category AS c " +
                "WHERE c.name = :username");
        query.setParameter("username", categoryName);
        List<Category> categories = query.getResultList();
        return categories.stream().findFirst().orElse(null);
    }

    @Override
    public Category findByName(long id) {
        return this.entityManager.find(Category.class, id);
    }

    @Override
    public void deleteById(long id) {
        Query query = this.entityManager.createQuery("DELETE FROM Category AS c " +
                "WHERE c.id = :id");
        query.setParameter("id", id);
        query.executeUpdate();
    }
}
