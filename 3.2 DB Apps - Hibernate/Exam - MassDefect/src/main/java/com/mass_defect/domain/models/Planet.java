package com.mass_defect.domain.models;

import javax.persistence.*;

/**
 * Created by Edi on 19-Nov-16.
 */
@Entity
@Table(name = "planets")
public class Planet {
    private Long id;
    private String name;
    private Star sun;
    private SolarSystem solarSystem;

    public Planet() {
    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "planet_id")
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
    @JoinColumn(name = "sun_id")
    public Star getSun() {
        return sun;
    }

    public void setSun(Star sun) {
        this.sun = sun;
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
