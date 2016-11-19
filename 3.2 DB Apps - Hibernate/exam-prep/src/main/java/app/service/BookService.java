package app.service;

import app.domain.Book;
import app.domain.Category;
import app.domain.enums.AgeRestriction;
import org.springframework.data.repository.query.Param;

import java.util.Date;
import java.util.List;

public interface BookService {
    void save(Book book);

    void delete(Book book);

    void delete(Long id);

    Book findBook(Long id);

    Iterable<Book> findBooks();

    List<Book> findByAgeRestriction(AgeRestriction ageRestriction);

    List<Book> findByEditionAndPages();

    List<Book> findByPrice();

    List<Book> findByReleaseDateNot(Date date);

    List<Book> findByCategoriesIn(List<Category> categories);

    List<Book> findByReleaseDateBefore(Date date);

    int countByTitleLength(int len);

    List<Object[]> findSumOfCopies();

    List<Object[]> findCountOfBooksByCategories();

    List<Book> findTop3ByCategoriesOrderByReleaseDateDescTitleAsc(Category category);

    int updateBooksByDateWithCopies(Date releaseDate, int copies);
}
