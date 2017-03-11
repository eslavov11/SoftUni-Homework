package com.forum.service;

import com.forum.models.bindingModels.ReplyBindingModel;

public interface ReplyService {

    void create(ReplyBindingModel replyBindingModel, long topicId);
}
