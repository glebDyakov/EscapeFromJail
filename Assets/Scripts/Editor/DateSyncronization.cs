using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class DateSyncronization {
    
    public static bool LeaveGame(){
        string lastTimestampPlay = DateTime.Now.ToString("dd:MM:yyyy|HH:mm:ss");
        PlayerPrefs.SetString("LastTimestampPlay", lastTimestampPlay);
        Debug.Log(lastTimestampPlay);
        return true;
    }

    public static void QuitGame(){
        string lastTimestampPlay = DateTime.Now.ToString("dd:MM:yyyy|HH:mm:ss");
        PlayerPrefs.SetString("LastTimestampPlay", lastTimestampPlay);
        Debug.Log(lastTimestampPlay);
    }

    static DateSyncronization() {
        EditorApplication.wantsToQuit += LeaveGame;
        EditorApplication.quitting += QuitGame;
    }
}
