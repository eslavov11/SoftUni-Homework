package com.issueTracker.controller;

import com.mvcFramework.annotations.controller.Controller;
import com.mvcFramework.annotations.request.GetMapping;

import javax.ejb.Stateless;

/**
 * Created by Edi on 03-Mar-17.
 */
@Stateless
@Controller
public class HomeController {
    @GetMapping("/")
    public String getHomePage() {
        return "/templates/home";
    }
}
