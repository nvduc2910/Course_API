package com.solid.courses.Adapter;

import android.app.Activity;
import android.content.Context;
import android.support.v7.widget.CardView;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.nostra13.universalimageloader.core.ImageLoader;
import com.solid.courses.Models.ReturnData;
import com.solid.courses.R;
import com.solid.courses.Util.DataConstants;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Le Trinh The Hai on 21/10/2017.
 */

public class GridViewAdapter extends BaseAdapter {
    private Activity mContext;
    private List<ReturnData> datas;

    public interface OnItemClickListener {
        void onItemClick(int item);
    }

    private final OnItemClickListener listener;

    // Gets the context so it can be used later
    public GridViewAdapter(Activity c, List<ReturnData> datas, OnItemClickListener listener) {
        mContext = c;
        this.datas = datas;
        this.listener = listener;
    }

    // Total number of things contained within the adapter
    public int getCount() {
        return datas.size();
    }

    // Require for structure, not really used in my code.
    public ReturnData getItem(int position) {
        return null;
    }

    // Require for structure, not really used in my code. Can
    // be used to get the id of an item in the adapter for
    // manual control.
    public long getItemId(int position) {
        return position;
    }

    public View getView(int position,
                        View convertView, ViewGroup parent) {

        final ReturnData data = datas.get(position);

        CardView llTitle = (CardView) mContext.getLayoutInflater().inflate(R.layout.item_im_ins,null);

        ImageView imIns = llTitle.findViewById(R.id.imIns);

        ImageLoader imageLoader = ImageLoader.getInstance();

        if(data.getImage() != null){
            String imPath =  (data.getImage().contains("http")) ? data.getImage() :
                    DataConstants.IMAGE_URL + data.getImage();
            imageLoader.displayImage(imPath, imIns);
        }

        imIns.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                listener.onItemClick(data.getId());
            }
        });

        return llTitle;
    }
}