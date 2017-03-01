package com.bookhut.service;

import com.bookhut.model.bindingModel.AddBookModel;
import com.bookhut.model.viewModel.ViewBookModel;

import java.util.List;

/**
 * Created by Edi on 26-Feb-17.
 */
public interface BookService {
    void saveBook(AddBookModel book);

    List<ViewBookModel> getAllBooks();

    ViewBookModel findBookByTitle(String title);

    void deleteBookByTitle(String title);
}
