package com.solid.courses.Models;

import com.google.gson.annotations.SerializedName;

/**
 * Created by Le Trinh The Hai on 21/10/2017.
 */

public class CourseType {
    @SerializedName("Id")
    private int Id;
    @SerializedName("Type")
    private String Type;

    public int getId() {
        return Id;
    }

    public void setId(int id) {
        Id = id;
    }

    public String getType() {
        return Type;
    }

    public void setType(String type) {
        Type = type;
    }
}
