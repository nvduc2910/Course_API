package com.solid.courses.Fragment;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
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
import com.solid.courses.Adapter.GridViewAdapter;
import com.solid.courses.Adapter.RelianceAdapter;
import com.solid.courses.Models.Course;
import com.solid.courses.Models.CourseDetail;
import com.solid.courses.Models.Trainer;
import com.solid.courses.R;
import com.solid.courses.Services.CallbackInterface;
import com.solid.courses.Services.RemoteDataSource;

import org.androidannotations.annotations.Click;
import org.androidannotations.annotations.EFragment;
import org.androidannotations.annotations.ViewById;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;
import java.util.TimeZone;

import de.hdodenhof.circleimageview.CircleImageView;

/**
 * Created by Le Trinh The Hai on 21/10/2017.
 */

@EFragment(R.layout.fragment_course_detail)
public class CourseDetailFragment extends BaseFragment {

    @ViewById(R.id.imDes)
    ImageView imDes;
    @ViewById(R.id.imTrainer)
    ImageView imTrainer;
    @ViewById(R.id.imLocation)
    ImageView imLocation;
    @ViewById(R.id.imContact)
    ImageView imContact;
    @ViewById(R.id.imReliance)
    ImageView imReliance;
    @ViewById(R.id.imReminder)
    ImageView imReminder;

    @ViewById(R.id.llDes)
    LinearLayout llDes;
    @ViewById(R.id.llTrainer)
    LinearLayout llTrainer;
    @ViewById(R.id.llContact)
    LinearLayout llContact;
    @ViewById(R.id.llReliance)
    LinearLayout llReliance;
    @ViewById(R.id.llReminder)
    LinearLayout llReminder;
    @ViewById(R.id.llLocation)
    LinearLayout llLocation;

    @ViewById(R.id.tvName)
    TextView tvName;
    @ViewById(R.id.tvIns)
            TextView tvIns;
    @ViewById(R.id.tvLocation)
            TextView tvLocation;
    @ViewById(R.id.imMale)
            ImageView imMale;
    @ViewById(R.id.imFemale)
            ImageView imFemale;

    @ViewById(R.id.tvDate)
            TextView tvDate;
    @ViewById(R.id.tvMainPrice)
            TextView tvMainPrice;
    @ViewById(R.id.tvMovitationPrice)
            TextView tvMovitationPrice;
    @ViewById(R.id.tvNote)
            TextView tvNote;
    @ViewById(R.id.imCourse)
            ImageView imCourse;
    @ViewById(R.id.tvDescription)
            TextView tvDescription;

    @ViewById(R.id.lvTrainer)
            ListView lvTrainer;
    @ViewById(R.id.tvPhone)
            TextView tvPhone;
    @ViewById(R.id.tvEmail)
            TextView tvEmail;

    @ViewById(R.id.llSub)
    LinearLayout llSub;
    @ViewById(R.id.svMain)
    ScrollView svMain;
    @ViewById(R.id.pb)
    ProgressBar pb;

    @ViewById(R.id.gvIns)
    GridView gvIns;
    RelianceAdapter relicanceAdapter;

    QuickAdapter<Trainer> trainerAdapter;

    RemoteDataSource remoteDataSource;

    private int courseId;

    ImageLoader imageLoader;

    String url;
    String fbUrl;
    String twUrl;
    String liUrl;
    String phoneNumber;

