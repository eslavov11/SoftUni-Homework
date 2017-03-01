package com.bookhut.controller;

import com.bookhut.model.bindingModel.LoginModel;
import com.bookhut.service.UserService;
import com.bookhut.serviceImpl.UserServiceImpl;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

/**
 * Created by Edi on 26-Feb-17.
 */
@WebServlet("/signup")
public class SignUpController extends HttpServlet {
    private UserService userService;

    public SignUpController() {
        this.userService = new UserServiceImpl();
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        LoginModel loginModel = null;
        String signupText = req.getParameter("signup");
        if (signupText != null) {
            String username = req.getParameter("username");
            String password = req.getParameter("password");
            loginModel = new LoginModel(username, password);
            this.userService.createUser(loginModel);
            resp.sendRedirect("/signin");
        }
    }

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        req.getRequestDispatcher("/templates/signup.jsp").forward(req, resp);
    }
}
