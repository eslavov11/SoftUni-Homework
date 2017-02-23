package app.service;

import app.domain.Author;

import java.util.List;

public interface AuthorService {
    void save(Author author);

    void delete(Author author);

    void delete(Long id);

    Author findAuthor(Long id);

    Iterable<Author> findAuthors();

    List<Author> findByFirstNameStartsWith(String letters);

    List<Object[]> findByAutohrBooks();
}


