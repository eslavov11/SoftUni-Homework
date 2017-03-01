package com.bookhut.model.bindingModel;

import java.util.Date;

/**
 * Created by Edi on 26-Feb-17.
 */
public class AddBookModel {
    private String title;
    private String author;
    private int pages;

    public AddBookModel() {
    }

    public AddBookModel(String title, String author, int pages) {
        this.title = title;
        this.author = author;
        this.pages = pages;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getAuthor() {
        return author;
    }

    public void setAuthor(String author) {
        this.author = author;
    }

    public int getPages() {
        return pages;
    }

    public void setPages(int pages) {
        this.pages = pages;
    }
}
