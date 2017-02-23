package com.mass_defect.domain.dto.xml_dto;

import javax.xml.bind.annotation.*;
import java.io.Serializable;
import java.util.List;

/**
 * Created by Edi on 19-Nov-16.
 */
@XmlRootElement(name = "anomalies")
@XmlAccessorType(XmlAccessType.FIELD)
public class AnomaliesImportDto implements Serializable {
    @XmlElement(name = "anomaly")
    private List<AnomalyWithVictimImportDto> anomalies;

    public AnomaliesImportDto() {
    }

    public List<AnomalyWithVictimImportDto> getAnomalies() {
        return anomalies;
    }

    public void setAnomalies(List<AnomalyWithVictimImportDto> anomalies) {
        this.anomalies = anomalies;
    }
}
