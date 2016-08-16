package io;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class ConsoleReader implements InputReader {

    private BufferedReader consoleReader;

    public ConsoleReader() {
        this.consoleReader = new BufferedReader(new InputStreamReader(System.in));
    }

    @Override
    public String readLine() {
        String inputLine = null;

        try {
            inputLine = this.consoleReader.readLine();
        } catch (IOException e) {
            return e.getMessage();
        }

        return inputLine;
    }
}
