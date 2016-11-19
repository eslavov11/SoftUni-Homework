package com.mass_defect.service;

import com.mass_defect.domain.models.Star;

/**
 * Created by Edi on 19-Nov-16.
 */
public interface StarService {
    void save(Star star);

    void delete(Star star);

    void delete(Long id);

    Star findStar(Long id);

    Star findStarByName(String name);

    Iterable<Star> findStars();
}
