package com.solid.courses.Models.RequestModels;

import com.google.gson.annotations.SerializedName;

/**
 * Created by Le Trinh The Hai on 19/10/2017.
 */

public class ProfileRequest {

    @SerializedName("phoneNumber")
    private String phoneNumber;

    @SerializedName("countryId")
    private int countryId;

    @SerializedName("cityId")
    private int cityId;

    @SerializedName("email")
    private String email;

    @SerializedName("name")
    private String name;

    public ProfileRequest(String phoneNumber, int countryId, int cityId, String email, String name) {
        this.phoneNumber = phoneNumber;
        this.countryId = countryId;
        this.cityId = cityId;
        this.email = email;
        this.name = name;
    }
}
