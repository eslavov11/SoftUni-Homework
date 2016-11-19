package com.mass_defect.serviceImpl;

import com.mass_defect.dao.AnomalyRepository;
import com.mass_defect.domain.models.Anomaly;
import com.mass_defect.service.AnomalyService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Primary;
import org.springframework.stereotype.Service;

/**
 * Created by Edi on 19-Nov-16.
 */
@Service
@Primary
public class AnomalyServiceImpl implements AnomalyService {
    @Autowired
    private AnomalyRepository anomalyRepository;

    @Override
    public void save(Anomaly anomaly) {
        this.anomalyRepository.saveAndFlush(anomaly);
    }

    @Override
    public void delete(Anomaly anomaly) {
        this.anomalyRepository.delete(anomaly);
    }

    @Override
    public void delete(Long id) {
        this.anomalyRepository.delete(id);
    }

    @Override
    public Anomaly findAnomaly(Long id) {
        return this.anomalyRepository.findOne(id);
    }

    @Override
    public Iterable<Anomaly> findAnomalies() {
        return this.anomalyRepository.findAll();
    }
}
