package com.forum.serviceImpl;

import com.forum.entities.Category;
import com.forum.entities.Topic;
import com.forum.entities.User;
import com.forum.models.bindingModels.AddTopicModel;
import com.forum.models.viewModels.TopicReplyViewModel;
import com.forum.models.viewModels.TopicViewModel;
import com.forum.repositories.CategoryRepository;
import com.forum.repositories.TopicRepository;
import com.forum.repositories.UserRepository;
import com.forum.service.TopicService;
import com.forum.utils.parser.interfaces.ModelParser;

import javax.ejb.Stateless;
import javax.inject.Inject;
import javax.transaction.Transactional;
import java.util.*;

@Stateless
public class TopicServiceImpl implements TopicService {

    @Inject
    private TopicRepository topicRepository;

    @Inject
    private UserRepository userRepository;

    @Inject
    private CategoryRepository categoryRepository;

    @Inject
    private ModelParser modelParser;

    @Override
    public void create(AddTopicModel addTopicModel) {
        Topic topic = this.modelParser.convert(addTopicModel, Topic.class);
        User user = this.userRepository.findByUsername(addTopicModel.getAuthorUsername());
        Category category = this.categoryRepository.findByName(addTopicModel.getCategoryName());
        topic.setAuthor(user);
        topic.setCategory(category);
        topic.setPublishDate(new Date());
        this.topicRepository.create(topic);
    }

    @Override
    public Set<TopicViewModel> findTop10Topics() {
        Set<TopicViewModel> topicViewModels = new HashSet<>();
        Set<Topic> topics = this.topicRepository.findTop10Topics();
        for (Topic topic : topics) {
            TopicViewModel topicViewModel = this.modelParser.convert(topic, TopicViewModel.class);
            topicViewModel.setCount(topic.getReplies().size());
            topicViewModels.add(topicViewModel);
        }

        return topicViewModels;
    }

    @Transactional
    @Override
    public TopicReplyViewModel findTopicByTopicId(long id) {
        Topic topic = this.topicRepository.findTopicByTopicId(id);
        TopicReplyViewModel topicReplyViewModel = this.modelParser.convert(topic, TopicReplyViewModel.class);

        return topicReplyViewModel;
    }

    @Override
    public void deleteById(long id) {
        this.topicRepository.deleteById(id);
    }
}
