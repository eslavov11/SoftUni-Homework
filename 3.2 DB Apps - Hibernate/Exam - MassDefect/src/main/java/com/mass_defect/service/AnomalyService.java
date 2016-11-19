package com.mass_defect.service;

import com.mass_defect.domain.models.Anomaly;

/**
 * Created by Edi on 19-Nov-16.
 */
public interface AnomalyService {
    void save(Anomaly anomaly);

    void delete(Anomaly anomaly);

    void delete(Long id);

    Anomaly findAnomaly(Long id);

    Iterable<Anomaly> findAnomalies();
}
