package com.mass_defect.data_parsers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import org.springframework.stereotype.Component;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

/**
 * Created by Edi on 19-Nov-16.
 */
@Component
public class JSONParserImpl {
    private Gson gson;

    public JSONParserImpl() {
        this.setGson(new GsonBuilder().setPrettyPrinting().create());
    }

    private Gson getGson() {
        return gson;
    }

    private void setGson(Gson gson) {
        this.gson = gson;
    }

    public <T> T[] readFromJSON(Class<T[]> classes, String file) {
        String fileData = null;
        T[] objects = null;

        try {
            fileData = new String(Files.readAllBytes(Paths.get(file)));
            objects = this.getGson().fromJson(fileData, classes);
        } catch (IOException e) {
            e.printStackTrace();
        }

        return objects;
    }

    public <T> void writeToJSON(T object, String file) {
        String json = this.getGson().toJson(object);
        BufferedWriter bufferedWriter = null;

        try {
            bufferedWriter = new BufferedWriter(new FileWriter(file));
            bufferedWriter.write(json);
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            try {
                if (bufferedWriter != null) {
                    bufferedWriter.close();
                }
            } catch (IOException e) {
                e.printStackTrace();
            }
        }


    }
}
