package com.pizzamoreLab.models.cookie;

public class Cookie {

    private String name;

    private String value;

    public Cookie(String name, String value) {
        this.setName(name);
        this.setValue(value);
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getValue() {
        return value;
    }

    public void setValue(String value) {
        this.value = value;
    }

    public String getCookieValue(){
        String cookieValue = String.format("%s=%s;", this.getName(), this.getValue());
        return cookieValue;
    }
}
