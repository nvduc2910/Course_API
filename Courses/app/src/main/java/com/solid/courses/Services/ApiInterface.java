package com.solid.courses.Services;

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

import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.Query;

/**
 * Created by Le Trinh The Hai on 17/10/2017.
 */

public interface ApiInterface {


//    ACCOUNT

    @GET("Account/GetCountry")
    Call<DataResponse<List<Country>>> getCountry();

    @GET("Account/GetCityByCountry")
    Call<DataResponse<List<Country>>> getCity(@Query("countryId") int countryId);

    @POST("Account/Register")
    Call<DataResponse<Account>> signUp(@Body SignUpRequest signUpRequest);

    @POST("Account/Login")
    Call<DataResponse<Account>> login(@Body LoginRequest loginRequest);

    @GET("Account/GetProfile")
    Call<DataResponse<Profile>> getProfile();

    @POST("Account/UpdateProfile")
    Call<DataResponse> updateProfile(@Body ProfileRequest request);

//    COURSES

    @GET("Course/GetCourse")
    Call<DataResponse<List<ReturnData>>> getCourse(@Query("page") int page, @Query("pageSize") int pageSize);

    @GET("Course/GetFeaturedCourse")
    Call<DataResponse<List<Course>>> getCourseFeature(@Query("page") int page, @Query("pageSize") int pageSize);

    @GET("Course/GetCourseDetails")
    Call<DataResponse<CourseDetail>> getCourseDetail(@Query("courseId") int courseId);

    @GET("Course/GetCourseType")
    Call<DataResponse<List<CourseType>>> getCourseType();

    @POST("Course/Reminder")
    Call<DataResponse> reminder(@Query("courseId") int courseId);
    @POST("Course/SearchCourse")
    Call<DataResponse<List<Course>>> searchCourse(@Body FavoriteRequest request);

//    INSTITUTE
    @GET("Institute/GetInstitute")
    Call<DataResponse<List<ReturnData>>> getIns(@Query("page") int page, @Query("pageSize") int pageSize);

    @GET("Institute/InstituteDetails")
    Call<DataResponse<InstituteDetail>> getInsDetail(@Query("instituteId") int instituteId);

//    TRAINER
    @GET("Trainer/GetTrainers")
    Call<DataResponse<List<Trainer>>> getTrainers(@Query("page") int page, @Query("pageSize") int pageSize);

    @GET("Trainer/TrainersDetails")
    Call<DataResponse<TrainerDetail>> getTrainerDetail(@Query("trainerId") int trainerId);

//    FAVORITE
    @GET("Course/GetFavorite")
    Call<DataResponse<List<Course>>> getFavorite();
    @POST("Course/SetupFavorite")
    Call<DataResponse<List<Course>>> setupfavorite(@Body FavoriteRequest request);

//    CONTACT

    @GET("Contact/GetContactUse")
    Call<DataResponse<ContactApp>> getContact();
}
