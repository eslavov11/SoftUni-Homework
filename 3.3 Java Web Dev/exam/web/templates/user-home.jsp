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
            <div class="col-12">
                <div class="text-center"><h1 class="display-3">SoftUni Store</h1></div>

                <form class="form-inline">
                    Filter:
                    <input type="submit" name="filter" class="btn btn-link" value="All"/>
                    <input type="submit" name="filter" class="btn btn-link" value="Owned"/>
                </form>

                <c:forEach items="${gameViewModels}" var="game" varStatus="gamesCount">
                    <c:if test="${gamesCount.index mod 3 == 0}">
                        <div class="card-group">
                    </c:if>

                    <div class="card col-4 thumbnail">
                        <img class="card-image-top img-fluid img-thumbnail"
                             onerror="this.src='https://i.ytimg.com/vi/${game.thumbnailURL}/maxresdefault.jpg';"
                             src="${game.thumbnailURL}">

                        <div class="card-block">
                            <h4 class="card-title">${game.title}</h4>
                            <p class="card-text"><strong>Price</strong> - ${game.price}&euro;</p>
                            <p class="card-text"><strong>Size</strong> - ${game.size} GB</p>
                            <p class="card-text">${game.description}</p>
                        </div>

                        <div class="card-footer">
                            <a class="card-button btn btn-outline-primary" name="info" href="${pageContext.request.contextPath}/games/${game.id}">Info</a>
                            <a class="card-button btn btn-primary" name="buy" href="${pageContext.request.contextPath}/cart/add/${game.id}">Buy</a>
                        </div>
                    </div>

                    <c:if test="${gamesCount.index mod 3 == 2}">
                        </div>
                    </c:if>
                </c:forEach>
            </div>
        </div>
    </div>
</main>
<br/>

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