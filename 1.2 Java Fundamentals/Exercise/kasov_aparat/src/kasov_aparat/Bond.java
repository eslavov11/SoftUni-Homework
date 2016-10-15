package kasov_aparat;

import java.util.ArrayList;
import java.util.Date;

public class Bond {
    private int id;
    private Date date;
    private ArrayList<Position> positions;

    public Bond() {}

    public Bond(int id, Date date, ArrayList<Position> positions) {
        this.setId(id);
        this.setDate(date);
        this.setPositions(positions);
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }

    public ArrayList<Position> getPositions() {
        return positions;
    }

    public void setPositions(ArrayList<Position> positions) {
        this.positions = positions;
    }

    @Override
    public String toString() {
        return "Bond{" +
                "id=" + this.getId() +
                ", date=" + this.getDate() +
                ", positions=" + this.getPositions() +
                '}';
    }

    public static void main(String[] args) {
        Bond b1 = new Bond(1, new Date(), new ArrayList<Position>() {{add(new Position(1, 1, 2));}});
        Bond b2 = new Bond(2, new Date(), new ArrayList<Position>() {{add(new Position(2, 2, 4));}});
        Bond b3 = new Bond(3, new Date(),
                new ArrayList<Position>() {{add(new Position(3, 3, 8)); add(new Position(4, 3, 8));}});

        System.out.println(b1);
        System.out.println(b2);
        System.out.println(b3);
    }
}

class Position {
    private int number;
    private int code;
    private int quantity;

    public Position(int number, int code, int quantity) {
        this.setNumber(number);
        this.setCode(code);
        this.setQuantity(quantity);
    }

    public int getNumber() {
        return number;
    }

    public void setNumber(int number) {
        this.number = number;
    }

    public int getCode() {
        return code;
    }

    public void setCode(int code) {
        this.code = code;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }

    @Override
    public String toString() {
        return "Position{" +
                "number=" + this.getNumber() +
                ", code=" + this.getCode() +
                ", quantity=" + this.getQuantity() +
                '}';
    }
}

//    Създайте клас Bond (касов бон) с атрибути 1) уникален номер на бона, 2) дата и час,
//    и 3) една или повече позиции. Всяка позиция има 1) номер на позиция, 2) код на стоката,
//    3)количество. Реализирайте следните методи 1) конструктор без аргументи (default constructor),
//    2) конструктор с три аргумента (номер, дата и час, списък с позиции), 3) метод toString(),
//    който да връща информацията за бона в текстов вид. Създайте също статичен метод main,
//    в който да се създаде нов касов бон и да се отпечата на екрана в текстов вид.