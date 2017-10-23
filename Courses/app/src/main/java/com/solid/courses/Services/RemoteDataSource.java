package com.solid.courses.Services;

import android.content.Context;

import com.google.gson.Gson;
import com.google.gson.TypeAdapter;
import com.solid.courses.Models.Account;
import com.solid.courses.Models.ContactApp;
import com.solid.courses.Models.Country;
import com.solid.courses.Models.Course;
import com.solid.courses.Models.CourseDetail;
import com.solid.courses.Models.CourseType;
import com.solid.courses.Models.InstituteDetail;
import com.solid.courses.Models.Profile;
import com.solid.courses.Models.RequestModels.FavoriteRequest;
import com.solid.courses.Models.RequestModels.LoginRequest;
import com.solid.courses.Models.RequestModels.ProfileRequest;
import com.solid.courses.Models.RequestModels.SignUpRequest;
import com.solid.courses.Models.ResponseModels.DataResponse;
import com.solid.courses.Models.ReturnData;
import com.solid.courses.Models.Trainer;
import com.solid.courses.Models.TrainerDetail;

import java.io.IOException;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

/**
 * Created by Le Trinh The Hai on 17/10/2017.
 */

public class RemoteDataSource {

    private static RemoteDataSource INSTANCE;
    private ApiInterface mApiInterfaceClient;

    private Context mContext;

    public RemoteDataSource(Context context) {
        mContext = context;
        mApiInterfaceClient = ApiClient.getClient(context).create(ApiInterface.class);
    }

    private class PostData {
        PostData(Call<DataResponse> call, final CallbackInterface<String> callback) {
            call.enqueue(new Callback<DataResponse>() {
                @Override
                public void onResponse(Call<DataResponse> call, Response<DataResponse> response) {
                    if (response.body() != null) {
                        if (response.body().getError() == null) {
                            if (response.body().getData() != null) {
                                callback.onSuccess(response.body().getData().toString());
                            } else {
                                callback.onSuccess("Success");
                            }
                        }
                    } else {
                        Gson gson = new Gson();
                        TypeAdapter<DataResponse> adapter = gson.getAdapter(DataResponse.class);
                        try {
                            DataResponse registerResponse = null;
                            if (response.errorBody() != null)
                                registerResponse =
                                        adapter.fromJson(
                                                response.errorBody().string());
                            callback.onError(registerResponse.getError().getErrorMessage().get(0));

                        } catch (IOException e) {
                            e.printStackTrace();
                        }
                    }
                }

                @Override
                public void onFailure(Call<DataResponse> call, Throwable t) {
                    callback.onError("Can't retrieve data!");
                }
            });
        }
    }


    private class LoadData<D> {

        LoadData(Call<DataResponse<D>> call, final CallbackInterface<D> callback) {
            call.enqueue(new Callback<DataResponse<D>>() {
                @Override
                public void onResponse(Call<DataResponse<D>> call, Response<DataResponse<D>> response) {
                    if (response.body() != null) {
                        if (response.body().getData() != null) {
                            callback.onSuccess(response.body().getData());
                        } else {
                            callback.onError(errorMessage(response));
                        }
                    } else {
                        callback.onError(errorMessage(response));
                    }

                }

                @Override
                public void onFailure(Call<DataResponse<D>> call, Throwable t) {
                    callback.onError("Can't retrieve data!");
                }
            });

        }

        private String errorMessage(Response response) {
            Gson gson = new Gson();
            TypeAdapter<DataResponse> adapter = gson.getAdapter(DataResponse.class);
            try {
                DataResponse registerResponse = null;
                if (response.errorBody() != null)
                    registerResponse =
                            adapter.fromJson(
                                    response.errorBody().string());
                if (registerResponse != null) {
                    return registerResponse.getError().getErrorMessage().get(0);
                } else {
                    return "null data!";
                }
            } catch (IOException e) {
                e.printStackTrace();
                return "null data!";
            }
        }

    }

    public void getCountry(CallbackInterface<List<Country>> callback){
        Call<DataResponse<List<Country>>> call = mApiInterfaceClient.getCountry();
        new LoadData<>(call, callback);
    }

