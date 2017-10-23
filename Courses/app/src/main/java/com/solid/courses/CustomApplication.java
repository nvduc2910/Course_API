package com.solid.courses;

import android.app.Application;
import android.content.Context;

import com.nostra13.universalimageloader.cache.memory.impl.WeakMemoryCache;
import com.nostra13.universalimageloader.core.DisplayImageOptions;
import com.nostra13.universalimageloader.core.ImageLoader;
import com.nostra13.universalimageloader.core.ImageLoaderConfiguration;
import com.nostra13.universalimageloader.core.assist.QueueProcessingType;

/**
 * Created by Le Trinh The Hai on 17/10/2017.
 */

public class CustomApplication extends Application {

    private static Context context;
    public static Context getContext() {
        return context;
    }

    @Override
    public void onCreate() {

        super.onCreate();
        context = getApplicationContext();

        //FacebookSdk.sdkInitialize(context);

        DisplayImageOptions opts = new DisplayImageOptions.Builder()
                .cacheInMemory(true)
                .cacheOnDisc(true)
                .build();

        ImageLoaderConfiguration config = new ImageLoaderConfiguration.Builder(
                getApplicationContext()).threadPriority(Thread.MAX_PRIORITY)
                .memoryCache(new WeakMemoryCache())
                .denyCacheImageMultipleSizesInMemory().threadPoolSize(5)
                .tasksProcessingOrder(QueueProcessingType.LIFO)
                .defaultDisplayImageOptions(opts)
                .build();

        ImageLoader.getInstance().init(config);

//        CalligraphyConfig.initDefault(new CalligraphyConfig.Builder()
//                .setDefaultFontPath("fonts/Lato-Regular.ttf")
//                .setFontAttrId(R.attr.fontPath)
//                .build()
//        );
    }
}
