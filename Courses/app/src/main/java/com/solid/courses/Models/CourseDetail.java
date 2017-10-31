package com.solid.courses.Models;

import com.google.gson.annotations.SerializedName;

import java.util.List;

/**
 * Created by Le Trinh The Hai on 21/10/2017.
 */

public class CourseDetail {
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
    private String MainPrice;

    @SerializedName("MoviationPrice")
    private String MotivationPrice;

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

    @SerializedName("Note")
    private String Note;

    @SerializedName("Description")
    private String Description;

    @SerializedName("RegisterLink")
    private String RegisterLink;

    @SerializedName("Trainer")
    private List<Trainer> Trainer;

    @SerializedName("Contact")
    private Contact Contact;

    @SerializedName("Reliance")
    private List<Reliance> Reliance;

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

    public String getMainPrice() {
        return MainPrice;
    }

    public void setMainPrice(String mainPrice) {
        MainPrice = mainPrice;
    }

    public String getMotivationPrice() {
        return MotivationPrice;
    }

    public void setMotivationPrice(String motivationPrice) {
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

    public String getNote() {
        return Note;
    }

    public void setNote(String note) {
        Note = note;
    }

    public String getDescription() {
        return Description;
    }

    public void setDescription(String description) {
        Description = description;
    }

    public List<com.solid.courses.Models.Trainer> getTrainer() {
        return Trainer;
    }

    public void setTrainer(List<com.solid.courses.Models.Trainer> trainer) {
        Trainer = trainer;
    }

    public com.solid.courses.Models.Contact getContact() {
        return Contact;
    }

    public void setContact(com.solid.courses.Models.Contact contact) {
        Contact = contact;
    }

    public List<com.solid.courses.Models.Reliance> getReliance() {
        return Reliance;
    }

    public void setReliance(List<com.solid.courses.Models.Reliance> reliance) {
        Reliance = reliance;
    }

    public String getRegisterLink() {
        return RegisterLink;
    }

    public void setRegisterLink(String registerLink) {
        RegisterLink = registerLink;
    }
}
