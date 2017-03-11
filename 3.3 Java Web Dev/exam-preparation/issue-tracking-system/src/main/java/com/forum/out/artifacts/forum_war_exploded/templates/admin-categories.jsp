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
<c:choose>
    <c:when test="${sessionScope.user != null}">
        <jsp:include page="nav-logged.jsp"/>
    </c:when>
    <c:otherwise>
        <jsp:include page="nav-not-logged.jsp"/>
    </c:otherwise>
</c:choose>
<div class="container">
    <div class="container">
        <a href="/admin/categories/add" class="btn btn-success">New Category</a>
        <table class = "table table-striped">
            <caption>Categories</caption>
            <thead>
            <tr>
                <th>Name</th>
                <th>Edit</th>
                <th>Delete</th>
            </tr>
            </thead>
            <tbody>
            <c:forEach items="${categories}"  var="category">
            <tr>

                    <td><a href="#">${category.name}</a></td>
                    <td><a href="/admin/categories/edit/${category.id}" class="btn btn-primary">Edit</a></td>
                    <td><a href="/admin/categories/delete/${category.id}#" class="btn btn-danger">Delete</a></td>

            </tr>
            </c:forEach>
            </tbody>
        </table>
    </div>
</div>
<body>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
<script src="${pageContext.request.contextPath}/bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
