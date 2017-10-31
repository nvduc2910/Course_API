package com.solid.courses.Fragment;

import android.app.DatePickerDialog;
import android.content.Intent;
import android.view.View;
import android.widget.AdapterView;
import android.widget.DatePicker;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.ScrollView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.joanzapata.android.BaseAdapterHelper;
import com.joanzapata.android.QuickAdapter;
import com.nostra13.universalimageloader.core.ImageLoader;
import com.solid.courses.Activity.MainActivity_;
import com.solid.courses.Activity.SearchActivity;
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

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.TimeZone;

/**
 * Created by Le Trinh The Hai on 21/10/2017.
 */

@EFragment(R.layout.fragment_search)
public class SearchFragment extends BaseFragment {

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

    @ViewById(R.id.lvCourse)
    ListView lvCourse;

    @ViewById(R.id.llList)
    LinearLayout llList;

    @ViewById(R.id.scMain)
    ScrollView scMain;

    QuickAdapter<Course> courseAdapter;


    RemoteDataSource remoteDataSource;

    private DatePickerDialog dayDialog;

    SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd");

    ImageLoader imageLoader;

    @Override
    public void init() {

        remoteDataSource = new RemoteDataSource(getActivity());

        imageLoader = ImageLoader.getInstance();

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

        courseAdapter = new QuickAdapter<Course>(getActivity(), R.layout.item_course) {
            @Override
            protected void convert(BaseAdapterHelper helper, final Course item) {
                helper.setText(R.id.tvName, item.getName())
                        .setText(R.id.tvIns, item.getInstituteName())
                        .setText(R.id.tvPrice, String.valueOf(item.getMainPrice()))
                        .setText(R.id.tvMovitationPrice, String.valueOf(item.getMotivationPrice()))
                        .setText(R.id.tvLocation, item.getCountry() + " - "+ item.getCity());

                helper.setVisible(R.id.imMale, item.getGender() == 1 || item.getGender() == 0);
                helper.setVisible(R.id.imFemale, item.getGender() == 2 || item.getGender() == 0);

                SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm");
                dateFormat.setTimeZone(TimeZone.getTimeZone("UTC"));
                try {
                    Date date = dateFormat.parse(item.getStartDate());

                    dateFormat = new SimpleDateFormat("dd MMM yyyy");
                    helper.setText(R.id.tvDate, dateFormat.format(date) +" (" +item.getTotalDay() +")");

                } catch (ParseException e) {
                    e.printStackTrace();
                }


                imageLoader.displayImage(getImageUrl(item.getImage()),(ImageView) helper.getView(R.id.imCourse) );

                helper.setOnClickListener(R.id.root, new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        Intent intent = new Intent(getActivity(), MainActivity_.class);
                        intent.putExtra("type", 1);
                        intent.putExtra("courseId", item.getId());
                        startActivity(intent);
                    }
                });
            }
        };
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
        remoteDataSource.searchCourse(request,new CallbackInterface<List<Course>>() {
            @Override
            public void onSuccess(List<Course> courses) {
                scMain.setVisibility(View.GONE);
                llList.setVisibility(View.VISIBLE);
                courseAdapter.clear();
                courseAdapter.addAll(courses);
                lvCourse.setAdapter(courseAdapter);
            }

            @Override
            public void onError(String message) {
                Toast.makeText(getActivity(), message, Toast.LENGTH_SHORT).show();
            }
        });
    }

}
