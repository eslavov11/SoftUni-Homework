package app;

import app.core.SystemSplitEngine;

import java.io.IOException;

/**
 * Created by Edi on 10-Jul-16.
 */
public class Main {
    public static void main(String[] args) throws IOException {
        SystemSplitEngine engine = new SystemSplitEngine();
        engine.run();
    }
}
