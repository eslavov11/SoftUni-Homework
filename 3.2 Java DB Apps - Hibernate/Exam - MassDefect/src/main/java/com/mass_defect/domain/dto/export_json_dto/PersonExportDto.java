package com.mass_defect.domain.dto.export_json_dto;

/**
 * Created by Edi on 19-Nov-16.
 */
public class PersonExportDto {
    private String name;
    private PlanetExportDto homePlanet;

    public PersonExportDto() {}

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public PlanetExportDto getHomePlanet() {
        return homePlanet;
    }

    public void setHomePlanet(PlanetExportDto homePlanet) {
        this.homePlanet = homePlanet;
    }
}
