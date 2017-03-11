package com.forum.service;

import com.forum.entities.Category;
import com.forum.models.bindingModels.CategoryBindingModel;
import com.forum.models.viewModels.CategoryViewModel;

import java.util.List;

public interface CategoryService {

    void save(CategoryBindingModel categoryBindingModel);

    List<CategoryViewModel> findAll();

    void update(CategoryBindingModel categoryBindingModel);

    CategoryViewModel findByName(long id);

    void deleteById(long id);
}
