package com.pizzamoreLab.models.session;

import javax.persistence.*;

/**
 * Created by Edi on 23-Feb-17.
 */
@Entity
@Table(name = "session_data")
public class SessionData {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long id;

    @Column(name = "key_data")
    private String key;

    @Column(name = "value_data")
    private String value;

    @ManyToOne
    @JoinColumn(name = "session_id")
    private Session session;

    public SessionData() {
    }

    public SessionData(String key, String value, Session session) {
        this.setKey(key);
        this.setValue(value);
        this.setSession(session);
    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public String getKey() {
        return key;
    }

    public void setKey(String key) {
        this.key = key;
    }

    public String getValue() {
        return value;
    }

    public void setValue(String value) {
        this.value = value;
    }

    public Session getSession() {
        return session;
    }

    public void setSession(Session session) {
        this.session = session;
    }
}
