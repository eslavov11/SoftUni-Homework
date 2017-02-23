package com.mass_defect.service;

import com.mass_defect.domain.models.Person;

import java.util.List;

/**
 * Created by Edi on 19-Nov-16.
 */
public interface PersonService {
        void save(Person person);

        void delete(Person person);

        void delete(Long id);

        Person findPerson(Long id);

        Person findPersonByName(String name);

        Iterable<Person> findPersons();

      //  List<Person> findPersonsNotVictims();
}
