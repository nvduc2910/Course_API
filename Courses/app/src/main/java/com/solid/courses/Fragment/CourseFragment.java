package com.solid.courses.Fragment;

import android.app.Fragment;
import android.content.Intent;
import android.support.v4.widget.SwipeRefreshLayout;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.AbsListView;
import android.widget.GridView;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.ProgressBar;

import com.joanzapata.android.BaseAdapterHelper;
import com.joanzapata.android.QuickAdapter;
import com.nostra13.universalimageloader.core.ImageLoader;
import com.solid.courses.Activity.MainActivity;
import com.solid.courses.Activity.MainActivity_;
import com.solid.courses.Adapter.GridViewAdapter;
import com.solid.courses.Adapter.RecyclerViewAdapter;
import com.solid.courses.Models.Course;
import com.solid.courses.Models.ReturnData;
import com.solid.courses.R;
import com.solid.courses.Services.CallbackInterface;
import com.solid.courses.Services.RemoteDataSource;

import org.androidannotations.annotations.EFragment;
import org.androidannotations.annotations.ViewById;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;
import java.util.TimeZone;

/**
 * Created by Le Trinh The Hai on 21/10/2017.
 */

@EFragment(R.layout.fragment_courses)
public class CourseFragment extends BaseFragment {

    int COUSES_PAGE = 1;
    final int COURSE_PAGE_SIZE = 20;

    RemoteDataSource remoteDataSource;

    QuickAdapter<Course> courseAdapter;

    @ViewById(R.id.swiperefresh)
    SwipeRefreshLayout swipelayout;

    ImageLoader imageLoader;

    @ViewById(R.id.lvCourse)
    ListView lvCourse;
    @ViewById(R.id.pb)
    ProgressBar pb;

    private boolean isLoadmore = true;

    @Override
    public void init() {
        remoteDataSource = new RemoteDataSource(getActivity());

        imageLoader = ImageLoader.getInstance();

        courseAdapter = new QuickAdapter<Course>(getActivity(), R.layout.item_course) {
            @Override
            protected void convert(BaseAdapterHelper helper, final Course item) {
                helper.setText(R.id.tvName, item.getName())
                        .setText(R.id.tvIns, item.getInstituteName())
                        .setText(R.id.tvPrice, String.valueOf(item.getMainPrice())  + item.getCurrency())
                        .setText(R.id.tvMovitationPrice, String.valueOf(item.getMotivationPrice())  + item.getCurrency())
                        .setText(R.id.tvLocation, item.getCountry() + " - "+ item.getCity());

                helper.setVisible(R.id.imMale, item.getGender() == 1 || item.getGender() == 0);
                helper.setVisible(R.id.imFemale, item.getGender() == 2 || item.getGender() == 0);

                SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm");
                dateFormat.setTimeZone(TimeZone.getTimeZone("UTC"));
                try {
                    Date date = dateFormat.parse(item.getStartDate());

                    dateFormat = new SimpleDateFormat("dd MMM yyyy");
                    helper.setText(R.id.tvDate, dateFormat.format(date) +" (" +item.getTotalDay() +" Days)");

                } catch (ParseException e) {
                    e.printStackTrace();
                }


                imageLoader.displayImage(item.getImage(),(ImageView) helper.getView(R.id.imCourse) );

                helper.setOnClickListener(R.id.root, new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
//                        Intent intent = new Intent(getActivity(), MainActivity_.class);
//                        intent.putExtra("type", 1);
//                        intent.putExtra("courseId", item.getId());
//                        startActivity(intent);
                        ((MainActivity)getActivity()).navCourseDetail(item.getId());

                    }
                });
            }
        };

        lvCourse.setOnScrollListener(new AbsListView.OnScrollListener() {
            @Override
            public void onScrollStateChanged(AbsListView absListView, int i) {

            }

            @Override
            public void onScroll(AbsListView absListView, int i, int i1, int i2) {

                if(i1+i == i2 && i2!=0)
                {
                    if(isLoadmore){
                        isLoadmore = false;
                        COUSES_PAGE++;
                        loadData();
                    }

                }
            }
        });

        swipelayout.setOnRefreshListener(new SwipeRefreshLayout.OnRefreshListener() {
            @Override
            public void onRefresh() {
                COUSES_PAGE = 1;
                courseAdapter.clear();
                loadData();
            }
        });

        loadData();
    }
    private void loadData(){
        remoteDataSource.getCourseFeature(COUSES_PAGE, COURSE_PAGE_SIZE, new CallbackInterface<List<Course>>() {

            @Override
            public void onSuccess(List<Course> courses) {
                if(courses.size() != 0){
                    isLoadmore = true;
                    courseAdapter.clear();
                    courseAdapter.addAll(courses);
                    lvCourse.setAdapter(courseAdapter);
                    courseAdapter.notifyDataSetChanged();
                    pb.setVisibility(View.GONE);
                }
                if(swipelayout.isRefreshing()) swipelayout.setRefreshing(false);
            }

            @Override
            public void onError(String message) {

            }
        });


    }
}
