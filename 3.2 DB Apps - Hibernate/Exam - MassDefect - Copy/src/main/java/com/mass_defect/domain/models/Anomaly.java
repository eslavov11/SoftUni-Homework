package com.mass_defect.domain.models;

import javax.persistence.*;
import java.util.HashSet;
import java.util.Set;

/**
 * Created by Edi on 19-Nov-16.
 */
@Entity
@Table(name = "anomalies")
public class Anomaly {
    private Long id;
    private Planet originPlanet;
    private Planet teleportPlanet;
    private Set<Person> victims;

    public Anomaly() {
        this.victims = new HashSet<>();
    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "anomaly_id")
    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    @ManyToOne
    @JoinColumn(name = "origin_planet_id")
    public Planet getOriginPlanet() {
        return originPlanet;
    }

    public void setOriginPlanet(Planet planet) {
        this.originPlanet = planet;
    }

    @ManyToOne
    @JoinColumn(name = "teleport_planet_id")
    public Planet getTeleportPlanet() {
        return teleportPlanet;
    }

    public void setTeleportPlanet(Planet planet) {
        this.teleportPlanet = planet;
    }

    @ManyToMany
    public Set<Person> getVictims() {
        return victims;
    }

    public void setVictims(Set<Person> victims) {
        this.victims = victims;
    }
}
