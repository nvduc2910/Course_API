package com.solid.courses.Activity;

import android.content.Intent;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import com.mobsandgeeks.saripaar.ValidationError;
import com.mobsandgeeks.saripaar.Validator;
import com.mobsandgeeks.saripaar.annotation.NotEmpty;
import com.solid.courses.Adapter.CountryAdapter;
import com.solid.courses.Helper.PreferenceHelper;
import com.solid.courses.Models.Account;
import com.solid.courses.Models.Country;
import com.solid.courses.Models.RequestModels.SignUpRequest;
import com.solid.courses.R;
import com.solid.courses.Services.CallbackInterface;
import com.solid.courses.Services.RemoteDataSource;

import org.androidannotations.annotations.Click;
import org.androidannotations.annotations.EActivity;
import org.androidannotations.annotations.ViewById;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Le Trinh The Hai on 17/10/2017.
 */

@EActivity(R.layout.activity_signup)
public class SignUpActivity extends BaseActivity implements Validator.ValidationListener {


    @ViewById(R.id.spGender)
    Spinner spGender;

    @ViewById(R.id.spCity)
    Spinner spCity;

    @ViewById(R.id.spCountry)
            Spinner spCountry;

    @NotEmpty
    @ViewById(R.id.etPhone)
    EditText etPhone;
    @NotEmpty
    @ViewById(R.id.etEmail)
    EditText etEmail;

    @NotEmpty
    @ViewById(R.id.etPassword)
            EditText etPassword;

    List<String> genders = new ArrayList<>();

    RemoteDataSource remoteDataSource;

    List<Country> countries;
    List<Country> cities;

    Validator validator;

    @Override
    public void init() {
        setupUI(findViewById(android.R.id.content), this);

        remoteDataSource = new RemoteDataSource(this);
        validator = new Validator(this);

        validator.setValidationListener(this);

        genders.add("Male");
        genders.add("Female");

        ArrayAdapter<String> genderAdapter = new ArrayAdapter<String>(this,android.R.layout.simple_spinner_item, genders);

        spGender.setAdapter(genderAdapter);

        getCountry();

        spCountry.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
                Country country = (Country) spCountry.getSelectedItem();
                getCity(country.getId());
            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });
    }
    private void getCountry(){
        showProgressDialog(this);
        remoteDataSource.getCountry(new CallbackInterface<List<Country>>() {
            @Override
            public void onSuccess(List<Country> countries) {
                CountryAdapter countryAdapter =
                        new CountryAdapter(SignUpActivity.this,android.R.layout.simple_spinner_item, countries);

                spCountry.setAdapter(countryAdapter);
            }

            @Override
            public void onError(String message) {
                hideProgressDialog();
            }
        });
    }

    private void getCity(int id){
        remoteDataSource.getCity(id, new CallbackInterface<List<Country>>() {
            @Override
            public void onSuccess(List<Country> countries) {
                CountryAdapter countryAdapter =
                        new CountryAdapter(SignUpActivity.this,android.R.layout.simple_spinner_item, countries);

                spCity.setAdapter(countryAdapter);
                hideProgressDialog();
            }

            @Override
            public void onError(String message) {
                hideProgressDialog();
            }
        });
    }

    @Click(R.id.tvSignUp)
    void clickSignUp(){
        validator.validate();
    }


    @Override
    public void onValidationSucceeded() {
        signUp();
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

    private void signUp(){
        showProgressDialog(this);
        SignUpRequest request = new SignUpRequest();
        request.setPhoneNumber(etPhone.getText().toString());
        request.setPassword(etPassword.getText().toString());
        request.setCountryId(((Country)spCountry.getSelectedItem()).getId());
        request.setCityId(((Country)spCity.getSelectedItem()).getId());
        request.setSex((String) spGender.getSelectedItem());
        request.setEmail(etEmail.getText().toString());
        remoteDataSource.signUp(request, new CallbackInterface<Account>() {
            @Override
            public void onSuccess(Account account) {
                PreferenceHelper preferenceHelper = PreferenceHelper.getInstance(SignUpActivity.this);
                preferenceHelper.setToken(account.getAccess_token());
                preferenceHelper.setUserId(account.getUser_id());

                hideProgressDialog();
                Intent intent = new Intent(SignUpActivity.this, MainActivity_.class);
                startActivity(intent);
                finish();


            }

            @Override
            public void onError(String message) {
                Toast.makeText(SignUpActivity.this, message, Toast.LENGTH_SHORT).show();
                hideProgressDialog();
            }
        });
    }
}
