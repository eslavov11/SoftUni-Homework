package com.bookhut.filter;

import com.bookhut.config.Config;
import com.bookhut.model.bindingModel.LoginModel;

import javax.servlet.*;
import javax.servlet.annotation.WebFilter;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;
import java.io.IOException;

/**
 * Created by teodo on 16/02/2017.
 */
@WebFilter("/*")
public class Filter implements javax.servlet.Filter {
    @Override
    public void init(FilterConfig filterConfig) throws ServletException {

    }

    public void doFilter(ServletRequest req, ServletResponse resp, FilterChain chain) throws ServletException, IOException {
        HttpSession session = ((HttpServletRequest)req).getSession();
        LoginModel loginModel = (LoginModel) session.getAttribute(Config.LOGIN_MODEL);
        String username = null;
        if(loginModel != null){
            username = loginModel.getUsername();
            req.setAttribute(Config.USERNAME, username);
        }

        chain.doFilter(req, resp);
    }

    @Override
    public void destroy() {

    }

}
