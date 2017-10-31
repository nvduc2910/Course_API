package com.solid.courses.Services;

import android.content.Context;
import android.text.TextUtils;

import com.solid.courses.Helper.PreferenceHelper;
import com.solid.courses.Util.DataConstants;

import java.io.IOException;
import java.util.concurrent.TimeUnit;

import okhttp3.Interceptor;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

/**
 * Created by Le Trinh The Hai on 17/10/2017.
 */

public class ApiClient {
    private static Retrofit INSTANCE = null;

    public static Retrofit getClient(Context context) {
        if (INSTANCE == null) {
            INSTANCE = new Retrofit.Builder().baseUrl(DataConstants.BASE_URL)
                    .addConverterFactory(GsonConverterFactory.create())
                    .client(getRequestHeader(context))
                    .build();
        }
        return INSTANCE;
    }

    private static OkHttpClient getRequestHeader(Context context) {
        final String token = "Bearer " + PreferenceHelper.getInstance(context).getToken();
        OkHttpClient client = new OkHttpClient.Builder()
                .connectTimeout(30, TimeUnit.SECONDS)
                .writeTimeout(30, TimeUnit.SECONDS)
                .readTimeout(30, TimeUnit.SECONDS)
                .addInterceptor(new Interceptor() {
                    @Override
                    public Response intercept(Chain chain) throws IOException {
                        Request request = chain.request();
                        if (TextUtils.isEmpty(token)) {
                            return chain.proceed(request);
                        } else {
                            request = chain.request().newBuilder().addHeader("Authorization",token).build();
                            return chain.proceed(request);
                        }
                    }
                })
                .build();

        return client;
    }

}
