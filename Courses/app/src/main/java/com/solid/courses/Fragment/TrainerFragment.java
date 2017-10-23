package com.solid.courses.Fragment;

import android.content.Intent;
import android.support.v4.widget.SwipeRefreshLayout;
import android.view.View;
import android.widget.AbsListView;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.ProgressBar;

import com.joanzapata.android.BaseAdapterHelper;
import com.joanzapata.android.QuickAdapter;
import com.nostra13.universalimageloader.core.ImageLoader;
import com.solid.courses.Activity.MainActivity;
import com.solid.courses.Activity.MainActivity_;
import com.solid.courses.Models.Course;
import com.solid.courses.Models.Trainer;
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

@EFragment(R.layout.fragment_trainers)
public class TrainerFragment extends BaseFragment {

    int PAGE = 1;
    final int PAGE_SIZE = 20;

    @ViewById(R.id.swiperefresh)
    SwipeRefreshLayout swipelayout;

    RemoteDataSource remoteDataSource;

    QuickAdapter<Trainer> trainerAdapter;

    ImageLoader imageLoader;

    @ViewById(R.id.lvTrainer)
    ListView lvTrainer;
    @ViewById(R.id.pb)
    ProgressBar pb;

    private boolean isLoadmore = true;

    @Override
    public void init() {
        remoteDataSource = new RemoteDataSource(getActivity());

        imageLoader = ImageLoader.getInstance();

        trainerAdapter = new QuickAdapter<Trainer>(getActivity(), R.layout.item_trainer) {
            @Override
            protected void convert(BaseAdapterHelper helper, final Trainer item) {
                helper.setText(R.id.tvName, item.getName())
                        .setText(R.id.tvIns, item.getMajor());



                imageLoader.displayImage(getImageUrl(item.getAvatar()),(ImageView) helper.getView(R.id.imAvatar) );

                if(item.getTotalActive() > 0){
                    helper.setVisible(R.id.rlActive, true);
                    helper.setText(R.id.tvNumberActive, String.valueOf(item.getTotalActive()));
                } else {
                    helper.setVisible(R.id.rlActive, false);
                }

                helper.setOnClickListener(R.id.root, new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
//                        Intent intent = new Intent(getActivity(), MainActivity_.class);
//                        intent.putExtra("type", 2);
//                        intent.putExtra("trainerId", item.getId());
//                        startActivity(intent);
                        ((MainActivity)getActivity()).navTrainDetail(item.getId());
                    }
                });
            }
        };

        lvTrainer.setOnScrollListener(new AbsListView.OnScrollListener() {
            @Override
            public void onScrollStateChanged(AbsListView absListView, int i) {

            }

            @Override
            public void onScroll(AbsListView absListView, int i, int i1, int i2) {

                if(i1+i == i2 && i2!=0)
                {
                    if(isLoadmore){
                        isLoadmore = false;
                        PAGE++;
                        loadData();
                    }

                }
            }
        });

        swipelayout.setOnRefreshListener(new SwipeRefreshLayout.OnRefreshListener() {
            @Override
            public void onRefresh() {
                PAGE = 1;
                trainerAdapter.clear();
                loadData();
            }
        });

        loadData();
    }
    private void loadData(){
        remoteDataSource.getTrainers(PAGE, PAGE_SIZE, new CallbackInterface<List<Trainer>>() {

            @Override
            public void onSuccess(List<Trainer> courses) {
                if(courses.size() != 0){
                    trainerAdapter.clear();
                    trainerAdapter.addAll(courses);
                    lvTrainer.setAdapter(trainerAdapter);
                    trainerAdapter.notifyDataSetChanged();
                    pb.setVisibility(View.GONE);
                    isLoadmore = true;
                }
                if(swipelayout.isRefreshing()) swipelayout.setRefreshing(false);
            }

            @Override
            public void onError(String message) {

            }
        });


    }
}
