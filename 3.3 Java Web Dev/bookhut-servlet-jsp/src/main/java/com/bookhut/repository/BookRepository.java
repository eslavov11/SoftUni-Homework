package com.bookhut.repository;

import com.bookhut.entity.Book;

import java.util.List;

/**
 * Created by Edi on 26-Feb-17.
 */
public interface BookRepository {
    void createBook(Book book);

    List<Book> getAllBooks();

    void deleteBookByTitle(String title);

    Book findByTitle(String title);
}
