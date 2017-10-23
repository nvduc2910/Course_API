package com.solid.courses.Models.ResponseModels;

import com.google.gson.annotations.SerializedName;

/**
 * Created by Le Trinh The Hai on 17/10/2017.
 */

public class DataResponse<D> {
    @SerializedName("error")
    private ErrorMessage error;
    @SerializedName("data")
    private D data;

    public ErrorMessage getError() {
        return error;
    }

    public void setError(ErrorMessage error) {
        this.error = error;
    }

    public D getData() {
        return data;
    }

    public void setData(D data) {
        this.data = data;
    }
}
