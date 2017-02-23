package com.mass_defect.dao;

import com.mass_defect.domain.models.Planet;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

/**
 * Created by Edi on 19-Nov-16.
 */
@Repository
public interface PlanetRepository extends JpaRepository<Planet, Long> {
    Planet findById(Long id);

    Planet findByName(String name);

    List<Planet> findAll();


    @Query(value = "SELECT p " +
            "FROM Planet AS p " +
            "where p.id not in (select a.originPlanet.id from Anomaly a)")
    List<Planet> findPlanetsWhichAreNotAnomalyOrigins();
}
