package com.solid.courses.Models;

import com.google.gson.annotations.SerializedName;

/**
 * Created by Le Trinh The Hai on 21/10/2017.
 */

public class ContactApp {
    @SerializedName("ApplicationName")
    private String ApplicationName;
    @SerializedName("CompanyName")
    private String CompanyName;
    @SerializedName("About")
    private String About;
    @SerializedName("ContactNumber")
    private String ContactNumber;
    @SerializedName("Email")
    private String Email;
    @SerializedName("Website")
    private String Website;
    @SerializedName("Twitter")
    private String Twitter;
    @SerializedName("Instagram")
    private String Instagram;
    @SerializedName("GooglePlus")
    private String GooglePlus;
    @SerializedName("Facebook")
    private String Facebook;

    public String getApplicationName() {
        return ApplicationName;
    }

    public void setApplicationName(String applicationName) {
        ApplicationName = applicationName;
    }

    public String getCompanyName() {
        return CompanyName;
    }

    public void setCompanyName(String companyName) {
        CompanyName = companyName;
    }

    public String getAbout() {
        return About;
    }

    public void setAbout(String about) {
        About = about;
    }

    public String getContactNumber() {
        return ContactNumber;
    }

    public void setContactNumber(String contactNumber) {
        ContactNumber = contactNumber;
    }

    public String getEmail() {
        return Email;
    }

    public void setEmail(String email) {
        Email = email;
    }

    public String getWebsite() {
        return Website;
    }

    public void setWebsite(String website) {
        Website = website;
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

    public String getGooglePlus() {
        return GooglePlus;
    }

    public void setGooglePlus(String googlePlus) {
        GooglePlus = googlePlus;
    }

    public String getFacebook() {
        return Facebook;
    }

    public void setFacebook(String facebook) {
        Facebook = facebook;
    }
}
