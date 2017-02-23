package com.mass_defect.domain.models;

import javax.persistence.*;

/**
 * Created by Edi on 19-Nov-16.
 */
@Entity
@Table(name = "stars")
public class Star {
    private Long id;
    private String name;
    private SolarSystem solarSystem;

    public Star() {
    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "star_id")
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

    @ManyToOne
    @JoinColumn(name = "solar_system_id")
    public SolarSystem getSolarSystem() {
        return solarSystem;
    }

    public void setSolarSystem(SolarSystem solarSystem) {
        this.solarSystem = solarSystem;
    }
}