    public void getCity(int id, CallbackInterface<List<Country>> callback){
        Call<DataResponse<List<Country>>> call = mApiInterfaceClient.getCity(id);
        new LoadData<>(call, callback);
    }

    public void signUp(SignUpRequest request, CallbackInterface<Account> callback){
        Call<DataResponse<Account>> call = mApiInterfaceClient.signUp(request);
        new LoadData<>(call, callback);
    }

    public void login(LoginRequest request, CallbackInterface<Account> callback){
        Call<DataResponse<Account>> call = mApiInterfaceClient.login(request);
        new LoadData<>(call, callback);
    }

    public void getCourse(int page, int pageSize, CallbackInterface<List<ReturnData>> callback){
        Call<DataResponse<List<ReturnData>>> call = mApiInterfaceClient.getCourse(page, pageSize);
        new LoadData<>(call, callback);
    }

    public void getIns(int page, int pageSize, CallbackInterface<List<ReturnData>> callback){
        Call<DataResponse<List<ReturnData>>> call = mApiInterfaceClient.getIns(page, pageSize);
        new LoadData<>(call, callback);
    }

    public void getCourseFeature(int page, int pageSize, CallbackInterface<List<Course>> callback){
        Call<DataResponse<List<Course>>> call = mApiInterfaceClient.getCourseFeature(page, pageSize);
        new LoadData<>(call, callback);
    }

    public void getCourseDetail(int courseId, CallbackInterface<CourseDetail> callback){
        Call<DataResponse<CourseDetail>> call = mApiInterfaceClient.getCourseDetail(courseId);
        new LoadData<>(call, callback);
    }

    public void getTrainers(int page, int pageSize, CallbackInterface<List<Trainer>> callback){
        Call<DataResponse<List<Trainer>>> call = mApiInterfaceClient.getTrainers(page, pageSize);
        new LoadData<>(call, callback);
    }
    public void getCourseType(CallbackInterface<List<CourseType>> callback){
        Call<DataResponse<List<CourseType>>> call = mApiInterfaceClient.getCourseType();
        new LoadData<>(call, callback);
    }
    public void getFavorite(CallbackInterface<List<Course>> callback){
        Call<DataResponse<List<Course>>> call = mApiInterfaceClient.getFavorite();
        new LoadData<>(call, callback);
    }
    public void setupFavorite(FavoriteRequest request, CallbackInterface<List<Course>> callback){
        Call<DataResponse<List<Course>>> call = mApiInterfaceClient.setupfavorite(request);
        new LoadData<>(call, callback);
    }
    public void getTrainerDetail(int trainerId, CallbackInterface<TrainerDetail> callback){
        Call<DataResponse<TrainerDetail>> call = mApiInterfaceClient.getTrainerDetail(trainerId);
        new LoadData<>(call, callback);
    }

    public void getInsDetail(int instituteId, CallbackInterface<InstituteDetail> callback){
        Call<DataResponse<InstituteDetail>> call = mApiInterfaceClient.getInsDetail(instituteId);
        new LoadData<>(call, callback);
    }

    public void getProfile(CallbackInterface<Profile> callback){
        Call<DataResponse<Profile>> call = mApiInterfaceClient.getProfile();
        new LoadData<>(call, callback);
    }
    public void updateProfile(ProfileRequest request, CallbackInterface callback){
        Call<DataResponse> call = mApiInterfaceClient.updateProfile(request);
        new PostData(call, callback);
    }
    public void getContact(CallbackInterface<ContactApp> callback){
        Call<DataResponse<ContactApp>> call = mApiInterfaceClient.getContact();
        new LoadData<>(call, callback);
    }

    public void setReminder(int courseId, CallbackInterface callback){
        Call<DataResponse> call = mApiInterfaceClient.reminder(courseId);
        new PostData(call, callback);
    }

    public void searchCourse(FavoriteRequest request, CallbackInterface<List<Course>> callback){
        Call<DataResponse<List<Course>>> call = mApiInterfaceClient.searchCourse(request);
        new LoadData<>(call, callback);
    }
}
