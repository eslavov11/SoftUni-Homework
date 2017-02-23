package com.mass_defect.dao;

import com.mass_defect.domain.models.Anomaly;
import com.mass_defect.domain.models.Planet;
import com.mass_defect.domain.models.SolarSystem;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.util.List;

/**
 * Created by Edi on 19-Nov-16.
 */
@Repository
public interface SolarSystemRepository extends JpaRepository<SolarSystem, Long> {
    SolarSystem findById(Long id);

    SolarSystem findByName(String name);

    List<SolarSystem> findAll();

}
