package com.mass_defect.serviceImpl;

import com.mass_defect.dao.SolarSystemRepository;
import com.mass_defect.domain.models.SolarSystem;
import com.mass_defect.service.SolarSystemService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Primary;
import org.springframework.stereotype.Service;

/**
 * Created by Edi on 19-Nov-16.
 */
@Service
@Primary
public class SolarSystemServiceImpl implements SolarSystemService {
    @Autowired
    private SolarSystemRepository solarSystemRepository;

    @Override
    public void save(SolarSystem solarSystem) {
        this.solarSystemRepository.saveAndFlush(solarSystem);
    }

    @Override
    public void delete(SolarSystem s) {
        this.solarSystemRepository.delete(s);
    }

    @Override
    public void delete(Long id) {
        this.solarSystemRepository.delete(id);
    }

    @Override
    public SolarSystem findSolarSystem(Long id) {
        return this.solarSystemRepository.findOne(id);
    }

    @Override
    public SolarSystem findSolarSystemByName(String name) {
        return this.solarSystemRepository.findByName(name);
    }

    @Override
    public Iterable<SolarSystem> findSolarSystems() {
        return this.solarSystemRepository.findAll();
    }
}
