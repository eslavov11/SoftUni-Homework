package com.mass_defect.domain.dto.json_dto;

/**
 * Created by Edi on 19-Nov-16.
 */
public class AnomalyVictimsImportDao {
    private Long id;
    private String person;

    public AnomalyVictimsImportDao() {}

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getPerson() {
        return person;
    }

    public void setPerson(String person) {
        this.person = person;
    }
}
