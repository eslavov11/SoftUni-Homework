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
<c:set value="${userTopicsViewModel}" var="user"></c:set>
<div class="container">
    <h1>${user.username}</h1>
    <table class = "table table-striped">
        <caption>Topics</caption>
        <thead>
        <tr>
            <th>Title</th>
            <th>Category</th>
            <th>Date</th>
            <th>Replies Count</th>
            <th>Delete</th>
        </tr>
        </thead>
        <tbody>
        <c:forEach items="${user.topics}" var="topic">
            <tr>
                <td><a href="#">${topic.title}</a></td>
                <td><a href="#">${topic.categoryName}</a></td>
                <td>${topic.publishDate}</td>
                <td>${topic.count}</td>
                <c:if test="${sessionScope.user.id == profileId}">
                    <td><a href="/topics/delete/${topic.id}" class="btn btn-danger"/>Delete</a></td>
                </c:if>

            </tr>
        </c:forEach>

        </tbody>
    </table>
</div>
<body>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
<script src="${pageContext.request.contextPath}/bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
