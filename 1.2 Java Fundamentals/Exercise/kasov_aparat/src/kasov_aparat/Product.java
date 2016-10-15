package kasov_aparat;

public class Product {
    private int id;
    private String name;
    private double price;

    public Product() {
    }

    public Product(int id, String name, double price) {
        this.setId(id);
        this.setName(name);
        this.setPrice(price);
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    @Override
    public String toString() {
        return "Product{" +
                "id=" + this.getId() +
                ", name='" + this.getName() + '\'' +
                ", price=" + this.getPrice() +
                '}';
    }

    public static void main(String[] args) {
        Product p1 = new Product(1, "Product 1", 10);
        Product p2 = new Product(2, "Product 2", 20.5);
        Product p3 = new Product(3, "Product 3", 30);

        System.out.println(p1);
        System.out.println(p2);
        System.out.println(p3);
    }
}

//    Създайте клас Product с атрибути 1) код на стоката 2) наименование на стоката и
//        3) цена на стоката и методи 1) конструктор без аргументи (default constructor),
//        2) конструктор с три аргумента (код, наименование и цена на стоката),
//        3) метод toString(), който да връща информацията за стоката в текстов вид
//        Създайте също статичен метод main, в който да се създадат три различни продукта
//        (стоки) и да се отпечатат на екрана в текстов вид.