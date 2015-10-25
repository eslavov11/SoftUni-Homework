import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;

public class CopyJPGFile {
    public static void main(String[] args) {
        try(FileInputStream source = new FileInputStream("picture.jpg");
        FileOutputStream destination = new FileOutputStream("my-copied-picture.jpg")) {
            byte[] buffer = new byte[4096];
            while (true) {
                int readBytes = source.read(buffer, 0, buffer.length);
                if(readBytes <= 0) break;
                destination.write(buffer, 0, readBytes);
            }

        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}