package com.gameStore.repositoryImpl;

import com.gameStore.entities.games.Game;
import com.gameStore.repositorties.GameRepository;

import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import java.util.List;

@Stateless
public class GameRepositoryImpl implements GameRepository {

    @PersistenceContext
    private EntityManager entityManager;

    @Override
    public void create(Game game) {
        this.entityManager.persist(game);
    }

    @Override
    public List<Game> findAll() {
        Query query = this.entityManager.createQuery("SELECT i FROM Game AS i");
        List<Game> games = query.getResultList();
        return games;
    }

    @Override
    public void update(Game game) {
        this.entityManager.merge(game);
    }

    @Override
    public Game findById(long id) {
        return this.entityManager.find(Game.class, id);
    }

    @Override
    public void deleteById(long id) {
        Query query = this.entityManager.createQuery("DELETE FROM Game AS i " +
                "WHERE i.id = :id");
        query.setParameter("id", id);
        query.executeUpdate();
    }
}
