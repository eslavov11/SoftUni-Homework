package com.forum.controller;

import com.forum.models.bindingModels.AddTopicModel;
import com.forum.models.bindingModels.LoginModel;
import com.forum.models.bindingModels.ReplyBindingModel;
import com.forum.models.viewModels.CategoryViewModel;
import com.forum.models.viewModels.TopicReplyViewModel;
import com.forum.models.viewModels.TopicViewModel;
import com.forum.service.CategoryService;
import com.forum.service.ReplyService;
import com.forum.service.TopicService;
import com.mvcFramework.annotations.controller.Controller;
import com.mvcFramework.annotations.parameters.ModelAttribute;
import com.mvcFramework.annotations.parameters.PathVariable;
import com.mvcFramework.annotations.parameters.RequestParam;
import com.mvcFramework.annotations.request.GetMapping;
import com.mvcFramework.annotations.request.PostMapping;
import com.mvcFramework.models.Model;

import javax.ejb.Stateless;
import javax.inject.Inject;
import javax.servlet.http.HttpSession;
import java.util.List;
import java.util.Set;

@Stateless
@Controller
public class TopicController {

    @Inject
    private TopicService topicService;

    @Inject
    private CategoryService categoryService;

    @Inject
    private ReplyService replyService;

    @GetMapping("/topics")
    public String getTopicPage(Model model){
        Set<TopicViewModel> topics = this.topicService.findTop10Topics();
        model.addAttribute("topics", topics);
        return "/templates/topic";
    }

    @GetMapping("/topics/add")
    public String getAddTopicPage(Model model){
        List<CategoryViewModel> categories = this.categoryService.findAll();
        model.addAttribute("categories", categories);
        return "/templates/add-topic";
    }

    @PostMapping("/topics/add")
    public String addTopic(@ModelAttribute AddTopicModel addTopicModel, HttpSession session){
        LoginModel loginModel = (LoginModel) session.getAttribute("user");
        String username = loginModel.getUsername();
        addTopicModel.setAuthorUsername(username);
        this.topicService.create(addTopicModel);
        return "redirect:/topics";
    }

    @GetMapping("/topics/details")
    public String getDetailsPage(@RequestParam("id") long id, Model model){
        TopicReplyViewModel topic = this.topicService.findTopicByTopicId(id);
        model.addAttribute("topic",topic);

        return "/templates/topic-details";
    }

    @PostMapping("/topics/details")
    public String reply(@ModelAttribute ReplyBindingModel replyBindingModel, @RequestParam("id") long id, Model model, HttpSession session){
        LoginModel loginModel = (LoginModel) session.getAttribute("user");
        String username = loginModel.getUsername();
        replyBindingModel.setAuthorUsername(username);
        this.replyService.create(replyBindingModel, id);

        return "redirect:/topics/details?id=" + id;
    }

    @GetMapping("/topics/delete/{id}")
    public String getDetailsPage(@PathVariable("id") long id){
        this.topicService.deleteById(id);

        return "redirect:/topics";
    }
}
