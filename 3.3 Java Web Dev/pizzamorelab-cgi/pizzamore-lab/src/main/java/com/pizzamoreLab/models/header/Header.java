package com.pizzamoreLab.models.header;

import com.pizzamoreLab.models.cookie.Cookie;

public class Header {

    private static final String CONTENT_TYPE="Content-type: text/html\n";

    private Cookie cookie;

    private String location;

    public Header() {
    }

    public Cookie getCookie() {
        return cookie;
    }

    public void setCookie(Cookie cookie) {
        this.cookie = cookie;
    }

    public String getLocation() {
        return location;
    }

    public void setLocation(String location) {
        this.location = location;
    }

    public void printHeader(){
        System.out.print(Header.CONTENT_TYPE);

        if(this.cookie != null){
            System.out.printf("Set-cookie: %s\n", this.cookie.getCookieValue());
        }

        if(this.location != null) {
            System.out.printf("Location: %s\n", this.location);
        }

        System.out.println();
    }
}
