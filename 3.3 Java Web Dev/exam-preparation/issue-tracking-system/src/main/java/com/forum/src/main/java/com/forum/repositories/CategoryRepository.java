package com.forum.repositories;

import com.forum.entities.Category;

import java.util.List;

public interface CategoryRepository {

    void create(Category category);

    void update(Category category);

    List<Category> findAll();

    Category findByName(String categoryName);

    Category findByName(long id);

    void deleteById(long id);
}
