package com.bookhut.repositoryImpl;

import com.bookhut.entity.Book;
import com.bookhut.repository.BookRepository;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Edi on 26-Feb-17.
 */
public class BookRepositoryImpl implements BookRepository {
    private static BookRepositoryImpl bookRepository;
    private List<Book> books;

    private BookRepositoryImpl() {
        this.books = new ArrayList<>();
    }

    public static BookRepository getInstance() {
        if (bookRepository == null) {
            bookRepository = new BookRepositoryImpl();
        }

        return bookRepository;
    }

    @Override
    public void createBook(Book book) {
        Book currentBook = this.books
                .stream()
                .filter(b -> b.getTitle().equals(book.getTitle()))
                .findFirst()
                .orElse(null);
        if (currentBook != null) {
            this.books.remove(currentBook);
        }

        this.books.add(book);
    }

    @Override
    public List<Book> getAllBooks() {
        return this.books;
    }

    @Override
    public void deleteBookByTitle(String title) {
        Book book = this.books
                .stream()
                .filter(b -> b.getTitle().equals(title)).findFirst()
                .get();
        this.books.remove(book);
    }

    @Override
    public Book findByTitle(String title) {
        return this.books
                .stream()
                .filter(b -> b.getTitle().equals(title)).findFirst()
                .get();
    }
}
