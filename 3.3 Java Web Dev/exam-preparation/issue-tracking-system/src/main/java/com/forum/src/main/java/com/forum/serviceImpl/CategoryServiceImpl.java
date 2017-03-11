package com.forum.serviceImpl;

import com.forum.entities.Category;
import com.forum.models.bindingModels.CategoryBindingModel;
import com.forum.models.viewModels.CategoryViewModel;
import com.forum.repositories.CategoryRepository;
import com.forum.service.CategoryService;
import com.forum.utils.parser.interfaces.ModelParser;

import javax.ejb.Stateless;
import javax.inject.Inject;
import java.util.ArrayList;
import java.util.List;

@Stateless
public class CategoryServiceImpl implements CategoryService {

    @Inject
    private CategoryRepository categoryRepository;

    @Inject
    private ModelParser modelParser;

    @Override
    public void save(CategoryBindingModel categoryBindingModel) {
        Category category = this.modelParser.convert(categoryBindingModel, Category.class);
        this.categoryRepository.create(category);
    }

    @Override
    public List<CategoryViewModel> findAll() {
        List<CategoryViewModel> categoryViewModels = new ArrayList<>();
        List<Category> categories = this.categoryRepository.findAll();
        for (Category category : categories) {
            CategoryViewModel categoryViewModel = this.modelParser.convert(category, CategoryViewModel.class);
            categoryViewModels.add(categoryViewModel);
        }

        return categoryViewModels;
    }

    @Override
    public void update(CategoryBindingModel categoryBindingModel) {
        Category category = this.modelParser.convert(categoryBindingModel, Category.class);
        this.categoryRepository.update(category);
    }

    @Override
    public CategoryViewModel findByName(long id) {
        Category category = this.categoryRepository.findByName(id);
        CategoryViewModel categoryViewModel = this.modelParser.convert(category, CategoryViewModel.class);
        return categoryViewModel;
    }

    @Override
    public void deleteById(long id) {
        this.categoryRepository.deleteById(id);
    }
}
