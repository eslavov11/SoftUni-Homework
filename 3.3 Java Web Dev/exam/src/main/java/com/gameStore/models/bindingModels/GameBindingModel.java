package com.gameStore.models.bindingModels;

import javax.validation.constraints.Pattern;
import javax.validation.constraints.Size;

public class GameBindingModel {
    @Pattern(regexp = "^[A-Z].{2,99}$", message = "The title must begin with capital letter and must contain [3, 100] characters.")
    private String title;

    @Pattern(regexp = "^[0-9]+(\\.[0-9][0-9]?)?$", message = "The price must be positive and no more than 2 digits after the decimal place.")
    private String price;

    @Pattern(regexp = "^[0-9]+(\\.[0-9]?)?$", message = "The size must be positive and no more than 1 digit after the decimal place.")
    private String size;

    @Pattern(regexp = "^.{11}$", message = "The trailer must be exactly 11 characters long.")
    private String trailer;

    @Pattern(regexp = "^((http:\\/\\/|https:\\/\\/).*)|null$", message = "Invalid thumbnail URL.")
    private String thumbnailURL;

    @Size(min = 20, message = "The description must be at least 20 characters long.")
    private String description;

    private String releaseDate;

    public GameBindingModel() {
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getPrice() {
        return price;
    }

    public void setPrice(String price) {
        this.price = price;
    }

    public String getSize() {
        return size;
    }

    public void setSize(String size) {
        this.size = size;
    }

    public String getTrailer() {
        return trailer;
    }

    public void setTrailer(String trailer) {
        this.trailer = trailer;
    }

    public String getThumbnailURL() {
        return thumbnailURL;
    }

    public void setThumbnailURL(String thumbnailURL) {
        this.thumbnailURL = thumbnailURL;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getReleaseDate() {
        return releaseDate;
    }

    public void setReleaseDate(String releaseDate) {
        this.releaseDate = releaseDate;
    }
}
