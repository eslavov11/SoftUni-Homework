package com.mass_defect.service;

import com.mass_defect.domain.models.Planet;

import java.util.List;

/**
 * Created by Edi on 19-Nov-16.
 */
public interface PlanetService {
    void save(Planet planet);

    void delete(Planet planet);

    void delete(Long id);

    Planet findPlanet(Long id);

    Planet findPlanetByName(String name);

    Iterable<Planet> findPlanets();

    List<Planet> findPlanetsWhichAreNotAnomalyOrigins();
}