    @Override
    public void init() {

        remoteDataSource = new RemoteDataSource(getActivity());
        imageLoader = ImageLoader.getInstance();

        trainerAdapter = new QuickAdapter<Trainer>(getActivity(), R.layout.item_trainer_course) {
            @Override
            protected void convert(BaseAdapterHelper helper, Trainer item) {
                helper.setText(R.id.tvName, item.getName())
                        .setText(R.id.tvNational, item.getMajor());
                imageLoader.displayImage(getImageUrl(item.getAvatar()),(CircleImageView) helper.getView(R.id.imAvatar));
            }
        };

        Bundle bundle = getArguments();
        if(bundle == null) return;

        courseId = bundle.getInt("courseId");

        svMain.setVisibility(View.GONE);

        loadData();
    }
    private void loadData(){

        remoteDataSource.getCourseDetail(courseId, new CallbackInterface<CourseDetail>() {
            @Override
            public void onSuccess(CourseDetail courseDetail) {
                tvName.setText(courseDetail.getName());
                tvIns.setText(courseDetail.getInstituteName());
                tvLocation.setText(courseDetail.getCountry() + " - "+ courseDetail.getCity());
                imFemale.setVisibility(courseDetail.getGender() == 0 || courseDetail.getGender() == 2?
                        View.VISIBLE : View.GONE);
                imMale.setVisibility(courseDetail.getGender() == 0 || courseDetail.getGender() == 1?
                        View.VISIBLE : View.GONE);
                tvMainPrice.setText(courseDetail.getMainPrice());

                SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm");
                dateFormat.setTimeZone(TimeZone.getTimeZone("UTC"));
                try {
                    Date date = dateFormat.parse(courseDetail.getStartDate());

                    dateFormat = new SimpleDateFormat("dd MMM yyyy");
                    tvDate.setText(dateFormat.format(date) +" (" +courseDetail.getTotalDay() +")");

                } catch (ParseException e) {
                    e.printStackTrace();
                }

                tvMovitationPrice.setText(courseDetail.getMotivationPrice());
                tvNote.setText(courseDetail.getNote());

                imageLoader.displayImage(getImageUrl(courseDetail.getImage()),imCourse);

                tvDescription.setText(courseDetail.getDescription());

                trainerAdapter.clear();
                trainerAdapter.addAll(courseDetail.getTrainer());
                lvTrainer.setAdapter(trainerAdapter);
                trainerAdapter.notifyDataSetChanged();

                tvPhone.setText(courseDetail.getContact().getContactNumber());
                tvEmail.setText(courseDetail.getContact().getEmail());

                relicanceAdapter = new RelianceAdapter(getActivity(), courseDetail.getReliance());
                gvIns.setAdapter(relicanceAdapter);
                relicanceAdapter.notifyDataSetChanged();

                url = courseDetail.getRegisterLink();
                fbUrl = courseDetail.getContact().getFacebook();
                twUrl = courseDetail.getContact().getTwitter();
                liUrl = courseDetail.getContact().getInstagram();
                phoneNumber = courseDetail.getContact().getContactNumber();

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

    @Click(R.id.llDesBtn)
    void clickDes(){
        llDes.setVisibility(View.VISIBLE);
        llContact.setVisibility(View.GONE);
        llLocation.setVisibility(View.GONE);
        llReliance.setVisibility(View.GONE);
        llReminder.setVisibility(View.GONE);
        llTrainer.setVisibility(View.GONE);

        imDes.setImageResource(R.drawable.ic_des_selected);
        imContact.setImageResource(R.drawable.ic_contact);
        imReliance.setImageResource(R.drawable.ic_reliance);
        imReminder.setImageResource(R.drawable.ic_reminder);
        imTrainer.setImageResource(R.drawable.ic_trainer);
        imLocation.setImageResource(R.drawable.ic_location);
    }
    @Click(R.id.llTrainerBtn)
    void clickTrainer(){
        llDes.setVisibility(View.GONE);
        llContact.setVisibility(View.GONE);
        llLocation.setVisibility(View.GONE);
        llReliance.setVisibility(View.GONE);
        llReminder.setVisibility(View.GONE);
        llTrainer.setVisibility(View.VISIBLE);

        imDes.setImageResource(R.drawable.ic_des);
        imContact.setImageResource(R.drawable.ic_contact);
        imReliance.setImageResource(R.drawable.ic_reliance);
        imReminder.setImageResource(R.drawable.ic_reminder);
        imTrainer.setImageResource(R.drawable.ic_trainer_selected);
        imLocation.setImageResource(R.drawable.ic_location);
    }
    @Click(R.id.llLocationBtn)
    void clickLocation(){
        llDes.setVisibility(View.GONE);
        llContact.setVisibility(View.GONE);
        llLocation.setVisibility(View.VISIBLE);
        llReliance.setVisibility(View.GONE);
        llReminder.setVisibility(View.GONE);
        llTrainer.setVisibility(View.GONE);

        imDes.setImageResource(R.drawable.ic_des);
        imContact.setImageResource(R.drawable.ic_contact);
        imReliance.setImageResource(R.drawable.ic_reliance);
        imReminder.setImageResource(R.drawable.ic_reminder);
        imTrainer.setImageResource(R.drawable.ic_trainer);
        imLocation.setImageResource(R.drawable.ic_location_selected);
    }
    @Click(R.id.llContactBtn)
    void clickContact(){
        llDes.setVisibility(View.GONE);
        llContact.setVisibility(View.VISIBLE);
        llLocation.setVisibility(View.GONE);
        llReliance.setVisibility(View.GONE);
        llReminder.setVisibility(View.GONE);
        llTrainer.setVisibility(View.GONE);

        imDes.setImageResource(R.drawable.ic_des);
        imContact.setImageResource(R.drawable.ic_contact_selected);
        imReliance.setImageResource(R.drawable.ic_reliance);
        imReminder.setImageResource(R.drawable.ic_reminder);
        imTrainer.setImageResource(R.drawable.ic_trainer);
        imLocation.setImageResource(R.drawable.ic_location);
    }
    @Click(R.id.llRelianceBtn)
    void clickReliance(){
        llDes.setVisibility(View.GONE);
        llContact.setVisibility(View.GONE);
        llLocation.setVisibility(View.GONE);
        llReliance.setVisibility(View.VISIBLE);
        llReminder.setVisibility(View.GONE);
        llTrainer.setVisibility(View.GONE);

        imDes.setImageResource(R.drawable.ic_des);
        imContact.setImageResource(R.drawable.ic_contact);
        imReliance.setImageResource(R.drawable.ic_reliance_selected);
        imReminder.setImageResource(R.drawable.ic_reminder);
        imTrainer.setImageResource(R.drawable.ic_trainer);
        imLocation.setImageResource(R.drawable.ic_location);
    }
    @Click(R.id.llReminderBtn)
    void clickReminder(){
        llDes.setVisibility(View.GONE);
        llContact.setVisibility(View.GONE);
        llLocation.setVisibility(View.GONE);
        llReliance.setVisibility(View.GONE);
        llReminder.setVisibility(View.VISIBLE);
        llTrainer.setVisibility(View.GONE);

        imDes.setImageResource(R.drawable.ic_des);
        imContact.setImageResource(R.drawable.ic_contact);
        imReliance.setImageResource(R.drawable.ic_reliance);
        imReminder.setImageResource(R.drawable.ic_reminder_selected);
        imTrainer.setImageResource(R.drawable.ic_trainer);
        imLocation.setImageResource(R.drawable.ic_location);
    }
    @Click(R.id.tvRemind)
    void clickRemind(){
        showProgressDialog(getActivity());
        remoteDataSource.setReminder(courseId, new CallbackInterface() {
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
    @Click(R.id.tvRegister)
    void clickRegister(){
        Intent i = new Intent(Intent.ACTION_VIEW);
        i.setData(Uri.parse(url));
        startActivity(i);
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
