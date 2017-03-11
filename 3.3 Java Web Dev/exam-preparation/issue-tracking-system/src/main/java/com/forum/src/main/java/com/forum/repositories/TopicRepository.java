package com.forum.repositories;

import com.forum.entities.Topic;
import com.forum.models.viewModels.TopicReplyViewModel;

import java.util.List;
import java.util.Set;

public interface TopicRepository {

    void create(Topic topic);

    Set<Topic> findTop10Topics();

    Topic findTopicByTopicId(long id);

    void deleteById(long id);
}
