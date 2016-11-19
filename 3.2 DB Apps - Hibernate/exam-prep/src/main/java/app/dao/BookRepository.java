package app.dao;

import app.domain.Book;
import app.domain.Category;
import app.domain.enums.AgeRestriction;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;

import javax.transaction.Transactional;
import java.util.Date;
import java.util.List;


public interface BookRepository extends CrudRepository<Book, Long> {
    Book findById(Long id);

    Iterable<Book> findAll();

    List<Book> findByAgeRestriction(AgeRestriction ageRestriction);

    @Query(value = "SELECT b FROM Book AS b WHERE b.editionType = 'GOLD' AND b.copies < 5000")
    List<Book> findByEditionAndPages();

    @Query(value = "SELECT b FROM Book AS b WHERE b.price < 5 OR b.price >40")
    List<Book> findByPrice();

    List<Book> findByReleaseDateNot(Date date);

    List<Book> findByCategoriesIn(List<Category> categories);

    List<Book> findByReleaseDateBefore(Date date);

    @Query(value = "SELECT COUNT(b) FROM Book AS b WHERE LENGTH(b.title) > :len")
    int countByTitleLength(@Param(value = "len") int len);

    @Query(value = "SELECT a, SUM(b.copies) AS copies " +
            "FROM Book AS b " +
            "INNER JOIN b.author AS a " +
            "GROUP BY a " +
            "ORDER BY copies DESC")
    List<Object[]> findSumOfCopies();

    @Query(value = "SELECT c, COUNT(b) AS bookCount " +
            "FROM Book AS b " +
            "INNER JOIN b.categories AS c " +
            "GROUP BY c " +
            "HAVING COUNT(b) > 0")
    List<Object[]> findCountOfBooksByCategories();

    List<Book> findTop3ByCategoriesOrderByReleaseDateDescTitleAsc(Category category);

    @Modifying
    @Transactional
    @Query(value = "UPDATE Book AS b " +
            "SET b.copies = b.copies + :copies " +
            "WHERE b.releaseDate > :releaseDate")
    int updateBooksByDateWithCopies(@Param(value = "releaseDate") Date releaseDate, @Param(value = "copies") int copies);
}