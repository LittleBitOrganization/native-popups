package com.plugin;

import android.util.Log;

import org.json.JSONException;
import org.json.JSONObject;

public class Example {

    public static void ShowMessagePopup() {
        // В качестве примера выполним какие-то действия в background потоке
        new Thread(new Runnable() {

            @Override
            public void run() {
                // Колбек требуется вызывать в Unity потоке
                UnityBridge.runOnUnityThread(new Runnable() {

                    @Override
                    public void run() {
                        PopupManager.ShowMessagePopup("Title", "cool message", "ok.");
                    }
                });
            }
        });
    }
}
