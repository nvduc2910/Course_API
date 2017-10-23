package com.solid.courses.Activity;

import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.support.v4.widget.DrawerLayout;
import android.view.Gravity;
import android.view.View;
import android.widget.EditText;
import android.widget.FrameLayout;
import android.widget.LinearLayout;

import com.solid.courses.Fragment.AboutFragment;
import com.solid.courses.Fragment.AboutFragment_;
import com.solid.courses.Fragment.ContactUsFragment;
import com.solid.courses.Fragment.ContactUsFragment_;
import com.solid.courses.Fragment.CourseDetailFragment;
import com.solid.courses.Fragment.CourseDetailFragment_;
import com.solid.courses.Fragment.CourseFragment;
import com.solid.courses.Fragment.CourseFragment_;
import com.solid.courses.Fragment.FavoriteFilterFragment;
import com.solid.courses.Fragment.FavoriteFragment;
import com.solid.courses.Fragment.FavoriteFragment_;
import com.solid.courses.Fragment.HomeFragment;
import com.solid.courses.Fragment.HomeFragment_;
import com.solid.courses.Fragment.InsDetailFragment;
import com.solid.courses.Fragment.InsDetailFragment_;
import com.solid.courses.Fragment.InstituteFragment;
import com.solid.courses.Fragment.InstituteFragment_;
import com.solid.courses.Fragment.ProfileFragment;
import com.solid.courses.Fragment.ProfileFragment_;
import com.solid.courses.Fragment.SearchFragment;
import com.solid.courses.Fragment.SearchFragment_;
import com.solid.courses.Fragment.TrainerDetailFragment;
import com.solid.courses.Fragment.TrainerDetailFragment_;
import com.solid.courses.Fragment.TrainerFragment;
import com.solid.courses.Fragment.TrainerFragment_;
import com.solid.courses.Helper.PreferenceHelper;
import com.solid.courses.R;

import org.androidannotations.annotations.Click;
import org.androidannotations.annotations.EActivity;
import org.androidannotations.annotations.ViewById;

/**
 * Created by Le Trinh The Hai on 17/10/2017.
 */

@EActivity(R.layout.activity_main)
public class MainActivity extends BaseActivity {

    @ViewById(R.id.flHome)
    FrameLayout flHome;
    @ViewById(R.id.llHome)
    LinearLayout llHome;

    @ViewById(R.id.llCourse)
            LinearLayout llCourse;
    @ViewById(R.id.flCourse)
            FrameLayout flCourse;
    @ViewById(R.id.llTrainer)
    LinearLayout llTrainer;
    @ViewById(R.id.llFavorite)
    LinearLayout llFavorite;

    @ViewById(R.id.llIns)
            LinearLayout llIns;
    @ViewById(R.id.flIns)
            FrameLayout flIns;
    @ViewById(R.id.flCourseDetail)
            FrameLayout flCourseDetail;
    @ViewById(R.id.flTRainer)
            FrameLayout flTRainer;
    @ViewById(R.id.flFavorite)
            FrameLayout flFavorite;
    @ViewById(R.id.flTrainerDetail)
            FrameLayout flTrainerDetail;
    @ViewById(R.id.flInsDetail)
            FrameLayout flInsDetail;
    @ViewById(R.id.flSetting)
    FrameLayout flSetting;
    @ViewById(R.id.flContactUs)
    FrameLayout flContactUs;
    @ViewById(R.id.flAbout)
    FrameLayout flAbout;
    @ViewById(R.id.flSearch)
    FrameLayout flSearch;

    @ViewById(R.id.rootDrawer)
    DrawerLayout rootDrawer;

    FragmentManager fragmentManager;
    FragmentTransaction fragmentTransaction;

    HomeFragment homeFragment;
    CourseFragment courseFragment;
    InstituteFragment instituteFragment;
    TrainerFragment trainerFragment;
    FavoriteFragment favoriteFragment;

    CourseDetailFragment courseDetailFragment;
    TrainerDetailFragment trainerDetailFragment;
    InsDetailFragment insDetailFragment;
    ProfileFragment profileFragment;
    ContactUsFragment contactUsFragment;
    AboutFragment aboutFragment;
    SearchFragment searchFragment;

