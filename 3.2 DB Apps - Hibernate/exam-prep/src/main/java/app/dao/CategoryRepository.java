package app.dao;

import app.domain.Category;
import org.springframework.data.repository.CrudRepository;

import java.util.List;


public interface CategoryRepository extends CrudRepository<Category, Long> {
    Category findById(Long id);

    Iterable<Category> findAll();

    List<Category> findByNameIn(String[] names);
}
