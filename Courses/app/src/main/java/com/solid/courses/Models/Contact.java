package com.solid.courses.Models;

import com.google.gson.annotations.SerializedName;

/**
 * Created by Le Trinh The Hai on 21/10/2017.
 */

public class Contact {
    @SerializedName("ContactNumber")
    private String ContactNumber;
    @SerializedName("Facebook")
    private String Facebook;
    @SerializedName("Twitter")
    private String Twitter;
    @SerializedName("Instagram")
    private String Instagram;
    @SerializedName("Email")
    private String Email;

    public String getContactNumber() {
        return ContactNumber;
    }

    public void setContactNumber(String contactNumber) {
        ContactNumber = contactNumber;
    }

    public String getFacebook() {
        return Facebook;
    }

    public void setFacebook(String facebook) {
        Facebook = facebook;
    }

    public String getTwitter() {
        return Twitter;
    }

    public void setTwitter(String twitter) {
        Twitter = twitter;
    }

    public String getInstagram() {
        return Instagram;
    }

    public void setInstagram(String instagram) {
        Instagram = instagram;
    }

    public String getEmail() {
        return Email;
    }

    public void setEmail(String email) {
        Email = email;
    }
}
