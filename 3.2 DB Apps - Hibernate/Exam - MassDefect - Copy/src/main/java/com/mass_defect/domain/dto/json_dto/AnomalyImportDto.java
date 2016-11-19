package com.mass_defect.domain.dto.json_dto;

import java.io.Serializable;

/**
 * Created by Edi on 19-Nov-16.
 */
public class AnomalyImportDto implements Serializable {
    private String originPlanet;
    private String teleportPlanet;

    public AnomalyImportDto() {
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
}
