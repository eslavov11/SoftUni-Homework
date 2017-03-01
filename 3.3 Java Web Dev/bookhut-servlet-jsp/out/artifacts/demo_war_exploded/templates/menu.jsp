
<%@ page import="com.bookhut.config.Config" %>
<%@ page import="com.bookhut.model.bindingModel.LoginModel" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
    <head>
        <link rel="stylesheet" type="text/css" href="/public/css/home.css"/>
    </head>
    <body>
    <header>
        <nav>
            <ul>
                <li><a href="/">Home</a></li>
                <li><a href="/signup">Sign Up</a></li>
                <%
                    LoginModel loginModel = (LoginModel) session.getAttribute(Config.LOGIN_MODEL);
                    String username = null;
                    if(loginModel != null){
                        username = loginModel.getUsername();
                        request.setAttribute(Config.USERNAME, username);
                    }
                %>
                <c:set var="username" value="${USERNAME}" scope="session"/>
                <c:choose>
                    <c:when test="${username != null}">
                        <li><a href="/signout">Sign Out(${username})</a></li>
                    </c:when>
                    <c:otherwise>
                        <li><a href="/signin">Sign In</a></li>
                    </c:otherwise>
                </c:choose>
                <li><a href="/add">Add Book</a></li>
                <li><a href="/shelves">Shelves</a></li>
            </ul>
        </nav>
    </header>

    </body>
</html>
