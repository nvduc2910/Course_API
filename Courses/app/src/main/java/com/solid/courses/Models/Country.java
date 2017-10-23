package com.solid.courses.Models;

import com.google.gson.annotations.SerializedName;

import java.util.List;

/**
 * Created by Le Trinh The Hai on 19/10/2017.
 */

public class Country {

    @SerializedName("Id")
    private int Id;

    @SerializedName("Name")
    private String Name;

    public int getId() {
        return Id;
    }

    public void setId(int id) {
        Id = id;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }
}
