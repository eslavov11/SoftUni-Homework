<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <title>Forum</title>
    <link href="${pageContext.request.contextPath}/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <link href="${pageContext.request.contextPath}/css/style.css" rel="stylesheet">
</head>
<body>
<c:choose>
    <c:when test="${sessionScope.user != null}">
        <jsp:include page="nav-logged.jsp"/>
    </c:when>
    <c:otherwise>
        <jsp:include page="nav-not-logged.jsp"/>
    </c:otherwise>
</c:choose>
<c:forEach items="${violations}" var="violation">
    <div class="alert alert-danger alert-dismissable">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Error!</strong> ${violation.getMessage()}
    </div>
</c:forEach>
<c:choose>
    <c:when test="${passwordMismatch != null}">
        <div class="alert alert-danger alert-dismissable">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong>Error!</strong> Passwords are not matching
        </div>
    </c:when>
    <c:when test="${userExists != null}">
        <div class="alert alert-danger alert-dismissable">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong>Error!</strong> The user already exists
        </div>
    </c:when>
</c:choose>
<div class="container">
    <form method="POST">
        <label>Username</label>
        <div class="form-group">
            <input name="username" type="text" class="form-control" placeholder="Enter username">
        </div>
        <label>Email</label>
        <div class="form-group">
            <input name="email" type="text" class="form-control" placeholder="Enter email">
        </div>
        <label>Password</label>
        <div class="form-group">
            <input name="password" type="password" class="form-control" placeholder="Enter password">
        </div>
        <label>Confirm Password</label>
        <div class="form-group">
            <input name="confirmPassword" type="password" class="form-control" placeholder="Confirm password">
        </div>
        <input type="reset" class="btn btn-danger" value="Clear"/>
        <input type="submit" class="btn btn-success" value="Register"/>
    </form>
</div>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
<script src="${pageContext.request.contextPath}/bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
