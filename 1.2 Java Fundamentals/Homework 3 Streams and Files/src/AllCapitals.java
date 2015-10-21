import java.awt.List;
import java.io.*;
public class AllCapitals {
	public static void main(String[] args) {
		List text = new List();
		try(
				  BufferedReader fileReader = new BufferedReader(
				    new FileReader("allCapitals.txt"));
				) {
				  while (true) {
				    String line = fileReader.readLine();
				    if (line == null) break;
				    line = line.toUpperCase();
			    	text.add(line);
				    
				    
				  }
				} catch (IOException ioex) {
				  System.err.println("Cannot read the file ");
				}
		try(PrintWriter print = new PrintWriter("allCapitals.txt");)
	    {
	    	for (int i = 0; i < text.getItemCount(); i++) {
				print.write(text.getItem(i) + "\n");
			}
	    }
	    catch (IOException ioex) {
			  System.err.println("Error ");
			}

	}
}