package com.solid.courses.Services;

/**
 * Created by Le Trinh The Hai on 17/10/2017.
 */

public interface CallbackInterface<D> {
    void onSuccess(D d);

    void onError(String message);
}
