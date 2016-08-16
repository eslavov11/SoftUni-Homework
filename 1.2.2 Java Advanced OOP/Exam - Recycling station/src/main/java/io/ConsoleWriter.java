package io;

public class ConsoleWriter implements OutputWriter {

    public ConsoleWriter() {
    }

    @Override
    public void write(String output) {
        System.out.print(output);
    }

    @Override
    public void write(String format, String output) {
        System.out.print(String.format(format, output));
    }

    @Override
    public void writeLine(String output) {
        System.out.println(output);
    }

    @Override
    public void writeLine(String format, String output) {
        System.out.println(String.format(format, output));
    }
}
