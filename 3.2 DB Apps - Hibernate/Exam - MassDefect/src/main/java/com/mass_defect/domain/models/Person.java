package com.mass_defect.domain.models;

import javax.persistence.*;
import java.util.Set;

/**
 * Created by Edi on 19-Nov-16.
 */
@Entity
@Table(name = "persons")
public class Person {
    private Long id;
    private String name;
    private Planet homePlanet;
    private Set<Anomaly> anomalies;

    public Person() {
    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "person_id")
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
    @JoinColumn(name = "home_planet_id")
    public Planet getHomePlanet() {
        return homePlanet;
    }

    public void setHomePlanet(Planet homePlanet) {
        this.homePlanet = homePlanet;
    }

    @ManyToMany(mappedBy = "victims")
    public Set<Anomaly> getAnomalies() {
        return anomalies;
    }

    public void setAnomalies(Set<Anomaly> anomalies) {
        this.anomalies = anomalies;
    }
}
