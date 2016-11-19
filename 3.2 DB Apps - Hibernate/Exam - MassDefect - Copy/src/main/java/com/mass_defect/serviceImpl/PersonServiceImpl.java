package com.mass_defect.serviceImpl;

import com.mass_defect.dao.PersonRepository;
import com.mass_defect.domain.models.Person;
import com.mass_defect.service.PersonService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Primary;
import org.springframework.stereotype.Service;

import java.util.List;

/**
 * Created by Edi on 19-Nov-16.
 */
@Service
@Primary
public class PersonServiceImpl implements PersonService {
    @Autowired
    private PersonRepository personRepository;

    @Override
    public void save(Person person) {
        this.personRepository.saveAndFlush(person);
    }

    @Override
    public void delete(Person person) {
        this.personRepository.delete(person);
    }

    @Override
    public void delete(Long id) {
        this.personRepository.delete(id);
    }

    @Override
    public Person findPerson(Long id) {
        return this.personRepository.findOne(id);
    }

    @Override
    public Person findPersonByName(String name) {
        return this.personRepository.findByName(name);
    }

    @Override
    public Iterable<Person> findPersons() {
        return this.personRepository.findAll();
    }

   /* @Override
    public List<Person> findPersonsNotVictims() {
        return this.personRepository.findPersonsNotVictims();
    }*/
}
