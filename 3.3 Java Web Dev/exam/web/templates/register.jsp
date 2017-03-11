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
<main class="col-4 offset-4 text-center">
    <div class="container">
        <div class="row">
            <div class="col-12">
                <div class="text-center"><h1 class="display-3">Register</h1></div>
                <br/>
                <form method="post">
                    <div class="form-group row">
                        <label class="sr-only">Email</label>
                        <input name="email" class="form-control" placeholder="somebody@example.com"/>
                    </div>

                    <div class="form-group row">
                        <label class="sr-only">Full Name</label>
                        <input name="fullName" pattern="^[a-zA-Z -.]+$" class="form-control" placeholder="Full Name"/>
                    </div>

                    <div class="form-group row">
                        <label class="sr-only">Password</label>
                        <input name="password" type="password" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}" class="form-control" placeholder="Password"/>
                    </div>

                    <div class="form-group row">
                        <label class="sr-only">Confirm Password</label>
                        <input name="confirmPassword" type="password" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}" class="form-control" placeholder="Confirm Password"/>
                    </div>

                    <input type="submit" class="btn btn-outline-warning btn-lg btn-block"
                           value="Register"/>
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