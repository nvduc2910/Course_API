package com.solid.courses.Helper;

import android.content.Context;
import android.content.SharedPreferences;

/**
 * Created by Le Trinh The Hai on 17/10/2017.
 */

public class PreferenceHelper {

    private static final String NAME = "COURSES";
    private static final String TOKEN = "token";
    private static final String USER_ID = "userId";
    private static final String USER_NAME = "username";
    private static final String USER_AVATAR = "avatar";

    private static PreferenceHelper mInstance;

    private SharedPreferences mSharePreferences;

    private PreferenceHelper(Context context) {
        mSharePreferences = context.getApplicationContext().getSharedPreferences(NAME, Context.MODE_PRIVATE);
    }

    public synchronized static PreferenceHelper getInstance(Context context) {
        if (mInstance == null) {
            mInstance = new PreferenceHelper(context);
        }
        return mInstance;
    }

    public void setToken(String token) {
        SharedPreferences.Editor editor = mSharePreferences.edit();
        editor.putString(TOKEN, token);
        editor.apply();
    }

    public String getToken() {
        return mSharePreferences.getString(TOKEN, "");
    }

    public void setUserId(int userId) {
        SharedPreferences.Editor editor = mSharePreferences.edit();
        editor.putInt(USER_ID, userId);
        editor.apply();
    }

    public int getUserId() {
        return mSharePreferences.getInt(USER_ID, 0);
    }

    public void setUserName(String userName) {
        SharedPreferences.Editor editor = mSharePreferences.edit();
        editor.putString(USER_NAME, userName);
        editor.apply();
    }

    public String getUserName() {
        return mSharePreferences.getString(USER_NAME, "User");
    }

    public void setUserAvatar(String avatar) {
        SharedPreferences.Editor editor = mSharePreferences.edit();
        editor.putString(USER_AVATAR, avatar);
        editor.apply();
    }

    public String getAvatar() {
        return mSharePreferences.getString(USER_AVATAR, "null");
    }
}
