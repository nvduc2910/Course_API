package com.solid.courses.Fragment;

import android.content.Intent;
import android.net.Uri;
import android.os.Binder;
import android.os.Bundle;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.GridView;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.ProgressBar;
import android.widget.ScrollView;
import android.widget.TextView;
import android.widget.Toast;

import com.joanzapata.android.BaseAdapterHelper;
import com.joanzapata.android.QuickAdapter;
import com.nostra13.universalimageloader.core.ImageLoader;
import com.solid.courses.Adapter.RecyclerViewAdapter;
import com.solid.courses.Adapter.RelianceAdapter;
import com.solid.courses.Models.CourseDetail;
import com.solid.courses.Models.Trainer;
import com.solid.courses.Models.TrainerDetail;
import com.solid.courses.R;
import com.solid.courses.Services.CallbackInterface;
import com.solid.courses.Services.RemoteDataSource;

import org.androidannotations.annotations.Click;
import org.androidannotations.annotations.EFragment;
import org.androidannotations.annotations.ViewById;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.TimeZone;

import de.hdodenhof.circleimageview.CircleImageView;

/**
 * Created by Le Trinh The Hai on 21/10/2017.
 */

@EFragment(R.layout.fragment_trainer_detail)
public class TrainerDetailFragment extends BaseFragment {

    RemoteDataSource remoteDataSource;

    @ViewById(R.id.imAvatar)
            ImageView imAvatar;
    @ViewById(R.id.tvName)
            TextView tvName;
    @ViewById(R.id.tvIns)
            TextView tvIns;
    @ViewById(R.id.tvGender)
            TextView tvGender;

    @ViewById(R.id.imNew)
    ImageView imNew;
    @ViewById(R.id.imAbout)
    ImageView imAbout;
    @ViewById(R.id.imOld)
    ImageView imOld;
    @ViewById(R.id.imContact)
    ImageView imContact;

    @ViewById(R.id.llNew)
    LinearLayout llNew;
    @ViewById(R.id.llAbout)
    LinearLayout llAbout;
    @ViewById(R.id.llOld)
    LinearLayout llOld;
    @ViewById(R.id.llContact)
    LinearLayout llContact;

    @ViewById(R.id.tvPhone)
            TextView tvPhone;
    @ViewById(R.id.tvEmail)
            TextView tvEmail;

    @ViewById(R.id.rvNew)
    RecyclerView rvNew;
    @ViewById(R.id.rvOld)
            RecyclerView rvOld;

    @ViewById(R.id.llSub)
    LinearLayout llSub;
    @ViewById(R.id.svMain)
    ScrollView svMain;
    @ViewById(R.id.pb)
    ProgressBar pb;

    @ViewById(R.id.tvKnowLedge)
            TextView tvKnowLedge;


    ImageLoader imageLoader;

    int trainerId;

    String fbUrl;
    String twUrl;
    String liUrl;
    String phoneNumber;

    @Override
    public void init() {

        remoteDataSource = new RemoteDataSource(getActivity());
        imageLoader = ImageLoader.getInstance();

        svMain.setVisibility(View.GONE);

        final LinearLayoutManager layoutManager = new LinearLayoutManager(getActivity().getApplicationContext());
        layoutManager.setOrientation(LinearLayoutManager.HORIZONTAL);

        //rvNew.setLayoutManager(layoutManager);
        rvOld.setLayoutManager(layoutManager);

        final LinearLayoutManager layoutNewManager = new LinearLayoutManager(getActivity().getApplicationContext());
        layoutNewManager.setOrientation(LinearLayoutManager.HORIZONTAL);
        rvNew.setLayoutManager(layoutNewManager);

        Bundle bundle = getArguments();
        if(bundle == null) return;
        trainerId = bundle.getInt("trainerId");

        loadData();
    }
    private void loadData(){

        remoteDataSource.getTrainerDetail(trainerId, new CallbackInterface<TrainerDetail>() {
            @Override
            public void onSuccess(TrainerDetail trainerDetail) {
                imageLoader.displayImage(getImageUrl(trainerDetail.getAvatar()),imAvatar);
                tvName.setText(trainerDetail.getName());
                tvIns.setText(trainerDetail.getCountry() + " - " + trainerDetail.getCity());
                tvGender.setText(trainerDetail.getGender() == 1? "Male" : "Female");
                tvPhone.setText(trainerDetail.getContact().getContactNumber());
                tvEmail.setText(trainerDetail.getContact().getEmail());

                RecyclerViewAdapter newCourse =
                        new RecyclerViewAdapter(trainerDetail.getNewCourses(), getActivity(), new RecyclerViewAdapter.OnItemClickListener() {
                    @Override
                    public void onItemClick(int item) {

                    }
                });
                rvNew.setAdapter(newCourse);
                newCourse.notifyDataSetChanged();

                RecyclerViewAdapter oldCourse =
                        new RecyclerViewAdapter(trainerDetail.getOldCourses(), getActivity(), new RecyclerViewAdapter.OnItemClickListener() {
                            @Override
                            public void onItemClick(int item) {

                            }
                        });
                rvOld.setAdapter(oldCourse);
                oldCourse.notifyDataSetChanged();

                tvKnowLedge.setText(trainerDetail.getAbout());

                fbUrl = trainerDetail.getContact().getFacebook();
                liUrl = trainerDetail.getContact().getInstagram();
                twUrl = trainerDetail.getContact().getTwitter();
                phoneNumber = trainerDetail.getContact().getContactNumber();

                svMain.setVisibility(View.VISIBLE);
                llSub.setVisibility(View.GONE);
                pb.setVisibility(View.GONE);
            }

            @Override
            public void onError(String message) {
                Toast.makeText(getActivity(), message, Toast.LENGTH_SHORT).show();
                pb.setVisibility(View.GONE);
            }
        });

    }

