package com.mass_defect.service;

import com.mass_defect.domain.models.SolarSystem;

/**
 * Created by Edi on 19-Nov-16.
 */
public interface SolarSystemService {
    void save(SolarSystem solarSystem);

    void delete(SolarSystem s   );

    void delete(Long id);

    SolarSystem findSolarSystem(Long id);

    SolarSystem findSolarSystemByName(String name);

    Iterable<SolarSystem> findSolarSystems();
}