    @Override
    public void init() {

        fragmentManager = getSupportFragmentManager();
        fragmentTransaction = fragmentManager.beginTransaction();

        Bundle bundle = getIntent().getExtras();
        if(bundle == null){
            flHome.setVisibility(View.VISIBLE);
            llHome.setBackgroundColor(Color.parseColor("#CA3560"));

            if(homeFragment == null){
                homeFragment = new HomeFragment_();
                fragmentTransaction.replace(R.id.flHome, homeFragment);
                fragmentTransaction.commit();
            }
        }
    }
    public  void navInsDetail(int id){
        insDetailFragment = new InsDetailFragment_();
        Bundle insDetailBundle = new Bundle();
        insDetailBundle.putInt("insId", id);
        insDetailFragment.setArguments(insDetailBundle);

        flInsDetail.setVisibility(View.VISIBLE);
        llIns.setBackgroundColor(Color.parseColor("#CA3560"));

        fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.flInsDetail, insDetailFragment);
        fragmentTransaction.commit();

        flHome.setVisibility(View.GONE);
        llHome.setBackgroundColor(Color.parseColor("#00ffffff"));
        flIns.setVisibility(View.GONE);
        flCourse.setVisibility(View.GONE);
        llCourse.setBackgroundColor(Color.parseColor("#00ffffff"));
        flTRainer.setVisibility(View.GONE);
        llTrainer.setBackgroundColor(Color.parseColor("#00ffffff"));
        flFavorite.setVisibility(View.GONE);
        llFavorite.setBackgroundColor(Color.parseColor("#00ffffff"));

