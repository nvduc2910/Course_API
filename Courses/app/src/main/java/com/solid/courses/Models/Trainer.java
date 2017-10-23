package com.solid.courses.Models;

import com.google.gson.annotations.SerializedName;

/**
 * Created by Le Trinh The Hai on 21/10/2017.
 */

public class Trainer {
    @SerializedName("Id")
    private int Id;
    @SerializedName("Avatar")
    private String Avatar;
    @SerializedName("Name")
    private String Name;
    @SerializedName("Major")
    private String Major;

    @SerializedName("InstitueName")
    private String InstitueName;

    @SerializedName("TotalActive")
    private int TotalActive;

    public int getId() {
        return Id;
    }

    public void setId(int id) {
        Id = id;
    }

    public String getAvatar() {
        return Avatar;
    }

    public void setAvatar(String avatar) {
        Avatar = avatar;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }

    public String getInstitueName() {
        return InstitueName;
    }

    public void setInstitueName(String institueName) {
        InstitueName = institueName;
    }

    public int getTotalActive() {
        return TotalActive;
    }

    public void setTotalActive(int totalActive) {
        TotalActive = totalActive;
    }

    public String getMajor() {
        return Major;
    }

    public void setMajor(String major) {
        Major = major;
    }
}
