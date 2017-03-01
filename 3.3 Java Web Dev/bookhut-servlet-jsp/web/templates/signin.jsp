<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
    <head>
        <title>Sign In</title>
    </head>
        <jsp:include page="menu.jsp"></jsp:include>
    <body>
        <form method="post">
            <label>Username</label>
            <input type="text" name="username"/>
            <label>Password</label>
            <input type="password" name="password"/>
            <input type="submit" name="signin" value="Sign In"/>
        </form>
    </body>
</html>
