package com.mass_defect.domain.models;

import javax.persistence.*;

/**
 * Created by Edi on 19-Nov-16.
 */
@Entity
@Table(name = "solar_systems")
public class SolarSystem {
    private Long id;
    private String name;

    public SolarSystem() {
    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "solar_system_id")
    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    @Column(name = "name", nullable = false)
    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
}
