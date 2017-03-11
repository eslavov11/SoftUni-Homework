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

<br/>
<c:forEach items="${errors}" var="error">
    <div class="alert alert-danger alert-dismissable">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Oh snap!</strong> ${error}
    </div>
</c:forEach>

<!--Body of the store-->
<main class="col-4 offset-4 text-center">
    <div class="container">
        <div class="row">
            <div class="col-12">
                <div class="text-center"><h1 class="display-3">Edit Game - ${game.title}</h1></div>
                <br/>
                <form method="post">
                    <div class="form-group row">
                        <label class="form-control-label">Title</label>
                        <input name="title" pattern="[A-Z].{3,100}" class="form-control"
                               placeholder="Enter Game Title" value="${game.title}"/>
                    </div>

                    <div class="form-group row">
                        <label class="form-control-label">Description</label>
                        <textarea name="description" class="form-control" placeholder="Enter Game Description" minlength="20">
                            ${game.description}
                        </textarea>
                    </div>

                    <div class="form-group row">
                        <label class="form-control-label">Thumbnail</label>
                        <input name="thumbnailURL" type="url" class="form-control" placeholder="Enter URL to Image" value="${game.thumbnailURL}"/>
                    </div>

                    <div class="form-group row">
                        <label class="form-control-label">Price</label>
                        <div class="input-group">

                            <input name="price" step="0.01" min="0" class="form-control" placeholder="Enter Price" value="${game.price}"/>
                            <span class="input-group-addon">&euro;</span>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label class="form-control-label">Size</label>
                        <div class="input-group">

                            <input name="size" step="0.1" min="0" class="form-control" placeholder="Enter Size" value="${game.size}"/>
                            <span class="input-group-addon">GB</span>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label class="form-control-label">YouTube Video URL</label>
                        <div class="input-group">
                            <span class="input-group-addon">https://www.youtube.com/watch?v=</span>
                            <input name="trailer" class="form-control" minlength="11" maxlength="11" value="${game.trailer}"/>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label class="form-control-label">Release Date</label>
                        <input name="releaseDate" type="date" class="form-control" placeholder="yyyy-MM-dd" value="${game.releaseDate}"/>
                    </div>

                    <input type="submit" class="btn btn-outline-warning btn-lg btn-block"
                           value="Edit Game"/>
                </form>
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