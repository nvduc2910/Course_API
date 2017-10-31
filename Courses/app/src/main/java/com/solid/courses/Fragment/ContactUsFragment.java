package com.solid.courses.Fragment;

import android.view.View;
import android.widget.AdapterView;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.mobsandgeeks.saripaar.ValidationError;
import com.mobsandgeeks.saripaar.Validator;
import com.mobsandgeeks.saripaar.annotation.NotEmpty;
import com.solid.courses.Adapter.CountryAdapter;
import com.solid.courses.Models.ContactApp;
import com.solid.courses.Models.Country;
import com.solid.courses.Models.Profile;
import com.solid.courses.Models.RequestModels.ProfileRequest;
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

@EFragment(R.layout.fragment_contact_us)
public class ContactUsFragment extends BaseFragment {

    @ViewById(R.id.tvPhone)
    TextView tvPhone;

    @ViewById(R.id.tvEmail)
            TextView tvEmail;

    RemoteDataSource remoteDataSource;

    @Override
    public void init() {
        remoteDataSource = new RemoteDataSource(getActivity());
        loadData();
    }

    private void loadData(){
        showProgressDialog(getActivity());
        remoteDataSource.getContact(new CallbackInterface<ContactApp>() {
            @Override
            public void onSuccess(ContactApp contactApp) {
                tvPhone.setText(contactApp.getContactNumber());
                tvEmail.setText(contactApp.getEmail());
                hideProgressDialog();
            }

            @Override
            public void onError(String message) {
                Toast.makeText(getActivity(), message, Toast.LENGTH_SHORT).show();
                hideProgressDialog();
            }
        });
    }

}
