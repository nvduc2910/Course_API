package com.solid.courses.Models.RequestModels;

import com.google.gson.annotations.SerializedName;

/**
 * Created by Le Trinh The Hai on 19/10/2017.
 */

public class FavoriteRequest {

    @SerializedName("cityId")
    private int cityId;
    @SerializedName("instituteId")
    private int instituteId;
    @SerializedName("courseTypeId")
    private int courseTypeId;
    @SerializedName("countryId")
    private int countryId;
    @SerializedName("selectTime")
    private String selectTime;

    public int getCityId() {
        return cityId;
    }

    public void setCityId(int cityId) {
        this.cityId = cityId;
    }

    public int getInstituteId() {
        return instituteId;
    }

    public void setInstituteId(int instituteId) {
        this.instituteId = instituteId;
    }

    public int getCourseTypeId() {
        return courseTypeId;
    }

    public void setCourseTypeId(int courseTypeId) {
        this.courseTypeId = courseTypeId;
    }

    public int getCountryId() {
        return countryId;
    }

    public void setCountryId(int countryId) {
        this.countryId = countryId;
    }

    public String getSelectTime() {
        return selectTime;
    }

    public void setSelectTime(String selectTime) {
        this.selectTime = selectTime;
    }
}
