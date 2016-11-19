package com.mass_defect.serviceImpl;

import com.mass_defect.dao.StarRepository;
import com.mass_defect.domain.models.Star;
import com.mass_defect.service.StarService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Primary;
import org.springframework.stereotype.Service;

/**
 * Created by Edi on 19-Nov-16.
 */
@Service
@Primary
public class StarServiceImpl implements StarService {
    @Autowired
    private StarRepository starRepository;

    @Override
    public void save(Star star) {
        this.starRepository.saveAndFlush(star);
    }

    @Override
    public void delete(Star star) {
        this.starRepository.delete(star);
    }

    @Override
    public void delete(Long id) {
        this.starRepository.delete(id);
    }

    @Override
    public Star findStar(Long id) {
        return this.starRepository.findOne(id);
    }

    @Override
    public Star findStarByName(String name) {
        return this.starRepository.findByName(name);
    }

    @Override
    public Iterable<Star> findStars() {
        return this.starRepository.findAll();
    }
}
