package com.bookhut.serviceImpl;

import com.bookhut.entity.Book;
import com.bookhut.model.bindingModel.AddBookModel;
import com.bookhut.model.viewModel.ViewBookModel;
import com.bookhut.repository.BookRepository;
import com.bookhut.repository.UserRepository;
import com.bookhut.repositoryImpl.BookRepositoryImpl;
import com.bookhut.repositoryImpl.UserRepositoryImpl;
import com.bookhut.service.BookService;
import org.modelmapper.ModelMapper;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Edi on 26-Feb-17.
 */
public class BookServiceImpl implements BookService {
    private BookRepository bookRepository;

    public BookServiceImpl() {
        this.bookRepository = BookRepositoryImpl.getInstance();
    }

    @Override
    public void saveBook(AddBookModel book) {
        ModelMapper modelMapper = new ModelMapper();
        Book newBook = modelMapper.map(book, Book.class);
        this.bookRepository.createBook(newBook);
    }

    @Override
    public List<ViewBookModel> getAllBooks() {
        List<Book> books = this.bookRepository.getAllBooks();
        ModelMapper modelMapper = new ModelMapper();
        List<ViewBookModel> viewBookModels = new ArrayList<>();
        for (Book book : books) {
            viewBookModels.add(modelMapper.map(book, ViewBookModel.class));
        }

        return viewBookModels;
    }

    @Override
    public ViewBookModel findBookByTitle(String title) {
        Book book = this.bookRepository.findByTitle(title);
        ModelMapper modelMapper = new ModelMapper();

        return modelMapper.map(book, ViewBookModel.class);
    }

    @Override
    public void deleteBookByTitle(String title) {
        this.bookRepository.deleteBookByTitle(title);
    }
}
