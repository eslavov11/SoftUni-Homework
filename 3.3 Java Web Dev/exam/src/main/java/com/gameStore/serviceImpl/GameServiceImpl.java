package com.gameStore.serviceImpl;

import com.gameStore.entities.games.Game;
import com.gameStore.models.bindingModels.GameBindingModel;
import com.gameStore.models.bindingModels.GameEditBindingModel;
import com.gameStore.models.viewModels.GameEditViewModel;
import com.gameStore.models.viewModels.GameHomeViewModel;
import com.gameStore.models.viewModels.GameViewModel;
import com.gameStore.repositorties.GameRepository;
import com.gameStore.repositorties.UserRepository;
import com.gameStore.services.GameService;
import com.gameStore.utils.parser.interfaces.ModelParser;

import javax.ejb.Stateless;
import javax.inject.Inject;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

@Stateless
public class GameServiceImpl implements GameService {

    @Inject
    private GameRepository gameRepository;

    @Inject
    private UserRepository userRepository;

    @Inject
    private ModelParser modelParser;

    @Override
    public List<GameViewModel> findAll() {
        List<Game> games = this.gameRepository.findAll();
        List<GameViewModel> gameViewModels = new ArrayList<>();
        for (Game game : games) {
            GameViewModel gameViewModel = this.modelParser.convert(game, GameViewModel.class);
            gameViewModels.add(gameViewModel);
        }

        return gameViewModels;
    }

    @Override
    public List<GameHomeViewModel> findAllDetailed() {
        List<Game> games = this.gameRepository.findAll();
        List<GameHomeViewModel> gameViewModels = new ArrayList<>();
        for (Game game : games) {
            GameHomeViewModel gameViewModel = this.modelParser.convert(game, GameHomeViewModel.class);
            gameViewModels.add(gameViewModel);
        }

        return gameViewModels;
    }

    @Override
    public void create(GameBindingModel gameBindingModel) {
        Game game = new Game();
        game.setTitle(gameBindingModel.getTitle());
        game.setPrice(Double.valueOf(gameBindingModel.getPrice()));
        game.setSize(Double.valueOf(gameBindingModel.getSize()));
        game.setTrailer(gameBindingModel.getTrailer());
        game.setThumbnailURL(gameBindingModel.getThumbnailURL());
        game.setDescription(gameBindingModel.getDescription());

        try {
            DateFormat formatter = new SimpleDateFormat("yyyy-MM-dd");
            Date date = formatter.parse(gameBindingModel.getReleaseDate());
            game.setReleaseDate(date);
        } catch (ParseException exp) {
            exp.printStackTrace();
        }

        this.gameRepository.create(game);
    }

    @Override
    public void update(GameEditBindingModel gameEditBindingModel) {
        Game game = new Game();
        game.setId(gameEditBindingModel.getId());
        game.setTitle(gameEditBindingModel.getTitle());
        game.setPrice(Double.valueOf(gameEditBindingModel.getPrice()));
        game.setSize(Double.valueOf(gameEditBindingModel.getSize()));
        game.setTrailer(gameEditBindingModel.getTrailer());
        game.setThumbnailURL(gameEditBindingModel.getThumbnailURL());
        game.setDescription(gameEditBindingModel.getDescription());

        DateFormat formatter = new SimpleDateFormat("yyyy-MM-dd");
        try {
            Date date = formatter.parse(gameEditBindingModel.getReleaseDate());
            game.setReleaseDate(date);
        } catch (ParseException exp) {
            exp.printStackTrace();
        }

        this.gameRepository.update(game);
    }

    @Override
    public GameEditViewModel getById(long id) {
        Game game = this.gameRepository.findById(id);
        GameEditViewModel gameEditViewModel = this.modelParser.convert(game, GameEditViewModel.class);
        gameEditViewModel.setReleaseDate(gameEditViewModel.getReleaseDate().split(" ")[0]);

        return gameEditViewModel;
    }

    @Override
    public GameHomeViewModel getByIdDetailed(long id) {
        Game game = this.gameRepository.findById(id);
        GameHomeViewModel gameHomeViewModel = this.modelParser.convert(game, GameHomeViewModel.class);
        gameHomeViewModel.setReleaseDate(gameHomeViewModel.getReleaseDate().split(" ")[0]);

        return gameHomeViewModel;
    }

    @Override
    public void deleteById(long id) {
        this.gameRepository.deleteById(id);
    }
}
