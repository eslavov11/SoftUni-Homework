package com.pizzamoreLab.pages;

import com.pizzamoreLab.models.cookie.Cookie;
import com.pizzamoreLab.models.header.Header;
import com.pizzamoreLab.models.session.Session;
import com.pizzamoreLab.models.session.SessionData;
import com.pizzamoreLab.repository.SessionRepository;
import com.pizzamoreLab.utils.WebUtils;
import com.sun.deploy.util.Waiter;

import java.util.HashMap;
import java.util.Map;
import java.util.Set;

/**
 * Created by Edi on 18-Feb-17.
 */
public class Home {
    private static Map<String, String> parameters;
    private static Map<String, Cookie> cookies;
    private static Header header;
    private static SessionRepository sessionRepository;

    static {
        parameters = new HashMap<>();
        cookies = new HashMap<>();
        header = new Header();
        sessionRepository = new SessionRepository();
    }

    public static void readParameters() {
        parameters = WebUtils.getParameters();
        for (String param : parameters.keySet()) {
            switch (param) {
                case "language":
                    String value = parameters.get("language");
                    setCookie("lang", value);
                    break;
                case "signin":
                    goToSignIn();
                    break;
                case "signup":
                    goToSignUp();
                default:
                    break;
            }
        }
    }

    private static void goToSignUp() {
        header.setLocation("http://localhost:80/cgi-bin/signup.cgi");
    }

    private static void goToSignIn() {
        header.setLocation("http://localhost:80/cgi-bin/signin.cgi");
    }

    private static void setCookie(String key, String value) {
        Cookie cookie = new Cookie(key, value);
        header.setCookie(cookie);
    }

    private static void readCookies(String[] args) {
        if (args.length == 0) {
            return;
        }

        for (String incomingCookie : args) {
            String[] tokens = incomingCookie.split("=");
            String key = tokens[0];
            String value = tokens[1];
            value = value.replace(";", "");
            Cookie cookie = new Cookie(key, value);
            cookies.put(key, cookie);
        }
    }

    public static void signOut(long id) {
        sessionRepository.delete(id);
    }

    private static void readHtml() {
        Cookie sessionCookie = cookies.get("sid");
        String username = null;
        if (sessionCookie != null) {
            long sid = Long.parseLong(sessionCookie.getValue());
            Session session = sessionRepository.findById(sid);
            if (parameters.containsKey("signout")) {
                signOut(sid);
                session = null;
            }

            if (session != null) {
                Set<SessionData> sessionData = session.getSessionData();
                for (SessionData data : sessionData) {
                    if (data.getKey().equals("username")) {
                        username = data.getValue();
                    }
                }
            }
        }


        Cookie languageCookie;
        if (!WebUtils.isPost()) {
            if (cookies.containsKey("lang")) {
                languageCookie = cookies.get("lang");
                if (languageCookie.getValue().equals("DE")) {
                    readHtmlDE(username);
                } else {
                    readHtmlEN(username);
                }
            } else {
                readHtmlEN(username);
            }
        } else {
            if (parameters.containsKey("language")) {
                String language = parameters.get("language");
                if (language.equals("DE")) {
                    readHtmlDE(username);
                } else {
                    readHtmlEN(username);
                }
            }
        }
    }

    public static void main(String[] args) {
        readParameters();
        header.printHeader();
        readCookies(args);
        readHtml();
    }

