package com.forum.models.viewModels;

import java.util.Set;

public class UserTopicsViewModel {

    private String username;

    private Set<TopicViewModel> topics;

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public Set<TopicViewModel> getTopics() {
        return topics;
    }

    public void setTopics(Set<TopicViewModel> topics) {
        this.topics = topics;
    }
}
