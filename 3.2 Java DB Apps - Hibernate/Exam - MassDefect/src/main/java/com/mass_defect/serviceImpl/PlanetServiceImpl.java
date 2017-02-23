package com.mass_defect.serviceImpl;

import com.mass_defect.dao.PlanetRepository;
import com.mass_defect.domain.models.Planet;
import com.mass_defect.service.PlanetService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Primary;
import org.springframework.stereotype.Service;

import java.util.List;

/**
 * Created by Edi on 19-Nov-16.
 */
@Service
@Primary
public class PlanetServiceImpl implements PlanetService {
    @Autowired
    private PlanetRepository planetRepository;

    @Override
    public void save(Planet planet) {
        this.planetRepository.saveAndFlush(planet);
    }

    @Override
    public void delete(Planet planet) {
        this.planetRepository.delete(planet);
    }

    @Override
    public void delete(Long id) {
        this.delete(id);
    }

    @Override
    public Planet findPlanet(Long id) {
        return this.planetRepository.findOne(id);
    }

    @Override
    public Planet findPlanetByName(String name) {
        return this.planetRepository.findByName(name);
    }

    @Override
    public Iterable<Planet> findPlanets() {
        return this.planetRepository.findAll();
    }

    @Override
    public List<Planet> findPlanetsWhichAreNotAnomalyOrigins() {
        return this.planetRepository.findPlanetsWhichAreNotAnomalyOrigins();
    }
}
