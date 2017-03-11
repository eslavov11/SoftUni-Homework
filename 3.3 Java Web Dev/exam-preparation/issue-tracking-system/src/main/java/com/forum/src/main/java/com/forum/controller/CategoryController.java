package com.forum.controller;

import com.forum.models.bindingModels.CategoryBindingModel;
import com.forum.models.viewModels.CategoryViewModel;
import com.forum.service.CategoryService;
import com.mvcFramework.annotations.controller.Controller;
import com.mvcFramework.annotations.parameters.ModelAttribute;
import com.mvcFramework.annotations.parameters.PathVariable;
import com.mvcFramework.annotations.request.GetMapping;
import com.mvcFramework.annotations.request.PostMapping;
import com.mvcFramework.models.Model;

import javax.ejb.Stateless;
import javax.inject.Inject;
import java.util.List;

@Stateless
@Controller
public class CategoryController {

    @Inject
    private CategoryService categoryService;

    @GetMapping("/categories")
    public String getCategoryPage(Model model) {
        List<CategoryViewModel> categories = this.categoryService.findAll();
        model.addAttribute("categories", categories);
        return "/templates/categories";
    }

    @GetMapping("/admin/categories")
    public String getAdminCategoryPage(Model model) {
        List<CategoryViewModel> categories = this.categoryService.findAll();
        model.addAttribute("categories", categories);
        return "/templates/admin-categories";
    }

    @GetMapping("/admin/categories/add")
    public String getAddCategoryPage() {

        return "/templates/admin-categories-add";
    }

    @PostMapping("/admin/categories/add")
    public String getAddCategory(@ModelAttribute CategoryBindingModel categoryBindingModel) {
        this.categoryService.save(categoryBindingModel);
        return "/templates/admin-categories-add";
    }

    @GetMapping("/admin/categories/edit/{id}")
    public String getEditCategoryPage(@PathVariable("id") long id, Model model) {
        CategoryViewModel categoryViewModel = this.categoryService.findByName(id);
        model.addAttribute("categoryViewModel", categoryViewModel);
        return "/templates/admin-categories-edit";
    }

    @PostMapping("/admin/categories/edit/{id}")
    public String editCategory(@PathVariable("id") long id, @ModelAttribute CategoryBindingModel categoryBindingModel) {
        categoryBindingModel.setId(id);
        this.categoryService.update(categoryBindingModel);
        return "redirect:/admin/categories";
    }

    @GetMapping("/admin/categories/delete/{id}")
    public String deleteCategory(@PathVariable("id") long id) {
        this.categoryService.deleteById(id);
        return "redirect:/admin/categories";
    }
}
