package com.solid.courses.Fragment;

import android.content.Intent;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.GridView;
import android.widget.ProgressBar;
import android.widget.Toast;

import com.solid.courses.Activity.MainActivity;
import com.solid.courses.Activity.MainActivity_;
import com.solid.courses.Adapter.GridViewAdapter;
import com.solid.courses.Adapter.RecyclerViewAdapter;
import com.solid.courses.Models.ReturnData;
import com.solid.courses.R;
import com.solid.courses.Services.CallbackInterface;
import com.solid.courses.Services.RemoteDataSource;

import org.androidannotations.annotations.EFragment;
import org.androidannotations.annotations.ViewById;

import java.util.List;

/**
 * Created by Le Trinh The Hai on 21/10/2017.
 */

@EFragment(R.layout.fragment_home)
public class HomeFragment extends BaseFragment {

    final int COUSES_PAGE = 1;
    final int COURSE_PAGE_SIZE = 10;

    final int INS_PAGE = 1;
    final int INS_PAGE_SIZE = 8;

    @ViewById(R.id.rvCourse)
    RecyclerView rvCourse;

    @ViewById(R.id.gvIns)
    GridView gvIns;

    @ViewById(R.id.pb_ins)
    ProgressBar pb_ins;
    @ViewById(R.id.pb_course)
            ProgressBar pb_course;

    RemoteDataSource remoteDataSource;

    RecyclerViewAdapter courseAdapter;
    GridViewAdapter insAdapter;

    @Override
    public void init() {
        remoteDataSource = new RemoteDataSource(getActivity());


        final LinearLayoutManager layoutManager = new LinearLayoutManager(getActivity().getApplicationContext());
        layoutManager.setOrientation(LinearLayoutManager.HORIZONTAL);
        rvCourse.setLayoutManager(layoutManager);

        loadData();
    }
    private void loadData(){
        remoteDataSource.getCourse(COUSES_PAGE, COURSE_PAGE_SIZE, new CallbackInterface<List<ReturnData>>() {
            @Override
            public void onSuccess(final List<ReturnData> returnDatas) {
                courseAdapter = new RecyclerViewAdapter(returnDatas, getActivity(), new RecyclerViewAdapter.OnItemClickListener() {
                    @Override
                    public void onItemClick(int item) {
                        ((MainActivity)getActivity()).navCourseDetail(item);
                    }
                });

                rvCourse.setAdapter(courseAdapter);
                courseAdapter.notifyDataSetChanged();

                pb_course.setVisibility(View.GONE);
                rvCourse.setVisibility(View.VISIBLE);
            }

            @Override
            public void onError(String message) {
                Toast.makeText(getActivity(), message, Toast.LENGTH_SHORT).show();
            }
        });

        remoteDataSource.getIns(INS_PAGE, INS_PAGE_SIZE, new CallbackInterface<List<ReturnData>>() {
            @Override
            public void onSuccess(List<ReturnData> returnDatas) {
                insAdapter = new GridViewAdapter(getActivity(), returnDatas, new GridViewAdapter.OnItemClickListener() {
                    @Override
                    public void onItemClick(int item) {
                        ((MainActivity)getActivity()).navInsDetail(item);
                    }
                });
                gvIns.setAdapter(insAdapter);
                insAdapter.notifyDataSetChanged();

                pb_ins.setVisibility(View.GONE);
                gvIns.setVisibility(View.VISIBLE);
            }

            @Override
            public void onError(String message) {
                Toast.makeText(getActivity(), message, Toast.LENGTH_SHORT).show();
            }
        });
    }
}
