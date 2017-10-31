package com.solid.courses.Models.ResponseModels;

import com.google.gson.annotations.SerializedName;

import java.util.List;

/**
 * Created by Le Trinh The Hai on 17/10/2017.
 */

public class ErrorMessage {
    @SerializedName("errorMessage")
    private List<String> errorMessage = null;
    @SerializedName("errorCode")
    private Integer errorCode;

    public List<String> getErrorMessage() {
        return errorMessage;
    }

    public void setErrorMessage(List<String> errorMessage) {
        this.errorMessage = errorMessage;
    }

    public Integer getErrorCode() {
        return errorCode;
    }

    public void setErrorCode(Integer errorCode) {
        this.errorCode = errorCode;
    }
}
