package com.solid.courses.Adapter;

import android.app.Activity;
import android.content.Context;
import android.content.res.Resources;
import android.graphics.Color;
import android.support.annotation.LayoutRes;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.solid.courses.Models.Country;
import com.solid.courses.R;

import java.util.List;

/**
 * Created by Le Trinh The Hai on 19/10/2017.
 */

public class CountryAdapter extends ArrayAdapter<Country> {

    private Activity context;
    private List<Country> countries;
    LayoutInflater inflater;
    int resources;


    public CountryAdapter(Activity context, int resource, List<Country> countries) {
        super(context, resource, countries);
        this.countries = countries;
        this.context = context;
        inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
    }

    @Override
    public int getCount(){
        return countries.size();
    }

    @Nullable
    @Override
    public Country getItem(int position) {
        return countries.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        TextView label = new TextView(context);
        label.setTextColor(Color.BLACK);

        label.setText(countries.get(position).getName());


        return label;
    }

    @Override
    public View getDropDownView(int position, View convertView,
                                ViewGroup parent) {

        LinearLayout llTitle = (LinearLayout) context.getLayoutInflater().inflate(R.layout.item_spinner,null);

        TextView tvContent = (TextView) llTitle.findViewById(R.id.tvContent);

        tvContent.setText(countries.get(position).getName());

        return llTitle;
    }
}
