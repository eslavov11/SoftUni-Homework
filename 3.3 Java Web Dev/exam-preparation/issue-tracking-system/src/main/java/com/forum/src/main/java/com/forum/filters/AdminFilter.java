package com.forum.filters;

import com.forum.models.bindingModels.LoginModel;

import javax.servlet.*;
import javax.servlet.annotation.WebFilter;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import java.io.IOException;

@WebFilter("/admin/*")
public class AdminFilter implements Filter {
    public void destroy() {
    }

    public void doFilter(ServletRequest req, ServletResponse resp, FilterChain chain) throws ServletException, IOException {
        HttpSession session = ((HttpServletRequest) req).getSession();
        LoginModel loginViwModel = (LoginModel) session.getAttribute("user");
        if (loginViwModel != null && loginViwModel.isAdmin()) {
            chain.doFilter(req, resp);
        }

        ((HttpServletResponse) resp).sendRedirect("/no_admin_error_to_do");

    }

    public void init(FilterConfig config) throws ServletException {

    }
}
