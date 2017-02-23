package com.mass_defect.domain.dto.xml_dto;

import javax.xml.bind.annotation.*;
import java.io.Serializable;
import java.util.List;

/**
 * Created by Edi on 19-Nov-16.
 */
@XmlRootElement(name = "anomaly")
@XmlAccessorType(XmlAccessType.FIELD)
public class AnomalyWithVictimImportDto implements Serializable {
    @XmlAttribute(name = "origin-planet", required = true)
    private String originPlanet;

    @XmlAttribute(name = "teleport-planet", required = true)
    private String teleportPlanet;

    @XmlElementWrapper(name = "victims")
    @XmlElement(name = "victim")
    private List<VictimImportDto> victims;

    public AnomalyWithVictimImportDto() {
    }

    public String getOriginPlanet() {
        return originPlanet;
    }

    public void setOriginPlanet(String originPlanet) {
        this.originPlanet = originPlanet;
    }

    public String getTeleportPlanet() {
        return teleportPlanet;
    }

    public void setTeleportPlanet(String teleportPlanet) {
        this.teleportPlanet = teleportPlanet;
    }

    public List<VictimImportDto> getVictims() {
        return victims;
    }

    public void setVictims(List<VictimImportDto> victims) {
        this.victims = victims;
    }
}
