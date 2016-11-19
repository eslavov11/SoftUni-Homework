package com.mass_defect.domain.dto.xml_dto;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlRootElement;

/**
 * Created by Edi on 19-Nov-16.
 */
@XmlRootElement(name = "victim")
@XmlAccessorType(XmlAccessType.FIELD)
public class VictimImportDto {
    @XmlAttribute(name = "name", required = true)
    private String name;

    public VictimImportDto() {
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
}
