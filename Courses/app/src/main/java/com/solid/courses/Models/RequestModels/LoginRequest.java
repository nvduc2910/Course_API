package com.solid.courses.Models.RequestModels;

import com.google.gson.annotations.SerializedName;

/**
 * Created by Le Trinh The Hai on 19/10/2017.
 */

public class LoginRequest {

    @SerializedName("phoneNumber")
    private String phoneNumber;
    @SerializedName("password")
    private String password;

    public LoginRequest(String phoneNumber, String password) {
        this.phoneNumber = phoneNumber;
        this.password = password;
    }
}
