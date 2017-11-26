package org.libsdl.app;

import java.io.IOException;
import java.io.InputStream;
import java.util.Arrays;
import java.lang.reflect.Method;
import java.util.Objects;

import android.app.*;
import android.content.*;
import android.text.InputType;
import android.view.*;
import android.view.inputmethod.BaseInputConnection;
import android.view.inputmethod.EditorInfo;
import android.view.inputmethod.InputConnection;
import android.view.inputmethod.InputMethodManager;
import android.widget.RelativeLayout;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.os.*;
import android.util.Log;
import android.util.SparseArray;
import android.graphics.*;
import android.graphics.drawable.Drawable;
import android.hardware.*;
import android.content.pm.ActivityInfo;

public interface SDLClipboardHandler {

    public boolean clipboardHasText();
    public String clipboardGetText();
    public void clipboardSetText(String string);

}