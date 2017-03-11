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
                <div class="text-center"><h1 class="display-3">Your Cart</h1></div>
                <br/>
                <div class="list-group">
                    <c:forEach items="${cart}" var="game" varStatus="gamesCount">
                    <div class="list-group-item">
                        <a class="btn btn-outline-danger btn-lg" href="${pageContext.request.contextPath}/cart/remove/${game.id}">X</a>
                        <div class="media col-3">
                            <figure class="pull-left">
                                <a href="#">
                                    <img
                                            class="card-image-top img-fluid img-thumbnail"
                                            onerror="this.src='https://i.ytimg.com/vi/${game.thumbnailURL}/maxresdefault.jpg';"
                                            src="${game.thumbnailURL}"></a>
                            </figure>
                        </div>
                        <div class="col-md-6">
                            <a href="#"><h4 class="list-group-item-heading"> ${game.title} </h4></a>
                            <p class="list-group-item-text">${game.description}
                            </p>
                        </div>
                        <div class="col-md-2 text-center mr-auto">
                            <h2> ${game.price}&euro; </h2>
                        </div>
                    </div>
                    </c:forEach>

                </div>
                <br/>
                <div class="col-8 offset-2 my-3 text-center">
                    <h1><strong>Total Price - </strong> 120 &euro;</h1>
                </div>
                <div class="col-8 offset-2 my-3">
                    <form method="post">

                        <input type="submit" class="btn btn-success btn-lg btn-block"
                               value="Order"/>
                    </form>
                </div>
                <br/>
            </div>
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