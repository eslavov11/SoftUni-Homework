package com.mass_defect.domain.dto.json_dto;

import java.io.Serializable;

/**
 * Created by Edi on 19-Nov-16.
 */
public class PersonImportDto implements Serializable {
    private String name;
    private String homePlanet;

    public PersonImportDto() {
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getHomePlanet() {
        return homePlanet;
    }

    public void setHomePlanet(String homePlanet) {
        this.homePlanet = homePlanet;
    }
}
