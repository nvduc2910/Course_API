package com.solid.courses.Models;

import com.google.gson.annotations.SerializedName;

import java.util.List;

/**
 * Created by Le Trinh The Hai on 21/10/2017.
 */

public class TrainerDetail {
    @SerializedName("Id")
    private int Id;

    @SerializedName("Name")
    private String Name;

    @SerializedName("Avatar")
    private String Avatar;

    @SerializedName("Country")
    private String Country;

    @SerializedName("City")
    private String City;

    @SerializedName("Gender")
    private int Gender;

    @SerializedName("About")
    private String About;

    @SerializedName("Contact")
    private Contact Contact;

    @SerializedName("OldCourses")
    private List<ReturnData> OldCourses;

    @SerializedName("NewCourses")
    private List<ReturnData> NewCourses;

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

    public String getAvatar() {
        return Avatar;
    }

    public void setAvatar(String avatar) {
        Avatar = avatar;
    }

    public String getCountry() {
        return Country;
    }

    public void setCountry(String country) {
        Country = country;
    }

    public String getCity() {
        return City;
    }

    public void setCity(String city) {
        City = city;
    }

    public int getGender() {
        return Gender;
    }

    public void setGender(int gender) {
        Gender = gender;
    }

    public String getAbout() {
        return About;
    }

    public void setAbout(String about) {
        About = about;
    }

    public com.solid.courses.Models.Contact getContact() {
        return Contact;
    }

    public void setContact(com.solid.courses.Models.Contact contact) {
        Contact = contact;
    }

    public List<ReturnData> getOldCourses() {
        return OldCourses;
    }

    public void setOldCourses(List<ReturnData> oldCourses) {
        OldCourses = oldCourses;
    }

    public List<ReturnData> getNewCourses() {
        return NewCourses;
    }

    public void setNewCourses(List<ReturnData> newCourses) {
        NewCourses = newCourses;
    }
}
