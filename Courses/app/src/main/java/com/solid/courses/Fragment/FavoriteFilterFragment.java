package com.solid.courses.Fragment;

import android.app.DatePickerDialog;
import android.view.View;
import android.widget.AdapterView;
import android.widget.DatePicker;
import android.widget.Spinner;
import android.widget.TextView;

import com.solid.courses.Activity.FavoriteActivity;
import com.solid.courses.Adapter.CountryAdapter;
import com.solid.courses.Adapter.CourseTypeAdapter;
import com.solid.courses.Adapter.InstituteAdapter;
import com.solid.courses.Models.Country;
import com.solid.courses.Models.Course;
import com.solid.courses.Models.CourseType;
import com.solid.courses.Models.RequestModels.FavoriteRequest;
import com.solid.courses.Models.ReturnData;
import com.solid.courses.R;
import com.solid.courses.Services.CallbackInterface;
import com.solid.courses.Services.RemoteDataSource;

import org.androidannotations.annotations.Click;
import org.androidannotations.annotations.EFragment;
import org.androidannotations.annotations.ViewById;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

/**
 * Created by Le Trinh The Hai on 21/10/2017.
 */

@EFragment(R.layout.fagment_favorite)
public class FavoriteFilterFragment extends BaseFragment {


    @ViewById(R.id.spCity)
    Spinner spCity;

    @ViewById(R.id.spCountry)
    Spinner spCountry;

    @ViewById(R.id.spIns)
    Spinner spIns;
    @ViewById(R.id.tvDate)
    TextView tvDate;
    @ViewById(R.id.spCourseType)
    Spinner spCourseType;


    RemoteDataSource remoteDataSource;

    private DatePickerDialog dayDialog;

    SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd");

    @Override
    public void init() {

        remoteDataSource = new RemoteDataSource(getActivity());

        getCountry();
        getIns();
        getCourseType();

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

    private void getIns(){
        remoteDataSource.getIns(1, 20, new CallbackInterface<List<ReturnData>>() {
            @Override
            public void onSuccess(List<ReturnData> returnDatas) {
                InstituteAdapter instituteAdapter =
                        new InstituteAdapter(getActivity(),android.R.layout.simple_spinner_item, returnDatas);
                spIns.setAdapter(instituteAdapter);
            }

            @Override
            public void onError(String message) {

            }
        });
    }

    private void getCourseType(){
        remoteDataSource.getCourseType(new CallbackInterface<List<CourseType>>() {
            @Override
            public void onSuccess(List<CourseType> returnDatas) {
                CourseTypeAdapter coutseTypeAdapter =
                        new CourseTypeAdapter(getActivity(),android.R.layout.simple_spinner_item, returnDatas);
                spCourseType.setAdapter(coutseTypeAdapter);
            }

            @Override
            public void onError(String message) {

            }
        });
    }

    @Click(R.id.tvDate)
    void clickDate(){
        Calendar cal = Calendar.getInstance();
        DatePickerDialog.OnDateSetListener callback = new DatePickerDialog.OnDateSetListener() {
            @Override
            public void onDateSet(DatePicker datePicker, int i, int i1, int i2) {
                Date date = new Date(i - 1900,i1,i2);
                tvDate.setText(simpleDateFormat.format(date));
            }
        };
        if(dayDialog == null){
            dayDialog = new DatePickerDialog(getActivity(),
                    callback,
                    cal.get(Calendar.YEAR),
                    cal.get(Calendar.MONTH),
                    cal.get(Calendar.DAY_OF_MONTH));
        }
        dayDialog.show();
    }
    @Click(R.id.tvSave)
    void clickSave(){
        FavoriteRequest request = new FavoriteRequest();
        request.setCountryId(((Country) spCountry.getSelectedItem()).getId());
        request.setCityId(((Country)spCity.getSelectedItem()).getId());
        request.setCourseTypeId(((CourseType)spCourseType.getSelectedItem()).getId());
        request.setInstituteId(((ReturnData)spIns.getSelectedItem()).getId());
        request.setSelectTime(tvDate.getText().toString());
        remoteDataSource.setupFavorite(request,new CallbackInterface<List<Course>>() {
            @Override
            public void onSuccess(List<Course> courses) {

            }

            @Override
            public void onError(String message) {

            }
        });
    }

}
