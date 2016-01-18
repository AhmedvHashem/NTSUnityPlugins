package com.NTStudio.Plugins.Utilities;

import android.app.ProgressDialog;
import android.content.Context;
import android.os.AsyncTask;

/**
 * Created by Ahmed Hashem on 7/21/2015.
 */

interface AsyncCallback
{
    void onStart();

    Boolean onProgress();

    void onFinish(Boolean isSuccess);
}

public class AsyncCall extends AsyncTask<Void, Void, Boolean>
{
    private ProgressDialog Dialog;

    public AsyncCallback callback;

    AsyncCall(Context activity)
    {
        Dialog = new ProgressDialog(activity);
    }

    @Override
    protected void onPreExecute()
    {
        // NOTE: You can call UI Element here.

        Dialog.setMessage("Please Wait...");
        Dialog.show();
        Dialog.setCancelable(false);

        callback.onStart();
    }

    @Override
    protected Boolean doInBackground(Void... params)
    {
        // NOTE: You can`t call UI Element here.

        return callback.onProgress();
    }

    @Override
    protected void onPostExecute(final Boolean isSuccess)
    {
        // NOTE: You can call UI Element here.

        Dialog.dismiss();

        callback.onFinish(isSuccess);
    }

    @Override
    protected void onCancelled()
    {
        Dialog.dismiss();
    }
}
