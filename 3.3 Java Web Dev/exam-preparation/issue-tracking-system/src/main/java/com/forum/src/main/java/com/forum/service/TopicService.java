package com.forum.service;


import com.forum.models.bindingModels.AddTopicModel;
import com.forum.models.viewModels.TopicReplyViewModel;
import com.forum.models.viewModels.TopicViewModel;

import java.util.List;
import java.util.Set;

public interface TopicService {

    void create(AddTopicModel addTopicModel);

    Set<TopicViewModel> findTop10Topics();

    TopicReplyViewModel findTopicByTopicId(long id);

    void deleteById(long id);
}
