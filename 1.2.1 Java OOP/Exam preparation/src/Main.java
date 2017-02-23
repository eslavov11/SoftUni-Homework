import java.io.File;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * Created by Edi on 01-Jan-17.
 */
public class Main {
    public static void main(String[] args) {
        //renameAndMoveFiles();
        //deleteSameFiles();
    }

    private static void deleteSameFiles() {
        String filesDest = "C:\\Users\\Edi\\Desktop\\IMAG";

        int count = 0;

        File filesDir = new File(filesDest);
        for (File file : filesDir.listFiles()) {
            if (file.getName().indexOf('A') != -1 && file.length() < 70000) {
                count++;
                file.delete();
            }
        }

        System.out.println(count);
    }

    private static void renameAndMoveFiles() {
        String filesDirPath = "C:\\Users\\Edi\\Desktop\\REC 7.1";
        String filesDestPath = "C:\\Users\\Edi\\Desktop\\IMAG";

        File files = new File(filesDirPath);
        File newFile = null;

        String extension = "";

        for (File fileDirs : files.listFiles()) {
            for (File file : fileDirs.listFiles()) {
                int i = file.getName().lastIndexOf('.');
                if (i > 0) {
                    extension = file.getName().substring(i+1);
                }

                if ("jpg".equalsIgnoreCase(extension)/* || "mp4".equalsIgnoreCase(extension)*/) {
                    String fileNewName = convertDate(new Date(file.lastModified()));

                    newFile = new File(filesDestPath + "\\" + fileNewName + "." + extension);
                    boolean renamed = file.renameTo(newFile);

                    char suffix = 'A';

                    while (!renamed) {
                        System.out.println("Collision of names: " + suffix);
                        newFile = new File(filesDestPath + "\\" + fileNewName + suffix + "." + extension);
                        renamed = file.renameTo(newFile);

                        suffix++;
                    }
                } /*else if ("mp3".equalsIgnoreCase(extension)) {
                //System.out.println("mp3");
            }*/
            }
        }

        System.out.println("Operation successful");
    }

    public static String convertDate(Date d) {
        return new SimpleDateFormat("yyyyMMdd_HHmmss").format(d.getTime());
    }
}
