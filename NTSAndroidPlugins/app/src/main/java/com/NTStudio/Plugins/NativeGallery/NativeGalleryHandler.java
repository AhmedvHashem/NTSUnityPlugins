package com.NTStudio.Plugins.NativeGallery;

import android.app.Activity;

import java.io.ByteArrayOutputStream;

import android.content.Intent;
import android.database.Cursor;

import android.graphics.Bitmap;
import android.graphics.Bitmap.CompressFormat;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.provider.MediaStore;

import com.NTStudio.Plugins.Utilities.Base64;
import com.NTStudio.Plugins.Utilities.NTS_Debug;

import com.NTStudio.Plugins.NTSAndroidPlugins;

import com.unity3d.player.*;

public class NativeGalleryHandler
{
    private static NativeGalleryHandler instance;

    public static NativeGalleryHandler GetInstance()
    {
        if (instance == null)
            instance = new NativeGalleryHandler();

        return instance;
    }

    public void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        String path = "";

        Uri selectedImage = data.getData();

        String[] filePathColumn = {MediaStore.Images.Media.DATA};//from Gallery
        // Get the cursor
        Cursor cursor = NTSAndroidPlugins.GetInstance().getContentResolver().query(selectedImage, filePathColumn, null, null, null);
        // Move to first row
        cursor.moveToFirst();

        int columnIndex = cursor.getColumnIndex(filePathColumn[0]);

        path = cursor.getString(columnIndex);
        cursor.close();

        if (path == null)
            path = selectedImage.getPath(); //from File Manager

        if (path != null)
        {
            OnImagePicked(path);
        }
    }

    public void PickUpImage()
    {
        try
        {
            Intent intent = new Intent();
            intent.setType("image/*");
            intent.setAction(Intent.ACTION_GET_CONTENT);
            NTSAndroidPlugins.GetInstance().startActivityForResult(intent, 2);
        }
        catch (Exception e)
        {
            NTS_Debug.Log(e.toString());
        }
    }

    public void OnImagePicked(String imagePath)
    {
        StringBuilder result = new StringBuilder();
        result.append(imagePath);
        result.append('|');

        String imgString = "";

        if (imagePath != null)
        {
            Bitmap bitMap = BitmapFactory.decodeFile(imagePath);

            float aspect = (float) bitMap.getWidth() / (float) bitMap.getHeight();
            float new_height = 512 / aspect;
            Bitmap scaledBitmap = Bitmap.createScaledBitmap(bitMap, 512, (int) new_height, false);
            imgString = Base64.encode(getBytesFromBitmap(scaledBitmap));

            NTS_Debug.Log(imgString);
        }

        result.append(imgString);
        UnityPlayer.UnitySendMessage("Android_NG_Handler", "OnImageLoaded", result.toString());
    }

    public byte[] getBytesFromBitmap(Bitmap bitmap)
    {
        ByteArrayOutputStream stream = new ByteArrayOutputStream();
        bitmap.compress(CompressFormat.PNG, 70, stream);
        return stream.toByteArray();
    }
}