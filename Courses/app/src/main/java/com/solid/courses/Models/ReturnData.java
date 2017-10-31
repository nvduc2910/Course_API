package com.solid.courses.Models;

import com.google.gson.annotations.SerializedName;

/**
 * Created by Le Trinh The Hai on 21/10/2017.
 */

public class ReturnData {
    @SerializedName("Id")
    private int Id;
    @SerializedName("Image")
    private String Image;

    @SerializedName("Name")
    private String Name;

    public int getId() {
        return Id;
    }

    public void setId(int id) {
        Id = id;
    }

    public String getImage() {
        return Image;
    }

    public void setImage(String image) {
        Image = image;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }
}
