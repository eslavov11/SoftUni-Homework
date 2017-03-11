<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html lang="en">
<head>
    <title>Game Store</title>
    <meta charset="UTF-8">
    <link href="${pageContext.request.contextPath}/static/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
</head>
<body>

<jsp:include page="menu.jsp"/>
<!--Body of the store-->

<main>
    <div class="container">
        <div class="row">
            <h2 class="m-1">All Games &ndash;&nbsp;</h2> <a href="${pageContext.request.contextPath}/games/add" class="btn btn-warning m-1"><strong>+</strong> Add
            Game</a>
            <table class="table table-striped table-hover">
                <thead>
                <tr>
                    <th>#</th>
                    <th>Name</th>
                    <th>Size</th>
                    <th>Price</th>
                    <th>Actions</th>
                </tr>
                </thead>
                <tbody>
                <c:forEach items="${gameViewModels}" var="game">
                <tr class="table-warning">
                    <th scope="row">${game.id}</th>
                    <td>${game.title}</td>
                    <td>${game.size} GB</td>
                    <td>${game.price} &euro;</td>
                    <td>
                        <a href="${pageContext.request.contextPath}/games/edit/${game.id}" class="btn btn-warning btn-sm">Edit</a>
                        <a href="${pageContext.request.contextPath}/games/delete/${game.id}" class="btn btn-danger btn-sm">Delete</a>
                    </td>
                </tr>
                </c:forEach>
                </tbody>
            </table>

        </div>
    </div>
</main>


<!--Footer-->
<footer>
    <div class="container modal-footer">
        <p>&copy; 2017 - Software University Foundation</p>
    </div>
</footer>

<script src="${pageContext.request.contextPath}/static/scripts/jquery-3.1.1.min.js"></script>
<script src="${pageContext.request.contextPath}/static/js/bootstrap.min.js"></script>
</body>
</html>