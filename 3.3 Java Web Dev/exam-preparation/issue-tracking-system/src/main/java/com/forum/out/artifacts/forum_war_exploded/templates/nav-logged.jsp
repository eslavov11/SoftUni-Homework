<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<div class="navbar-wrapper">
    <div class="container">
        <nav class="navbar navbar-inverse navbar-static-top">
            <div class="container">
                <div id="navbar">
                    <ul class="nav navbar-nav">
                        <li><a href="/topics">Topics</a></li>
                        <li><a href="/categories">Categories</a></li>
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Admin <span class="caret"></span></a>
                                <ul class="dropdown-menu">
                                    <li class=""><a href="/admin/categories">Categories</a></li>
                                </ul>
                            </li>
                    </ul>
                    <ul class="signmenu nav navbar-nav">
                        <li><span class="navbar-text">Hello, <a href="/user/profile?profileId=${sessionScope.user.id}">${sessionScope.user.username}</a></span></li>
                        <li><span class="navbar-text"><a href="/logout">Log out</a></span></li>
                    </ul>
                </div>
            </div>
        </nav>
    </div>
</div>