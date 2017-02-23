package com.pizzamoreLab.utils;

import java.io.*;
import java.net.URLDecoder;
import java.util.LinkedHashMap;
import java.util.Map;

public class WebUtils {

    public static boolean isPost() {
        String requestMethod = System.getProperty("cgi.request_method").toLowerCase();
        return requestMethod.equals("post");
    }

    public static Map<String, String> getParameters() {
        Map<String, String> parametersMap = new LinkedHashMap<>();
        String input = "";
        if (WebUtils.isPost()) {
            BufferedReader bira = null;
            try {
                bira = new BufferedReader(new InputStreamReader(System.in));
                input = bira.readLine();
            } catch (IOException e) {
                e.printStackTrace();
            } finally {
                try {
                    if (bira != null) {
                        bira.close();
                    }
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        } else {
            input = System.getProperty("cgi.query_string");
        }
        String[] parameters = new String[0];
        try {
            parameters = URLDecoder.decode(input, "UTF-8").split("&");
        } catch (UnsupportedEncodingException e) {
            e.printStackTrace();
        }
        for (String parameter : parameters) {
            String[] pair = parameter.split("=");
            String key = pair[0];
            String value = null;
            if (pair.length > 1) {
                value = pair[1];
            }
            parametersMap.put(key, value);
        }
        return parametersMap;
    }

    public static String readWholeFile(String absolutePath) {
        BufferedReader reader = null;
        StringBuilder sb = new StringBuilder();
        try {
            reader = new BufferedReader(new InputStreamReader(new FileInputStream(absolutePath)));
            String line;
            while (true) {
                line = reader.readLine();
                if (line == null) {
                    break;
                }
                sb.append(line).append(System.lineSeparator());
            }
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            try {
                if (reader != null) {
                    reader.close();
                }
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
        return sb.toString();
    }
}
