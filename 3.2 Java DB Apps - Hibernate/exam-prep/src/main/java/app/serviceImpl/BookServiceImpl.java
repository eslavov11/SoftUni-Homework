package app.serviceImpl;

import app.dao.BookRepository;
import app.domain.Book;
import app.domain.Category;
import app.domain.enums.AgeRestriction;
import app.service.BookService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Primary;
import org.springframework.stereotype.Service;

import java.util.Date;
import java.util.List;

@Service
@Primary
public class BookServiceImpl implements BookService{

    @Autowired
    private BookRepository bookRepository;

    @Override
    public void save(Book book) {
        bookRepository.save(book);
    }

    @Override
    public void delete(Book book) {
        bookRepository.delete(book);
    }

    @Override
    public void delete(Long id) {
        bookRepository.delete(id);
    }

    @Override
    public Book findBook(Long id) {
        return bookRepository.findById(id);
    }

    @Override
    public Iterable<Book> findBooks() {
        return bookRepository.findAll();
    }

    @Override
    public List<Book> findByAgeRestriction(AgeRestriction ageRestriction) {
        return bookRepository.findByAgeRestriction(ageRestriction);
    }

    @Override
    public List<Book> findByEditionAndPages() {
        return bookRepository.findByEditionAndPages();
    }

    @Override
    public List<Book> findByPrice() {
        return bookRepository.findByPrice();
    }

    @Override
    public List<Book> findByReleaseDateNot(Date date) {
        return bookRepository.findByReleaseDateNot(date);
    }

    @Override
    public List<Book> findByCategoriesIn(List<Category>  categories) {
        return bookRepository.findByCategoriesIn(categories);
    }

    @Override
    public List<Book> findByReleaseDateBefore(Date date) {
        return bookRepository.findByReleaseDateBefore(date);
    }

    @Override
    public int countByTitleLength(int len) {
        return this.bookRepository.countByTitleLength(len);
    }

    @Override
    public List<Object[]> findSumOfCopies() {
        return this.bookRepository.findSumOfCopies();
    }

    @Override
    public List<Object[]> findCountOfBooksByCategories() {
        return this.bookRepository.findCountOfBooksByCategories();
    }

    @Override
    public List<Book> findTop3ByCategoriesOrderByReleaseDateDescTitleAsc(Category category) {
        return this.bookRepository.findTop3ByCategoriesOrderByReleaseDateDescTitleAsc(category);
    }

    @Override
    public int updateBooksByDateWithCopies(Date releaseDate, int copies) {
       return this.bookRepository.updateBooksByDateWithCopies(releaseDate, copies);
    }
}
