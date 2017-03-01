<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
    <head>
        <title>Add Book</title>
    </head>
    <body>
        <jsp:include page="menu.jsp"/>
        <form method="post">
            <label>Title</label>
            <input type="text" name="title"/>
            <label>Author</label>
            <input type="text" name="author">
            <label>Pages</label>
            <input type="text" name="pages">
            <input type="submit" name="add" value="Add">
        </form>
    </body>
</html>
