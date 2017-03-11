package com.gameStore.repositorties;

import com.gameStore.entities.games.Game;

import java.util.List;

public interface GameRepository {

    void create(Game issue);

    List<Game> findAll();

    void update(Game issue);

    Game findById(long id);

    void deleteById(long id);
}
