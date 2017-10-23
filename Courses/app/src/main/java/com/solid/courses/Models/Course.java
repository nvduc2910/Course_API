package com.solid.courses.Models;

import com.google.gson.annotations.SerializedName;

import java.io.Serializable;

/**
 * Created by Le Trinh The Hai on 21/10/2017.
 */

public class Course implements Serializable{
    @SerializedName("Id")
    private int Id;

    @SerializedName("Name")
    private String Name;

    @SerializedName("Gender")
    private int Gender;

    @SerializedName("InstituteName")
    private String InstituteName;

    @SerializedName("InstituteId")
    private int InstituteId;

    @SerializedName("StartDate")
    private String StartDate;

    @SerializedName("MainPrice")
    private int MainPrice;

    @SerializedName("MotivationPrice")
    private int MotivationPrice;

    @SerializedName("Currency")
    private String Currency;

    @SerializedName("Country")
    private String Country;

    @SerializedName("City")
    private String City;

    @SerializedName("Image")
    private String Image;

    @SerializedName("TotalDay")
    private int TotalDay;

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

    public int getGender() {
        return Gender;
    }

    public void setGender(int gender) {
        Gender = gender;
    }

    public String getInstituteName() {
        return InstituteName;
    }

    public void setInstituteName(String instituteName) {
        InstituteName = instituteName;
    }

    public int getInstituteId() {
        return InstituteId;
    }

    public void setInstituteId(int instituteId) {
        InstituteId = instituteId;
    }

    public String getStartDate() {
        return StartDate;
    }

    public void setStartDate(String startDate) {
        StartDate = startDate;
    }

    public int getMainPrice() {
        return MainPrice;
    }

    public void setMainPrice(int mainPrice) {
        MainPrice = mainPrice;
    }

    public int getMotivationPrice() {
        return MotivationPrice;
    }

    public void setMotivationPrice(int motivationPrice) {
        MotivationPrice = motivationPrice;
    }

    public String getCurrency() {
        return Currency;
    }

    public void setCurrency(String currency) {
        Currency = currency;
    }

    public String getImage() {
        return Image;
    }

    public void setImage(String image) {
        Image = image;
    }

    public int getTotalDay() {
        return TotalDay;
    }

    public void setTotalDay(int totalDay) {
        TotalDay = totalDay;
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
}
