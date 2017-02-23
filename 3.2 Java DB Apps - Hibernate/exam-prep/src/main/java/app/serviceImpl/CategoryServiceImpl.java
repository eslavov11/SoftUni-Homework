package app.serviceImpl;

import app.dao.CategoryRepository;
import app.domain.Category;
import app.service.CategoryService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Primary;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@Primary
public class CategoryServiceImpl implements CategoryService {

    @Autowired
    private CategoryRepository categoryRepository;

    @Override
    public void save(Category category) {
        categoryRepository.save(category);
    }

    @Override
    public void delete(Category category) {
        categoryRepository.delete(category);
    }

    @Override
    public void delete(Long id) {
        categoryRepository.delete(id);
    }

    @Override
    public Category findCategory(Long id) {
        return categoryRepository.findById(id);
    }

    @Override
    public Iterable<Category> findCategories() {
        return categoryRepository.findAll();
    }

    @Override
    public List<Category> findByName(String[] names) {
        return categoryRepository.findByNameIn(names);
    }
}
