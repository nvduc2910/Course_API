package com.solid.courses.Adapter;

import android.app.Activity;
import android.support.v7.widget.CardView;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;

import com.nostra13.universalimageloader.core.ImageLoader;
import com.solid.courses.Models.Reliance;
import com.solid.courses.Models.ReturnData;
import com.solid.courses.R;
import com.solid.courses.Util.DataConstants;

import java.util.List;

/**
 * Created by Le Trinh The Hai on 21/10/2017.
 */

public class RelianceAdapter extends BaseAdapter {
    private Activity mContext;
    private List<Reliance> datas;

    // Gets the context so it can be used later
    public RelianceAdapter(Activity c, List<Reliance> datas) {
        mContext = c;
        this.datas = datas;
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

        final Reliance data = datas.get(position);

        CardView llTitle = (CardView) mContext.getLayoutInflater().inflate(R.layout.item_im_ins,null);

        ImageView imIns = llTitle.findViewById(R.id.imIns);

        ImageLoader imageLoader = ImageLoader.getInstance();

        if(data.getLogo() != null){
            String imPath =  (data.getLogo().contains("http")) ? data.getLogo() :
                    DataConstants.IMAGE_URL + data.getLogo();
            imageLoader.displayImage(imPath, imIns);
        }

        return llTitle;
    }
}