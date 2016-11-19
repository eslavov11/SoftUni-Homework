package com.mass_defect.domain.dto.json_dto;

import java.io.Serializable;

/**
 * Created by Edi on 19-Nov-16.
 */
public class PlanetImportDto implements Serializable {
    private String name;
    private String sun;
    private String solarSystem;

    public PlanetImportDto() {
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getSun() {
        return sun;
    }

    public void setSun(String sun) {
        this.sun = sun;
    }

    public String getSolarSystem() {
        return solarSystem;
    }

    public void setSolarSystem(String solarSystem) {
        this.solarSystem = solarSystem;
    }
}
