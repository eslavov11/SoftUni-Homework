package app.service;

import app.domain.Category;

import java.util.List;

public interface CategoryService {
    void save(Category category);

    void delete(Category category);

    void delete(Long id);

    Category findCategory(Long id);

    Iterable<Category> findCategories();

    List<Category> findByName(String[] names);
}
