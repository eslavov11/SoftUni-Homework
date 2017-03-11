package com.gameStore.filter;


import com.gameStore.entities.roles.Role;
import com.gameStore.models.bindingModels.GameEditBindingModel;
import com.gameStore.models.bindingModels.LoggedUserModel;

import javax.servlet.*;
import javax.servlet.annotation.WebFilter;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import java.io.IOException;

@WebFilter({"/games", "/games/add/*", "/games/edit/*", "/games/delete/*"})
public class LoginFilter implements Filter {
    @Override
    public void init(FilterConfig filterConfig) throws ServletException {

    }

    @Override
    public void doFilter(ServletRequest servletRequest, ServletResponse servletResponse, FilterChain filterChain) throws IOException, ServletException {
        HttpSession session = ((HttpServletRequest)servletRequest).getSession();
        LoggedUserModel loggedUserModel = (LoggedUserModel) session.getAttribute("user");
        if (loggedUserModel == null || loggedUserModel.getRole() != Role.ADMIN) {
            ((HttpServletResponse)servletResponse).sendRedirect("/login");
            return;
        }

        filterChain.doFilter(servletRequest, servletResponse);
    }

    @Override
    public void destroy() {

    }
}
