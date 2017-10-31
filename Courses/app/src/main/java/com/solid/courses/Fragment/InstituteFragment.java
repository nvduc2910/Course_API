package com.solid.courses.Fragment;

import android.content.Intent;
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
import com.solid.courses.Models.Course;
import com.solid.courses.Models.ReturnData;
import com.solid.courses.R;
import com.solid.courses.Services.CallbackInterface;
import com.solid.courses.Services.RemoteDataSource;

import org.androidannotations.annotations.EFragment;
import org.androidannotations.annotations.ViewById;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.TimeZone;

/**
 * Created by Le Trinh The Hai on 21/10/2017.
 */

@EFragment(R.layout.fragment_institutes)
public class InstituteFragment extends BaseFragment {

    final int INS_PAGE = 1;
    final int INS_PAGE_SIZE = 8;

    RemoteDataSource remoteDataSource;

    @ViewById(R.id.gvIns)
    GridView gvIns;
    @ViewById(R.id.pb)
    ProgressBar pb;

    GridViewAdapter insAdapter;

    @Override
    public void init() {
        remoteDataSource = new RemoteDataSource(getActivity());

        loadData();
    }
    private void loadData(){

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

                pb.setVisibility(View.GONE);
            }

            @Override
            public void onError(String message) {

            }
        });


    }
}
