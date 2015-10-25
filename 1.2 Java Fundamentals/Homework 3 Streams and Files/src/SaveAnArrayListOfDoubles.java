import java.io.*;
import java.util.ArrayList;
import java.util.Iterator;
public class SaveAnArrayListOfDoubles {
    public static void main(String[] args) {
        ArrayList<Double> numbers = new ArrayList<>();
        numbers.add(2.9);
        numbers.add(4.6);
        numbers.add(9.253728);
        numbers.add(7.132427);

        try (ObjectOutputStream output = new ObjectOutputStream(
                new BufferedOutputStream(
                        new FileOutputStream(
                                new File("doubles.list"))))) {
            for (Iterator iterator = numbers.iterator(); iterator.hasNext();) {
            	output.writeObject((Double) iterator.next() + ", ");
				
			}
        	

        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}