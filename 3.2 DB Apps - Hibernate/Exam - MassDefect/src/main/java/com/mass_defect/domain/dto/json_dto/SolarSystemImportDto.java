package com.mass_defect.domain.dto.json_dto;

import java.io.Serializable;

/**
 * Created by Edi on 19-Nov-16.
 */
public class SolarSystemImportDto implements Serializable {
    private String name;

    public SolarSystemImportDto() {
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
}
