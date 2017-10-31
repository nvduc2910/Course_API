package com.solid.courses.Adapter;

import android.app.Activity;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;

import com.nostra13.universalimageloader.core.ImageLoader;
import com.solid.courses.Models.ReturnData;
import com.solid.courses.R;
import com.solid.courses.Util.DataConstants;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Le Trinh The Hai on 21/10/2017.
 */

public class RecyclerViewAdapter extends RecyclerView.Adapter<RecyclerViewAdapter.RecyclerViewHolder> {



    public interface OnItemClickListener {
        void onItemClick(int item);
    }

    private final OnItemClickListener listener;
    private List<ReturnData> datas = new ArrayList<>();

    private Activity context;

    public RecyclerViewAdapter(List<ReturnData> listData, Activity context, OnItemClickListener listener) {
        this.datas = listData;
        this.context = context;
        this.listener = listener;
    }


    @Override
    public RecyclerViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        LayoutInflater inflater = LayoutInflater.from(parent.getContext());
        View itemview = inflater.inflate(R.layout.item_im_course, parent, false);
        return new RecyclerViewHolder(itemview);
    }

    @Override
    public void onBindViewHolder(RecyclerViewHolder holder, int position) {
        final ReturnData data = datas.get(position);

        ImageLoader imageLoader = ImageLoader.getInstance();

        if(data.getImage() != null){
            String imPath =  (data.getImage().contains("http")) ? data.getImage() :
                    DataConstants.IMAGE_URL + data.getImage();
            imageLoader.displayImage(imPath,holder.imCourse);
        }



        holder.itemView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                listener.onItemClick(data.getId());
            }
        });

    }

    @Override
    public int getItemCount() {
        return datas.size();
    }

    class RecyclerViewHolder extends RecyclerView.ViewHolder {
        ImageView imCourse;

        public RecyclerViewHolder(View itemView) {
            super(itemView);
            imCourse = (ImageView) itemView.findViewById(R.id.imCourse);
        }

    }
}