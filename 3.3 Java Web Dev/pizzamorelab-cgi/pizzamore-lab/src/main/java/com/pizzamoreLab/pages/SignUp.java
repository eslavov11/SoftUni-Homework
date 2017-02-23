package com.pizzamoreLab.pages;

import com.pizzamoreLab.models.cookie.Cookie;
import com.pizzamoreLab.models.header.Header;
import com.pizzamoreLab.models.user.User;
import com.pizzamoreLab.repository.UserRepository;
import com.pizzamoreLab.utils.WebUtils;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by Edi on 19-Feb-17.
 */
public class SignUp {
    private static Map<String, String> parameters;
    private static Header header;
    private static UserRepository userRepository;

    static {
        parameters = new HashMap<>();
        header = new Header();
        userRepository = new UserRepository();
    }

    public static void readParameters() {
        parameters = WebUtils.getParameters();
        String username = null;
        String password = null;
        for (String param : parameters.keySet()) {
            switch (param) {
                case "username":
                    username = parameters.get("username");
                    break;
                case "password":
                    password = parameters.get("password");
                    break;
                case "signup":
                    if (username.isEmpty() || password.isEmpty()) {
                        return;
                    }

                    User user = new User(username, password);
                    userRepository.crateUser(user);
                    header.setLocation("http://localhost:80/cgi-bin/signin.cgi");
                    break;
                case "main":
                    header.setLocation("http://localhost:80/cgi-bin/home.cgi");
                    break;
                default:
                    break;
            }
        }
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
                "    <title>SignUp</title>\n" +
                "    <link rel=\"stylesheet\" type=\"text/css\" href=\"/bootstrap/css/bootstrap.min.css\"/>\n" +
                "    <link rel=\"stylesheet\" type=\"text/css\" href=\"/css/signup.css\"/>\n" +
                "</head>\n" +
                "    <body>\n" +
                "    <div class=\"container-fluid\">\n" +
                "        <div class=\"jumbotron\">\n" +
                "            <form method=\"post\" class=\"form-horizontal\">\n" +
                "                <div class=\"form-group\">\n" +
                "                    <label class=\"control-label col-sm-2 col-sm-offset-2\">Username</label>\n" +
                "                    <div class=\"col-sm-3\">\n" +
                "                        <input class=\"form-control\" type=\"text\" name=\"username\">\n" +
                "                    </div>\n" +
                "                </div>\n" +
                "                <div class=\"form-group\">\n" +
                "                    <label class=\"control-label col-sm-2 col-sm-offset-2\">Password</label>\n" +
                "                    <div class=\"col-sm-3\">\n" +
                "                        <input class=\"form-control\" type=\"password\" name=\"password\">\n" +
                "                    </div>\n" +
                "                </div>\n" +
                "                <div class=\"form-group\">\n" +
                "                    <div class=\"col-sm-4 col-sm-offset-4\">\n" +
                "                        <input class=\"btn btn-success\" type=\"submit\" name=\"signup\" value=\"Sign Up\"/>\n" +
                "                        <input class=\"btn btn-danger\" type=\"submit\" name=\"home\" value=\"Home\"/>\n" +
                "                    </div>\n" +
                "                </div>\n" +
                "            </form>\n" +
                "        </div>\n" +
                "    </div>\n" +
                "\n" +
                "    <script src=\"/jquery/jquery.min.js\"></script>\n" +
                "    <script src=\"/bootstrap/js/bootstrap.min.js\"></script>\n" +
                "    </body>\n" +
                "</html>";

        System.out.println(html);
    }
}
