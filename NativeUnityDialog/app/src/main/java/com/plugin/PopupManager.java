package com.plugin;

import android.annotation.SuppressLint;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.DialogInterface.OnKeyListener;
import android.os.Build;
import android.util.Log;
import android.view.ContextThemeWrapper;
import android.view.KeyEvent;

import com.unity3d.player.UnityPlayer;

import org.json.JSONException;
import org.json.JSONObject;

public class PopupManager
{
    public static void ShowMessagePopup(String title, String message, String okButtonText) {
        AlertDialog.Builder messagePopup = new AlertDialog.Builder(new ContextThemeWrapper(UnityPlayer.currentActivity, GetTheme()));
        messagePopup.setTitle(title);
        messagePopup.setMessage(message);
        messagePopup.setPositiveButton(okButtonText, new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                try {
                    UnityBridge.SendMessageToUnity("Success", new JSONObject().put("Success", true).put("ValueStr",
                            "someResult").put( "ValueInt", 999).toString());
                } catch (JSONException e) {
                    e.printStackTrace();
                }
            }
        });
        messagePopup.setOnKeyListener(KeyListener);
        messagePopup.setCancelable(false);
        messagePopup.show();
    }

    @SuppressLint("InlinedApi")
    private static int GetTheme(){
        int theme = 0;
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP) {
            theme = android.R.style.Theme_Material_Light_Dialog;
        } else {
            theme = android.R.style.Theme_Holo_Dialog;
        }
        return theme;
    }

    private static DialogInterface.OnKeyListener KeyListener = new OnKeyListener() {
        @Override
        public boolean onKey(DialogInterface dialog, int keyCode, KeyEvent event) {
            if (keyCode == KeyEvent.KEYCODE_BACK) {
                Log.d("AndroidNative", "AndroidPopUp");
                dialog.dismiss();
            }
            return false;
        }
    };
}
