package com.mass_defect.dao;

import com.mass_defect.domain.models.Star;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

/**
 * Created by Edi on 19-Nov-16.
 */
@Repository
public interface StarRepository extends JpaRepository<Star, Long> {
    Star findById(Long id);

    Star findByName(String name);

    List<Star> findAll();
}
