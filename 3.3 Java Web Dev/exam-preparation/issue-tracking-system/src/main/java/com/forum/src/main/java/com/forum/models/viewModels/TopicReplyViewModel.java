package com.forum.models.viewModels;

import java.util.HashSet;
import java.util.Set;

public class TopicReplyViewModel {

    private String title;

    private String content;

    private String authorUsername;

    private String publishDate;

    private Set<ReplyViewModel> replies;

    public TopicReplyViewModel() {

    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }

    public String getAuthorUsername() {
        return authorUsername;
    }

    public void setAuthorUsername(String authorUsername) {
        this.authorUsername = authorUsername;
    }

    public String getPublishDate() {
        return publishDate;
    }

    public void setPublishDate(String publishDate) {
        this.publishDate = publishDate;
    }

    public Set<ReplyViewModel> getReplies() {
        return replies;
    }

    public void setReplies(Set<ReplyViewModel> replies) {
        this.replies = replies;
    }
}
