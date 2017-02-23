package app.console;

import app.domain.Author;
import app.domain.Book;
import app.domain.Category;
import app.domain.enums.AgeRestriction;
import app.domain.enums.EditionType;
import app.service.AuthorService;
import app.service.BookService;
import app.service.CategoryService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import java.io.*;
import java.math.BigDecimal;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.*;

@Component
public class ConsoleRunner implements CommandLineRunner {

    @Autowired
    private AuthorService authorService;

    @Autowired
    private BookService bookService;

    @Autowired
    private CategoryService categoryService;

    @Override
    public void run(String... strings) throws Exception {

//        1
//        BufferedReader bfr = new BufferedReader(new InputStreamReader(System.in));
//        String input;
//        while (!(input = bfr.readLine()).equals("Stop")) {
//            AgeRestriction ageRestriction = AgeRestriction.valueOf(input.toUpperCase());
//            List<Book> books = this.bookService.findByAgeRestriction(ageRestriction);
//            for (Book book : books) {
//                System.out.println(book.getTitle());
//            }
//        }
//        2
//         List<Book> books = bookService.findByEditionAndPages();
//        for (Book book : books) {
//            System.out.println(book.getTitle());
//        }
        
//        3
//        List<Book> books = bookService.findByPrice();
//        for (Book book : books) {
//            System.out.println(String.format("%s - %s", book.getTitle(), book.getPrice()));
//        }
//        4
//        SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd");
//        Date dtm = simpleDateFormat.parse("2016-03-12");
//        List<Book> books = bookService.findByReleaseDateNot(dtm);
//        for (Book book : books) {
//            System.out.println(book.getTitle());
//        }
//        5
//        BufferedReader bfr = new BufferedReader(new InputStreamReader(System.in));
//        String[] input = bfr.readLine().split("\\s+");
//        List<Category> categories = this.categoryService.findByName(input);
//        List<Book> books = this.bookService.findByCategoriesIn(categories);
//        for (Book book : books) {
//            System.out.println(book.getTitle());
//        }

//        6
//        BufferedReader bfr = new BufferedReader(new InputStreamReader(System.in));
//        String input = bfr.readLine();
//        SimpleDateFormat sdf = new SimpleDateFormat("dd-MM-yyyy");
//        Date releaseDate = sdf.parse(input);
//        List<Book> books =this.bookService.findByReleaseDateBefore(releaseDate);
//        for (Book book : books) {
//            System.out.println(String.format("%s - %s - %s",
//                    book.getTitle(), book.getEditionType(), book.getPrice()));
//        }

//        7
//        List<Author> authors = this.authorService.findByFirstNameStartsWith("pa");
//        for (Author author : authors) {
//            System.out.println(author.getFirstName());
//        }

//        10
//        int size = 12;
//        int books = this.bookService.countByTitleLength(size);
//        System.out.println(String.format("There are %d books with longer title than %d symbols", books,size));

//        11
//        List<Object[]> objects = this.bookService.findSumOfCopies();
//        for (Object[] object : objects) {
//            Author author = (Author) object[0];
//            long copies = (long) object[1];
//            System.out.println(String.format("%s - %d", author.getFirstName(), copies));
//        }

//        13
//       List<Object[]> obj = this.bookService.findCountOfBooksByCategories();
//        for (Object[] objects : obj) {
//            Category category = (Category) objects[0];
//            long bookCount = (long) objects[1];
//            System.out.println(String.format("--%s: %d books",category.getName(), bookCount));
//            List<Book> books = this.bookService.findTop3ByCategoriesOrderByReleaseDateDescTitleAsc(category);
//            for (Book book : books) {
//                String title = book.getTitle();
//                String year = new SimpleDateFormat("yyyy").format(book.getReleaseDate());
//                System.out.println(String.format("%s (%s)", title , year));
//            }
//        }

        BufferedReader bfr = new BufferedReader(new InputStreamReader(System.in));
        String input;
        while(!(input = bfr.readLine()).equals("Stop")){
            SimpleDateFormat sdf = new SimpleDateFormat("dd MMM yyyy");
            Date releaseDate = sdf.parse(input);
            int copies = Integer.parseInt(bfr.readLine());
            int booksUpdated = this.bookService.updateBooksByDateWithCopies(releaseDate, copies);
            long totalCopies = booksUpdated * copies;
            System.out.println(String.format("%d books are released after %s so total of %d book copies were added", booksUpdated, sdf.format(releaseDate), totalCopies));
        }
    }

    private void seedDatabase() throws IOException, ParseException {
        //TODO seed Authors from file authors.txt
        this.seedAuthors();
        //TODO seed categories from file categories.txt
        this.seedCategories();

        Random random = new Random();
        List<Author> authors = (List<Author>)  authorService.findAuthors();
        BufferedReader booksReader = new BufferedReader(new FileReader("books.txt"));
        String line = booksReader.readLine();
        while((line = booksReader.readLine()) != null){
            String[] data = line.split("\\s+");

            int authorIndex = random.nextInt(authors.size());
            Author author = authors.get(authorIndex);
            EditionType editionType = EditionType.values()[Integer.parseInt(data[0])];
            SimpleDateFormat formatter = new SimpleDateFormat("d/M/yyyy");
            Date releaseDate = formatter.parse(data[1]);
            int copies = Integer.parseInt(data[2]);
            BigDecimal price = new BigDecimal(data[3]);
            AgeRestriction ageRestriction = AgeRestriction.values()[Integer.parseInt(data[4])];
            StringBuilder titleBuilder = new StringBuilder();
            for (int i = 5; i < data.length; i++) {
                titleBuilder.append(data[i]).append(" ");
            }
            titleBuilder.delete(titleBuilder.lastIndexOf(" "), titleBuilder.lastIndexOf(" "));
            String title = titleBuilder.toString();

            Book book = new Book();
            //book.setAuthor(authorService.findAuthor(author.getId()));
            book.setEditionType(editionType);
            book.setReleaseDate(releaseDate);
            book.setCopies(copies);
            book.setPrice(price);
            book.setAgeRestriction(ageRestriction);
            book.setTitle(title);
            //TODO set random categories for current book

            bookService.save(book);
        }
    }

    private void seedCategories() throws IOException {
        BufferedReader reader = new BufferedReader(new FileReader("categories.txt"));
        String line = null;
        while((line = reader.readLine()) != null){
            Category category = new Category();
            category.setName(line);

            categoryService.save(category);
        }
    }

    private void seedAuthors() throws IOException {
        BufferedReader reader = new BufferedReader(new FileReader("authors.txt"));
        String line = reader.readLine();
        while((line = reader.readLine()) != null){
            String[] data = line.split("\\s+");

            Author author = new Author();
            author.setFirstName(data[0]);
            author.setLastName(data[1]);

            authorService.save(author);
        }
    }
}
