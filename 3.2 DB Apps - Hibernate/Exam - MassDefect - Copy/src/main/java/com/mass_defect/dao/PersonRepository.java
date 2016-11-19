package com.mass_defect.dao;

import com.mass_defect.domain.models.Person;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.util.List;

/**
 * Created by Edi on 19-Nov-16.
 */
@Repository
public interface PersonRepository extends JpaRepository<Person, Long> {
    Person findById(Long id);

    Person findByName(String name);

    List<Person> findAll();

  /*  @Query(value = "SELECT p " +
            "FROM Person AS p " +
            "where p.id not in (select a.victims.id from Anomaly a)")*/
    //List<Person> findPersonsNotVictims();
}