    @Click(R.id.llNewBtn)
    void ClickNew(){
        llNew.setVisibility(View.VISIBLE);
        llAbout.setVisibility(View.GONE);
        llOld.setVisibility(View.GONE);
        llContact.setVisibility(View.GONE);

        imNew.setImageResource(R.drawable.ic_des_selected);
        imAbout.setImageResource(R.drawable.ic_trainer);
        imOld.setImageResource(R.drawable.ic_des);
        imContact.setImageResource(R.drawable.ic_contact);
    }
    @Click(R.id.llAboutBtn)
    void ClickAbout(){
        llNew.setVisibility(View.GONE);
        llAbout.setVisibility(View.VISIBLE);
        llOld.setVisibility(View.GONE);
        llContact.setVisibility(View.GONE);

        imNew.setImageResource(R.drawable.ic_des);
        imAbout.setImageResource(R.drawable.ic_trainer_selected);
        imOld.setImageResource(R.drawable.ic_des);
        imContact.setImageResource(R.drawable.ic_contact);
    }
    @Click(R.id.llContactBtn)
    void ClickContact(){
        llNew.setVisibility(View.GONE);
        llAbout.setVisibility(View.GONE);
        llOld.setVisibility(View.GONE);
        llContact.setVisibility(View.VISIBLE);

        imNew.setImageResource(R.drawable.ic_des);
        imAbout.setImageResource(R.drawable.ic_trainer);
        imOld.setImageResource(R.drawable.ic_des);
        imContact.setImageResource(R.drawable.ic_contact_selected);
    }
    @Click(R.id.llOldBtn)
    void ClickOld(){
        llNew.setVisibility(View.GONE);
        llAbout.setVisibility(View.GONE);
        llOld.setVisibility(View.VISIBLE);
        llContact.setVisibility(View.GONE);

        imNew.setImageResource(R.drawable.ic_des);
        imAbout.setImageResource(R.drawable.ic_trainer);
        imOld.setImageResource(R.drawable.ic_des_selected);
        imContact.setImageResource(R.drawable.ic_contact);
    }
    @Click(R.id.imFacebook)
    void clickFacebook(){
        Intent i = new Intent(Intent.ACTION_VIEW);
        i.setData(Uri.parse(getUrl(fbUrl)));
        startActivity(i);
    }
    @Click(R.id.imTwitter)
    void clickTwitter(){
        Intent i = new Intent(Intent.ACTION_VIEW);
        i.setData(Uri.parse(getUrl(twUrl)));
        startActivity(i);
    }
    @Click(R.id.imLin)
    void clickimLin(){
        Intent i = new Intent(Intent.ACTION_VIEW);
        i.setData(Uri.parse(getUrl(liUrl)));
        startActivity(i);
    }
    @Click(R.id.imCall)
    void  clickCall(){
        Intent intent = new Intent(Intent.ACTION_DIAL, Uri.parse("tel:" + phoneNumber));
        startActivity(intent);
    }
}
