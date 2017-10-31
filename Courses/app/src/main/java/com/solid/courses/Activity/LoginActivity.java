package com.solid.courses.Activity;

import android.content.Intent;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

import com.mobsandgeeks.saripaar.ValidationError;
import com.mobsandgeeks.saripaar.Validator;
import com.mobsandgeeks.saripaar.annotation.NotEmpty;
import com.solid.courses.Helper.PreferenceHelper;
import com.solid.courses.Models.Account;
import com.solid.courses.Models.RequestModels.LoginRequest;
import com.solid.courses.R;
import com.solid.courses.Services.CallbackInterface;
import com.solid.courses.Services.RemoteDataSource;

import org.androidannotations.annotations.Click;
import org.androidannotations.annotations.EActivity;
import org.androidannotations.annotations.ViewById;

import java.util.List;

/**
 * Created by Le Trinh The Hai on 17/10/2017.
 */

@EActivity(R.layout.activity_login)
public class LoginActivity extends BaseActivity implements Validator.ValidationListener {

    @NotEmpty
    @ViewById(R.id.etUserName)
    EditText etUserName;

    @NotEmpty
    @ViewById(R.id.etPassword)
    EditText etPassword;

    Validator validator;

    RemoteDataSource remoteDataSource;

    @Override
    public void init() {

        if(PreferenceHelper.getInstance(this).getToken() != null &&
                !PreferenceHelper.getInstance(this).getToken().equals("")){
            Intent intent = new Intent(this, MainActivity_.class);
            startActivity(intent);
            finish();
        }

        validator = new Validator(this);
        validator.setValidationListener(this);

        remoteDataSource = new RemoteDataSource(this);

        setupUI(findViewById(android.R.id.content), this);
    }

    @Click(R.id.tvSignUp)
    void clickSignUp(){
        Intent intent = new Intent(this, SignUpActivity_.class);
        startActivity(intent);
    }

    @Override
    public void onValidationSucceeded() {
        login();
    }

    @Override
    public void onValidationFailed(List<ValidationError> errors) {
        for (ValidationError error : errors) {
            View view = error.getView();
            String message = error.getCollatedErrorMessage(this);

            // Display error messages ;)
            if (view instanceof EditText) {
                ((EditText) view).setError(message);
            } else {
                Toast.makeText(this, message, Toast.LENGTH_LONG).show();
            }
        }
    }

    @Click(R.id.tvLogin)
    void clickLogin(){
        validator.validate();
    }
    private void login(){
        showProgressDialog(this);
        LoginRequest request = new LoginRequest(etUserName.getText().toString(), etPassword.getText().toString());
        remoteDataSource.login(request, new CallbackInterface<Account>() {
            @Override
            public void onSuccess(Account account) {
                PreferenceHelper preferenceHelper = PreferenceHelper.getInstance(LoginActivity.this);
                preferenceHelper.setToken(account.getAccess_token());
                preferenceHelper.setUserId(account.getUser_id());

                hideProgressDialog();
                Intent intent = new Intent(LoginActivity.this, MainActivity_.class);
                startActivity(intent);


            }

            @Override
            public void onError(String message) {
                Toast.makeText(LoginActivity.this, message, Toast.LENGTH_SHORT).show();
                hideProgressDialog();
            }
        });
    }
}
