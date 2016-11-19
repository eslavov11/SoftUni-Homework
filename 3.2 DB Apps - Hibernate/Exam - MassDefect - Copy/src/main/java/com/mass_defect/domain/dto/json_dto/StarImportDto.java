package com.mass_defect.domain.dto.json_dto;

import java.io.Serializable;

/**
 * Created by Edi on 19-Nov-16.
 */
public class StarImportDto implements Serializable {
    private String name;
    private String solarSystem;

    public StarImportDto() {}

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getSolarSystem() {
        return solarSystem;
    }

    public void setSolarSystem(String solarSystem) {
        this.solarSystem = solarSystem;
    }
}
