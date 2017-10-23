package com.solid.courses.Fragment;

import android.content.Intent;
import android.view.View;
import android.widget.AdapterView;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.Toast;

import com.joanzapata.android.BaseAdapterHelper;
import com.joanzapata.android.QuickAdapter;
import com.mobsandgeeks.saripaar.ValidationError;
import com.mobsandgeeks.saripaar.Validator;
import com.mobsandgeeks.saripaar.annotation.NotEmpty;
import com.nostra13.universalimageloader.core.ImageLoader;
import com.solid.courses.Activity.MainActivity_;
import com.solid.courses.Activity.SignUpActivity;
import com.solid.courses.Adapter.CountryAdapter;
import com.solid.courses.Models.Country;
import com.solid.courses.Models.Profile;
import com.solid.courses.Models.RequestModels.ProfileRequest;
import com.solid.courses.Models.Trainer;
import com.solid.courses.R;
import com.solid.courses.Services.CallbackInterface;
import com.solid.courses.Services.RemoteDataSource;

import org.androidannotations.annotations.Click;
import org.androidannotations.annotations.EFragment;
import org.androidannotations.annotations.ViewById;

import java.util.List;

/**
 * Created by Le Trinh The Hai on 21/10/2017.
 */

@EFragment(R.layout.fragment_profile)
public class ProfileFragment extends BaseFragment implements Validator.ValidationListener {

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
    @ViewById(R.id.etName)
            EditText etName;

    RemoteDataSource remoteDataSource;

    List<Country> countries;
    List<Country> cities;

    Validator validator;

    Profile profileData;


    @Override
    public void init() {

        setupUI(getView(), getActivity());

        validator = new Validator(this);

        validator.setValidationListener(this);

        remoteDataSource = new RemoteDataSource(getActivity());

        getCountry();
        getProfile();

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
        showProgressDialog(getActivity());
        remoteDataSource.getCountry(new CallbackInterface<List<Country>>() {
            @Override
            public void onSuccess(List<Country> countries) {
                CountryAdapter countryAdapter =
                        new CountryAdapter(getActivity(),android.R.layout.simple_spinner_item, countries);

                spCountry.setAdapter(countryAdapter);

                hideProgressDialog();
            }

            @Override
            public void onError(String message) {
                hideProgressDialog();
            }
        });
    }
    private void getCity(int id){
        showProgressDialog(getActivity());
        remoteDataSource.getCity(id, new CallbackInterface<List<Country>>() {
            @Override
            public void onSuccess(List<Country> countries) {
                CountryAdapter countryAdapter =
                        new CountryAdapter(getActivity(),android.R.layout.simple_spinner_item, countries);

                spCity.setAdapter(countryAdapter);
                hideProgressDialog();
            }

            @Override
            public void onError(String message) {
                hideProgressDialog();
            }
        });
    }
    private void getProfile(){
        remoteDataSource.getProfile(new CallbackInterface<Profile>() {
            @Override
            public void onSuccess(Profile profile) {
                etPhone.setText(profile.getPhoneNumber());
                etName.setText(profile.getName());
                etEmail.setText(profile.getEmail());

                profileData = profile;

            }

            @Override
            public void onError(String message) {

            }
        });
    }

    private void updateProfile(){
        showProgressDialog(getActivity());
        ProfileRequest request =
                new ProfileRequest(etPhone.getText().toString(),
                        ((Country)spCountry.getSelectedItem()).getId(),
                        ((Country)spCity.getSelectedItem()).getId(),
                        etEmail.getText().toString(),
                        etName.getText().toString());
        remoteDataSource.updateProfile(request, new CallbackInterface() {
            @Override
            public void onSuccess(Object o) {
                Toast.makeText(getActivity(), "Success", Toast.LENGTH_SHORT).show();
                hideProgressDialog();
            }

            @Override
            public void onError(String message) {
                Toast.makeText(getActivity(), message, Toast.LENGTH_SHORT).show();
                hideProgressDialog();
            }
        });
    }

    @Override
    public void onValidationSucceeded() {
        updateProfile();
    }

    @Override
    public void onValidationFailed(List<ValidationError> errors) {
        for (ValidationError error : errors) {
            View view = error.getView();
            String message = error.getCollatedErrorMessage(getActivity());

            // Display error messages ;)
            if (view instanceof EditText) {
                ((EditText) view).setError(message);
            } else {
                Toast.makeText(getActivity(), message, Toast.LENGTH_LONG).show();
            }
        }
    }
    @Click(R.id.tvSave)
    void clickSave(){
        validator.validate();
    }
}
