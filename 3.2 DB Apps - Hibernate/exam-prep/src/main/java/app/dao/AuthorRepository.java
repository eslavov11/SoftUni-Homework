package app.dao;

import app.domain.Author;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface AuthorRepository extends CrudRepository<Author, Long>{
    Author findById(Long id);

    Iterable<Author> findAll();

    List<Author> findByFirstNameStartsWith(String letters);

    @Query(value = "SELECT a, COUNT(a) AS cnt FROM Author AS a GROUP BY a ORDER BY cnt")
    List<Object[]> findByAutohrBooks();
}










