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
<c:set value="${topic}" var="topic"></c:set>
<div class="container">
    <div class="thumbnail">
        <h4><strong><a href="/topics">${topic.title}</a></strong></h4>
        <p><a href="/useres/profile">${topic.authorUsername}</a> ${topic.publishDate}</p>
        <p>${topic.content}</p>
    </div>
    <c:forEach items="${topic.replies}" var="reply">
        <c:choose>
            <c:when test="${reply.imageUrl != null}">
                <div class="thumbnail reply">
                    <h5><strong><a href="#">${reply.authorUsername}</a></strong> ${reply.publishDate}</h5>
                    <p>${reply.content}</p>
                    <img src="${reply.imageUrl}" />
                </div>
            </c:when>
            <c:otherwise>
                <div class="thumbnail reply">
                    <h5><strong><a href="#">${reply.authorUsername}</a></strong> ${reply.publishDate}</h5>
                    <p>${reply.content}</p>
                </div>
            </c:otherwise>
        </c:choose>
    </c:forEach>

    <div class="thumbnail reply">
        <form method="post">
            <div class="form-group">
                <label>Content</label>
                <textarea name="content" class="form-control" placeholder="Enter your reply..."></textarea>
            </div>
            <div class="form-group">
                <label>Image URL</label>
                <input name="imageUrl" type="text" class="form-control" placeholder="http://..."/>
            </div>
            <input type="submit" class="btn btn-primary" value="Reply"/>
        </form>
    </div>
</div>
<body>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
<script src="${pageContext.request.contextPath}/bootstrap/js/bootstrap.min.js"></script>
</body>
</html>