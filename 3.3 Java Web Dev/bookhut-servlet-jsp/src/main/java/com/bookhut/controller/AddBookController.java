package com.bookhut.controller;

import com.bookhut.model.bindingModel.AddBookModel;
import com.bookhut.service.BookService;
import com.bookhut.serviceImpl.BookServiceImpl;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

/**
 * Created by Edi on 02-Mar-17.
 */
@WebServlet("/add")
public class AddBookController extends HttpServlet {
    private BookService bookService;

    public AddBookController() {
        bookService = new BookServiceImpl();
    }

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        req.getRequestDispatcher("templates/add-book.jsp").forward(req,resp);
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        String add = req.getParameter("add");
        if (add != null) {

            String title = req.getParameter("title");
            String author = req.getParameter("author");
            int pages = Integer.valueOf(req.getParameter("pages"));
            AddBookModel addBookModel = new AddBookModel(title, author, pages);
            bookService.saveBook(addBookModel);
            req.getRequestDispatcher("templates/add-book.jsp").forward(req,resp);
        }
    }
}
