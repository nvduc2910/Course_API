package com.solid.courses.Adapter;

import android.app.Activity;
import android.content.Context;
import android.graphics.Color;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.solid.courses.Models.Country;
import com.solid.courses.Models.ReturnData;
import com.solid.courses.R;

import java.util.List;

/**
 * Created by Le Trinh The Hai on 19/10/2017.
 */

public class InstituteAdapter extends ArrayAdapter<ReturnData> {

    private Activity context;
    private List<ReturnData> Ins;
    LayoutInflater inflater;
    int resources;


    public InstituteAdapter(Activity context, int resource, List<ReturnData> countries) {
        super(context, resource, countries);
        this.Ins = countries;
        this.context = context;
        inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
    }

    @Override
    public int getCount(){
        return Ins.size();
    }

    @Nullable
    @Override
    public ReturnData getItem(int position) {
        return Ins.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        TextView label = new TextView(context);
        label.setTextColor(Color.BLACK);

        label.setText(Ins.get(position).getName());


        return label;
    }

    @Override
    public View getDropDownView(int position, View convertView,
                                ViewGroup parent) {

        LinearLayout llTitle = (LinearLayout) context.getLayoutInflater().inflate(R.layout.item_spinner,null);

        TextView tvContent = (TextView) llTitle.findViewById(R.id.tvContent);

        tvContent.setText(Ins.get(position).getName());

        return llTitle;
    }
}
