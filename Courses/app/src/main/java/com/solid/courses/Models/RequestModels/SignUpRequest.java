package com.solid.courses.Models.RequestModels;

import com.google.gson.annotations.SerializedName;

/**
 * Created by Le Trinh The Hai on 19/10/2017.
 */

public class SignUpRequest {

    @SerializedName("countryId")
    private int countryId;

    @SerializedName("cityId")
    private int cityId;

    @SerializedName("phoneNumber")
    private String phoneNumber;

    @SerializedName("sex")
    private String sex;

    @SerializedName("password")
    private String password;

    @SerializedName("email")
    private String email;

    public int getCountryId() {
        return countryId;
    }

    public void setCountryId(int countryId) {
        this.countryId = countryId;
    }

    public int getCityId() {
        return cityId;
    }

    public void setCityId(int cityId) {
        this.cityId = cityId;
    }

    public String getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(String phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    public String getSex() {
        return sex;
    }

    public void setSex(String sex) {
        this.sex = sex;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }
}