        flCourseDetail.setVisibility(View.GONE);
        flTrainerDetail.setVisibility(View.GONE);
        flSetting.setVisibility(View.GONE);
        flContactUs.setVisibility(View.GONE);
        flAbout.setVisibility(View.GONE);
        flSearch.setVisibility(View.GONE);
    }

    public void navTrainDetail(int id){
        trainerDetailFragment = new TrainerDetailFragment_();
        Bundle trainerDetailBundle = new Bundle();
        trainerDetailBundle.putInt("trainerId", id);
        trainerDetailFragment.setArguments(trainerDetailBundle);

        flTrainerDetail.setVisibility(View.VISIBLE);
        llTrainer.setBackgroundColor(Color.parseColor("#CA3560"));

        fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.flTrainerDetail, trainerDetailFragment);
        fragmentTransaction.commit();

        flHome.setVisibility(View.GONE);
        llHome.setBackgroundColor(Color.parseColor("#00ffffff"));
        flIns.setVisibility(View.GONE);
        llIns.setBackgroundColor(Color.parseColor("#00ffffff"));
        flCourse.setVisibility(View.GONE);
        llCourse.setBackgroundColor(Color.parseColor("#00ffffff"));
        flTRainer.setVisibility(View.GONE);
        flFavorite.setVisibility(View.GONE);
        llFavorite.setBackgroundColor(Color.parseColor("#00ffffff"));

        flCourseDetail.setVisibility(View.GONE);
        flInsDetail.setVisibility(View.GONE);
        flSetting.setVisibility(View.GONE);
        flContactUs.setVisibility(View.GONE);
        flAbout.setVisibility(View.GONE);
        flSearch.setVisibility(View.GONE);
    }

    public void navCourseDetail(int id){
        courseDetailFragment = new CourseDetailFragment_();
        Bundle courseDetailBundle = new Bundle();
        courseDetailBundle.putInt("courseId", id);
        courseDetailFragment.setArguments(courseDetailBundle);

        flCourseDetail.setVisibility(View.VISIBLE);
        llCourse.setBackgroundColor(Color.parseColor("#CA3560"));

        fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.flCourseDetail, courseDetailFragment);
        fragmentTransaction.commit();

        flHome.setVisibility(View.GONE);
        llHome.setBackgroundColor(Color.parseColor("#00ffffff"));
        flIns.setVisibility(View.GONE);
        llIns.setBackgroundColor(Color.parseColor("#00ffffff"));
        flCourse.setVisibility(View.GONE);
        flTRainer.setVisibility(View.GONE);
        llTrainer.setBackgroundColor(Color.parseColor("#00ffffff"));
        flFavorite.setVisibility(View.GONE);
        llFavorite.setBackgroundColor(Color.parseColor("#00ffffff"));

        flTrainerDetail.setVisibility(View.GONE);
        flInsDetail.setVisibility(View.GONE);
        flSetting.setVisibility(View.GONE);
        flContactUs.setVisibility(View.GONE);
        flAbout.setVisibility(View.GONE);
        flSearch.setVisibility(View.GONE);
    }

    @Click(R.id.llCourse)
    void clickCourse(){

        flCourse.setVisibility(View.VISIBLE);
        llCourse.setBackgroundColor(Color.parseColor("#CA3560"));

        if(courseFragment == null){
            courseFragment = new CourseFragment_();
            fragmentTransaction = getSupportFragmentManager().beginTransaction();
            fragmentTransaction.replace(R.id.flCourse, courseFragment);
            fragmentTransaction.commit();
        }

        flHome.setVisibility(View.GONE);
        llHome.setBackgroundColor(Color.parseColor("#00ffffff"));
        flIns.setVisibility(View.GONE);
        llIns.setBackgroundColor(Color.parseColor("#00ffffff"));
        flTRainer.setVisibility(View.GONE);
        llTrainer.setBackgroundColor(Color.parseColor("#00ffffff"));
        flFavorite.setVisibility(View.GONE);
        llFavorite.setBackgroundColor(Color.parseColor("#00ffffff"));

        flCourseDetail.setVisibility(View.GONE);
        flTrainerDetail.setVisibility(View.GONE);
        flInsDetail.setVisibility(View.GONE);
        flSetting.setVisibility(View.GONE);
        flContactUs.setVisibility(View.GONE);
        flAbout.setVisibility(View.GONE);
        flSearch.setVisibility(View.GONE);
    }
    @Click(R.id.llHome)
    void clickHome(){
        flHome.setVisibility(View.VISIBLE);
        llHome.setBackgroundColor(Color.parseColor("#CA3560"));

        if(homeFragment == null){
            homeFragment = new HomeFragment_();
            fragmentTransaction = getSupportFragmentManager().beginTransaction();
            fragmentTransaction.replace(R.id.flHome, homeFragment);
            fragmentTransaction.commit();
        }
        flCourse.setVisibility(View.GONE);
        llCourse.setBackgroundColor(Color.parseColor("#00ffffff"));
        flIns.setVisibility(View.GONE);
        llIns.setBackgroundColor(Color.parseColor("#00ffffff"));
        flTRainer.setVisibility(View.GONE);
        llTrainer.setBackgroundColor(Color.parseColor("#00ffffff"));
        flFavorite.setVisibility(View.GONE);
        llFavorite.setBackgroundColor(Color.parseColor("#00ffffff"));

        flCourseDetail.setVisibility(View.GONE);
        flTrainerDetail.setVisibility(View.GONE);
        flInsDetail.setVisibility(View.GONE);
        flSetting.setVisibility(View.GONE);
        flContactUs.setVisibility(View.GONE);
        flAbout.setVisibility(View.GONE);
        flSearch.setVisibility(View.GONE);
    }
    @Click(R.id.llIns)
    void clickIns(){
        flIns.setVisibility(View.VISIBLE);
        llIns.setBackgroundColor(Color.parseColor("#CA3560"));

        if(instituteFragment == null){
            instituteFragment = new InstituteFragment_();
            fragmentTransaction = getSupportFragmentManager().beginTransaction();
            fragmentTransaction.replace(R.id.flIns, instituteFragment);
            fragmentTransaction.commit();
        }

        flHome.setVisibility(View.GONE);
        llHome.setBackgroundColor(Color.parseColor("#00ffffff"));
        flCourse.setVisibility(View.GONE);
        llCourse.setBackgroundColor(Color.parseColor("#00ffffff"));
        flTRainer.setVisibility(View.GONE);
        llTrainer.setBackgroundColor(Color.parseColor("#00ffffff"));
        flFavorite.setVisibility(View.GONE);
        llFavorite.setBackgroundColor(Color.parseColor("#00ffffff"));

        flCourseDetail.setVisibility(View.GONE);
        flTrainerDetail.setVisibility(View.GONE);
        flInsDetail.setVisibility(View.GONE);
        flSetting.setVisibility(View.GONE);
        flContactUs.setVisibility(View.GONE);
        flAbout.setVisibility(View.GONE);
        flSearch.setVisibility(View.GONE);
    }
    @Click(R.id.llTrainer)
    void clickTrainer(){
        flTRainer.setVisibility(View.VISIBLE);
        llTrainer.setBackgroundColor(Color.parseColor("#CA3560"));

        if(trainerFragment == null){
            trainerFragment = new TrainerFragment_();
            fragmentTransaction = getSupportFragmentManager().beginTransaction();
            fragmentTransaction.replace(R.id.flTRainer, trainerFragment);
            fragmentTransaction.commit();
        }

        flHome.setVisibility(View.GONE);
        llHome.setBackgroundColor(Color.parseColor("#00ffffff"));
        flCourse.setVisibility(View.GONE);
        llCourse.setBackgroundColor(Color.parseColor("#00ffffff"));
        flIns.setVisibility(View.GONE);
        llIns.setBackgroundColor(Color.parseColor("#00ffffff"));
        flFavorite.setVisibility(View.GONE);
        llFavorite.setBackgroundColor(Color.parseColor("#00ffffff"));

        flCourseDetail.setVisibility(View.GONE);
        flTrainerDetail.setVisibility(View.GONE);
        flInsDetail.setVisibility(View.GONE);
        flSetting.setVisibility(View.GONE);
        flContactUs.setVisibility(View.GONE);
        flAbout.setVisibility(View.GONE);
        flSearch.setVisibility(View.GONE);
    }
    @Click(R.id.llFavorite)
    void clickFavorite(){
        flFavorite.setVisibility(View.VISIBLE);
        llFavorite.setBackgroundColor(Color.parseColor("#CA3560"));

        if(favoriteFragment == null){
            favoriteFragment = new FavoriteFragment_();
            fragmentTransaction = getSupportFragmentManager().beginTransaction();
            fragmentTransaction.replace(R.id.flFavorite, favoriteFragment);
            fragmentTransaction.commit();
        }

        flHome.setVisibility(View.GONE);
        llHome.setBackgroundColor(Color.parseColor("#00ffffff"));
        flCourse.setVisibility(View.GONE);
        llCourse.setBackgroundColor(Color.parseColor("#00ffffff"));
        flIns.setVisibility(View.GONE);
        llIns.setBackgroundColor(Color.parseColor("#00ffffff"));
        flTRainer.setVisibility(View.GONE);
        llTrainer.setBackgroundColor(Color.parseColor("#00ffffff"));

        flCourseDetail.setVisibility(View.GONE);
        flTrainerDetail.setVisibility(View.GONE);
        flInsDetail.setVisibility(View.GONE);
        flSetting.setVisibility(View.GONE);
        flContactUs.setVisibility(View.GONE);
        flAbout.setVisibility(View.GONE);
        flSearch.setVisibility(View.GONE);
    }
    @Click(R.id.imHumberger)
    void click(){
        rootDrawer.openDrawer(Gravity.LEFT);
    }

    @Click(R.id.tvSetting)
    void clickSetting(){
        rootDrawer.closeDrawer(Gravity.LEFT);

        flSetting.setVisibility(View.VISIBLE);

        if(profileFragment == null){
            profileFragment = new ProfileFragment_();
            fragmentTransaction = getSupportFragmentManager().beginTransaction();
            fragmentTransaction.replace(R.id.flSetting, profileFragment);
            fragmentTransaction.commit();
        }

        flFavorite.setVisibility(View.GONE);
        llFavorite.setBackgroundColor(Color.parseColor("#00ffffff"));

        flHome.setVisibility(View.GONE);
        llHome.setBackgroundColor(Color.parseColor("#00ffffff"));
        flCourse.setVisibility(View.GONE);
        llCourse.setBackgroundColor(Color.parseColor("#00ffffff"));
        flIns.setVisibility(View.GONE);
        llIns.setBackgroundColor(Color.parseColor("#00ffffff"));
        flTRainer.setVisibility(View.GONE);
        llTrainer.setBackgroundColor(Color.parseColor("#00ffffff"));

        flCourseDetail.setVisibility(View.GONE);
        flTrainerDetail.setVisibility(View.GONE);
        flInsDetail.setVisibility(View.GONE);
        flContactUs.setVisibility(View.GONE);
        flAbout.setVisibility(View.GONE);
        flSearch.setVisibility(View.GONE);
    }
    @Click(R.id.tvContactUs)
    void clickContact(){
        rootDrawer.closeDrawer(Gravity.LEFT);

        flContactUs.setVisibility(View.VISIBLE);

        if(contactUsFragment == null){
            contactUsFragment = new ContactUsFragment_();
            fragmentTransaction = getSupportFragmentManager().beginTransaction();
            fragmentTransaction.replace(R.id.flContactUs, contactUsFragment);
            fragmentTransaction.commit();
        }

        flFavorite.setVisibility(View.GONE);
        llFavorite.setBackgroundColor(Color.parseColor("#00ffffff"));

        flHome.setVisibility(View.GONE);
        llHome.setBackgroundColor(Color.parseColor("#00ffffff"));
        flCourse.setVisibility(View.GONE);
        llCourse.setBackgroundColor(Color.parseColor("#00ffffff"));
        flIns.setVisibility(View.GONE);
        llIns.setBackgroundColor(Color.parseColor("#00ffffff"));
        flTRainer.setVisibility(View.GONE);
        llTrainer.setBackgroundColor(Color.parseColor("#00ffffff"));

        flCourseDetail.setVisibility(View.GONE);
        flTrainerDetail.setVisibility(View.GONE);
        flInsDetail.setVisibility(View.GONE);
        flSetting.setVisibility(View.GONE);
        flAbout.setVisibility(View.GONE);
        flSearch.setVisibility(View.GONE);
    }
    @Click(R.id.tvAbout)
    void clickAbout(){
        rootDrawer.closeDrawer(Gravity.LEFT);

        flAbout.setVisibility(View.VISIBLE);

        if(aboutFragment == null){
            aboutFragment = new AboutFragment_();
            fragmentTransaction = getSupportFragmentManager().beginTransaction();
            fragmentTransaction.replace(R.id.flAbout, aboutFragment);
            fragmentTransaction.commit();
        }

        flFavorite.setVisibility(View.GONE);
        llFavorite.setBackgroundColor(Color.parseColor("#00ffffff"));

        flHome.setVisibility(View.GONE);
        llHome.setBackgroundColor(Color.parseColor("#00ffffff"));
        flCourse.setVisibility(View.GONE);
        llCourse.setBackgroundColor(Color.parseColor("#00ffffff"));
        flIns.setVisibility(View.GONE);
        llIns.setBackgroundColor(Color.parseColor("#00ffffff"));
        flTRainer.setVisibility(View.GONE);
        llTrainer.setBackgroundColor(Color.parseColor("#00ffffff"));

        flCourseDetail.setVisibility(View.GONE);
        flTrainerDetail.setVisibility(View.GONE);
        flInsDetail.setVisibility(View.GONE);
        flSetting.setVisibility(View.GONE);
        flContactUs.setVisibility(View.GONE);
        flSearch.setVisibility(View.GONE);
    }
    @Click(R.id.imSearch)
    void clickSearch(){
        flSearch.setVisibility(View.VISIBLE);

        if(searchFragment == null){
            searchFragment = new SearchFragment_();
            fragmentTransaction = getSupportFragmentManager().beginTransaction();
            fragmentTransaction.replace(R.id.flSearch, searchFragment);
            fragmentTransaction.commit();
        }

        flFavorite.setVisibility(View.GONE);
        llFavorite.setBackgroundColor(Color.parseColor("#00ffffff"));

        flHome.setVisibility(View.GONE);
        llHome.setBackgroundColor(Color.parseColor("#00ffffff"));
        flCourse.setVisibility(View.GONE);
        llCourse.setBackgroundColor(Color.parseColor("#00ffffff"));
        flIns.setVisibility(View.GONE);
        llIns.setBackgroundColor(Color.parseColor("#00ffffff"));
        flTRainer.setVisibility(View.GONE);
        llTrainer.setBackgroundColor(Color.parseColor("#00ffffff"));

        flCourseDetail.setVisibility(View.GONE);
        flTrainerDetail.setVisibility(View.GONE);
        flInsDetail.setVisibility(View.GONE);
        flSetting.setVisibility(View.GONE);
        flContactUs.setVisibility(View.GONE);
        flAbout.setVisibility(View.GONE);
    }

    @Override
    public void onBackPressed() {
    }

    @Click(R.id.tvLogout)
    void clickLogout(){
        PreferenceHelper preferenceHelper = PreferenceHelper.getInstance(this);
        preferenceHelper.setToken("");

        Intent intent = new Intent(this, LoginActivity_.class);
        startActivity(intent);
        finish();
    }
}
