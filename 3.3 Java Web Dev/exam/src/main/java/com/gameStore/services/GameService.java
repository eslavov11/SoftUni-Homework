package com.gameStore.services;

import com.gameStore.models.bindingModels.GameBindingModel;
import com.gameStore.models.bindingModels.GameEditBindingModel;
import com.gameStore.models.viewModels.GameEditViewModel;
import com.gameStore.models.viewModels.GameHomeViewModel;
import com.gameStore.models.viewModels.GameViewModel;

import java.util.List;

public interface GameService {

    List<GameViewModel> findAll();

    List<GameHomeViewModel> findAllDetailed();

    void create(GameBindingModel gameBindingModel);

    void update(GameEditBindingModel gameEditBindingModel);

    GameEditViewModel getById(long id);

    GameHomeViewModel getByIdDetailed(long id);

    void deleteById(long id);
}
