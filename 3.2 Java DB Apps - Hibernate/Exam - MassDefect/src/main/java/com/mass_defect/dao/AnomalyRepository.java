package com.mass_defect.dao;

import com.mass_defect.domain.models.Anomaly;
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
public interface AnomalyRepository extends JpaRepository<Anomaly, Long> {
    Anomaly findById(Long id);

    List<Anomaly> findAll();
}