    private static void readHtmlEN(String username) {
        String signInOutBtnLbl = (username == null) ? "Sign in" : ("Sign out (" + username + ")");
        String signInOutBtnName = (username == null) ? "signin" : "signout";

        String html = "<!DOCTYPE html>\n" +
                "<html lang=\"en\">\n" +
                "    <head>\n" +
                "        <meta charset=\"UTF-8\">\n" +
                "        <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\"/>\n" +
                "        <title>Home</title>\n" +
                "        <link rel=\"stylesheet\" type=\"text/css\" href=\"/bootstrap/css/bootstrap.min.css\"/>\n" +
                "        <link rel=\"stylesheet\" type=\"text/css\" href=\"/css/home.css\"/>\n" +
                "    </head>\n" +
                "    <body>\n" +
                "        <div class=\"container-fluid\">\n" +
                "            <div id=\"myCarousel\" class=\"carousel slide\" data-ride=\"carousel\">\n" +
                "                <ol class=\"carousel-indicators\">\n" +
                "                    <li data-target=\"#myCarousel\" data-slide-to=\"0\" class=\"active\"></li>\n" +
                "                    <li data-target=\"#myCarousel\" data-slide-to=\"1\"></li>\n" +
                "                </ol>\n" +
                "                <div class=\"carousel-inner\" role=\"listbox\">\n" +
                "                    <div class=\"item active\">\n" +
                "                        <img src=\"/images/pizza_1.jpg\" alt=\"Pizza1\">\n" +
                "                    </div>\n" +
                "                    <div class=\"item\">\n" +
                "                        <img src=\"/images/pizza_2.jpg\" alt=\"Pizza2\">\n" +
                "                    </div>\n" +
                "                </div>\n" +
                "            </div>\n" +
                "            <nav id=\"navigation\" class=\"navbar navbar-default\">\n" +
                "                <div class=\"container\">\n" +
                "                    <div class=\"navbar-header\">\n" +
                "                        <a class=\"navbar-brand\">PizzaMore</a>\n" +
                "                    </div>\n" +
                "                    <form method=\"post\">\n" +
                "                        <input class=\"btn btn-primary\" type=\"submit\" name=\"language\" value=\"DE\"/>\n" +
                "                        <input class=\"btn btn-success\" type=\"submit\" name=\"" + signInOutBtnName
                + "\" value=\"" + signInOutBtnLbl + "\"/>\n" +
                "                        <input class=\"btn btn-warning\" type=\"submit\" name=\"signup\" value=\"Sign Up\"/>\n" +
                "                    </form>\n" +
                "                </div>\n" +
                "            </nav>\n" +
                "        </div>\n" +
                "    <script src=\"/jquery/jquery.min.js\"></script>\n" +
                "    <script src=\"/bootstrap/js/bootstrap.min.js\"></script>\n" +
                "    </body>\n" +
                "</html>";

        System.out.println(html);
    }

    private static void readHtmlDE(String username) {
        String html = "<!DOCTYPE html>\n" +
                "<html lang=\"en\">\n" +
                "    <head>\n" +
                "        <meta charset=\"UTF-8\">\n" +
                "        <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\"/>\n" +
                "        <title>Home</title>\n" +
                "        <link rel=\"stylesheet\" type=\"text/css\" href=\"/bootstrap/css/bootstrap.min.css\"/>\n" +
                "        <link rel=\"stylesheet\" type=\"text/css\" href=\"/css/home.css\"/>\n" +
                "    </head>\n" +
                "    <body>\n" +
                "        <div class=\"container-fluid\">\n" +
                "            <div id=\"myCarousel\" class=\"carousel slide\" data-ride=\"carousel\">\n" +
                "                <ol class=\"carousel-indicators\">\n" +
                "                    <li data-target=\"#myCarousel\" data-slide-to=\"0\" class=\"active\"></li>\n" +
                "                    <li data-target=\"#myCarousel\" data-slide-to=\"1\"></li>\n" +
                "                </ol>\n" +
                "                <div class=\"carousel-inner\" role=\"listbox\">\n" +
                "                    <div class=\"item active\">\n" +
                "                        <img src=\"/images/pizza_1.jpg\" alt=\"Pizza1\">\n" +
                "                    </div>\n" +
                "                    <div class=\"item\">\n" +
                "                        <img src=\"/images/pizza_2.jpg\" alt=\"Pizza2\">\n" +
                "                    </div>\n" +
                "                </div>\n" +
                "            </div>\n" +
                "            <nav id=\"navigation\" class=\"navbar navbar-default\">\n" +
                "                <div class=\"container\">\n" +
                "                    <div class=\"navbar-header\">\n" +
                "                        <a class=\"navbar-brand\">PizzaMore</a>\n" +
                "                    </div>\n" +
                "                    <form method=\"post\">\n" +
                "                        <input class=\"btn btn-primary\" type=\"submit\" name=\"language\" value=\"EN\"/>\n" +
                "                        <input class=\"btn btn-success\" type=\"submit\" name=\"signin\" value=\"SIGNEN INEN!\"/>\n" +
                "                        <input class=\"btn btn-warning\" type=\"submit\" name=\"signup\" value=\"SIGNEN UPEN!\"/>\n" +
                "                    </form>\n" +
                "                </div>\n" +
                "            </nav>\n" +
                "        </div>\n" +
                "    <script src=\"/jquery/jquery.min.js\"></script>\n" +
                "    <script src=\"/bootstrap/js/bootstrap.min.js\"></script>\n" +
                "    </body>\n" +
                "</html>";

        System.out.println(html);
    }
}
