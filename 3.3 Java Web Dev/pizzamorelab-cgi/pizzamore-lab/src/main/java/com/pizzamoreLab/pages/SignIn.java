package com.pizzamoreLab.pages;

import com.pizzamoreLab.models.cookie.Cookie;
import com.pizzamoreLab.models.header.Header;
import com.pizzamoreLab.models.session.Session;
import com.pizzamoreLab.models.user.User;
import com.pizzamoreLab.repository.SessionRepository;
import com.pizzamoreLab.repository.UserRepository;
import com.pizzamoreLab.utils.WebUtils;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by Edi on 19-Feb-17.
 */
public class SignIn {
    private static Map<String, String> parameters;
    private static Map<String, Cookie> cookies;
    private static Header header;
    private static UserRepository userRepository;
    private static SessionRepository sessionRepository;

    static {
        parameters = new HashMap<>();
        cookies = new HashMap<>();
        header = new Header();
        userRepository = new UserRepository();
        sessionRepository = new SessionRepository();
    }

    public static void readParameters() {
        parameters = WebUtils.getParameters();

        for (String param : parameters.keySet()) {
            switch (param) {
                case "signin":
                    singIn();
                    break;
                case "main":
                    goToMain();
                    break;
                default:
                    break;
            }
        }
    }

    private static void singIn() {
        String username = parameters.get("username");
        String password = parameters.get("password");
        User user = userRepository.findByUserAndPassword(username, password);
        if (user != null) {

            Session session = new Session();
            session.addData("username", username);
            long sid = sessionRepository.createSession(session);
            Cookie sessionCookie = new Cookie("sid", String.valueOf(sid));
            header.setCookie(sessionCookie);
            header.setLocation("http://localhost/cgi-bin/home.cgi");
        }
    }

    private static void goToMain() {
        header.setLocation("http://localhost/cgi-bin/home.cgi");
    }

    public static void main(String[] args) {
        readParameters();
        header.printHeader();
        readHtml();
    }

    private static void readHtml() {
        String html = "<!DOCTYPE html>\n" +
                "<html lang=\"en\">\n" +
                "<head>\n" +
                "    <meta charset=\"UTF-8\">\n" +
                "    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\"/>\n" +
                "    <title>SignIn</title>\n" +
                "    <link rel=\"stylesheet\" type=\"text/css\" href=\"/bootstrap/css/bootstrap.min.css\"/>\n" +
                "    <link rel=\"stylesheet\" type=\"text/css\" href=\"/css/signin.css\"/>\n" +
                "</head>\n" +
                "<body>\n" +
                "<div class=\"container-fluid\">\n" +
                "    <div class=\"jumbotron\">\n" +
                "        <form method=\"post\" class=\"form-horizontal\">\n" +
                "            <div class=\"form-group\">\n" +
                "                <label class=\"control-label col-sm-2 col-sm-offset-2\">Username</label>\n" +
                "                <div class=\"col-sm-3\">\n" +
                "                    <input class=\"form-control\" type=\"text\" name=\"username\">\n" +
                "                </div>\n" +
                "            </div>\n" +
                "            <div class=\"form-group\">\n" +
                "                <label class=\"control-label col-sm-2 col-sm-offset-2\">Password</label>\n" +
                "                <div class=\"col-sm-3\">\n" +
                "                    <input class=\"form-control\" type=\"password\" name=\"password\">\n" +
                "                </div>\n" +
                "            </div>\n" +
                "            <div class=\"form-group\">\n" +
                "                <div class=\"checkbox col-sm-4 col-sm-offset-4\">\n" +
                "                    <label>\n" +
                "                        <input type=\"checkbox\" name=\"rememberme\">\n" +
                "                        <span>Remember Me</span>\n" +
                "                    </label>\n" +
                "                </div>\n" +
                "            </div>\n" +
                "            <div class=\"form-group\">\n" +
                "                <div class=\"col-sm-4 col-sm-offset-4\">\n" +
                "                    <input class=\"btn btn-success\" type=\"submit\" name=\"signin\" value=\"Sign In\"/>\n" +
                "                    <input class=\"btn btn-danger\" type=\"submit\" name=\"home\" value=\"Home\"/>\n" +
                "                </div>\n" +
                "            </div>\n" +
                "        </form>\n" +
                "    </div>\n" +
                "</div>\n" +
                "\n" +
                "<script src=\"/jquery/jquery.min.js\"></script>\n" +
                "<script src=\"/bootstrap/js/bootstrap.min.js\"></script>\n" +
                "</body>\n" +
                "</html>";

        System.out.println(html);
    }
}
