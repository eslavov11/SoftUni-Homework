package com.forum.serviceImpl;

import com.forum.entities.Reply;
import com.forum.entities.Topic;
import com.forum.entities.User;
import com.forum.models.bindingModels.ReplyBindingModel;
import com.forum.repositories.ReplyRepository;
import com.forum.repositories.TopicRepository;
import com.forum.repositories.UserRepository;
import com.forum.service.ReplyService;
import com.forum.utils.parser.interfaces.ModelParser;

import javax.ejb.Stateless;
import javax.inject.Inject;
import java.util.Date;


@Stateless
public class ReplyServiceImpl implements ReplyService {

    @Inject
    private UserRepository userRepository;

    @Inject
    private TopicRepository topicRepository;

    @Inject
    private ReplyRepository replyRepository;

    @Inject
    private ModelParser modelParser;

    @Override
    public void create(ReplyBindingModel replyBindingModel, long topicId) {
        Reply reply = this.modelParser.convert(replyBindingModel, Reply.class);
        User user = this.userRepository.findByUsername(replyBindingModel.getAuthorUsername());
        reply.setAuthor(user);
        Topic topic = this.topicRepository.findTopicByTopicId(topicId);
        reply.setTopic(topic);
        reply.setPublishDate(new Date());
        this.replyRepository.save(reply);
    }
}
