package com.solid.courses.Models;

import com.google.gson.annotations.SerializedName;

/**
 * Created by Le Trinh The Hai on 21/10/2017.
 */

public class Reliance {
    @SerializedName("Id")
    private int Id;
    @SerializedName("Logo")
    private String Logo;

    public int getId() {
        return Id;
    }

    public void setId(int id) {
        Id = id;
    }

    public String getLogo() {
        return Logo;
    }

    public void setLogo(String logo) {
        Logo = logo;
    }
}
