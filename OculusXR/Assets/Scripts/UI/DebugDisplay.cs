using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebugDisplay : MonoBehaviour
{
    //Dictionary<string, string> debugLogs = new Dictionary<string, string>();
    private List<string> debugLogs = new List<string>();

    public TextMeshProUGUI display;

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    //void HandleLog(string logString, string stackTrace, LogType type)
    //{
    //    if (type == LogType.Log)
    //    {
    //        string[] splitString = logString.Split(char.Parse(":"));
    //        string debugKey = splitString[0];
    //        string debugValue = splitString.Length > 1 ? splitString[1] : "";

    //        if (debugLogs.ContainsKey(debugKey))
    //            debugLogs[debugKey] = debugValue;
    //        else
    //            debugLogs.Add(debugKey, debugValue);
    //    }

    //    string displayText = "";
    //    foreach (KeyValuePair<string, string> log in debugLogs)
    //    {
    //        if (log.Value == "")
    //            displayText += log.Key + "\n";
    //        else
    //            displayText += log.Key + ": " + log.Value + "\n";
    //    }

    //    display.text = displayText;
    //}

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        // Add the log message to the list
        debugLogs.Add(logString);

        // Update the display text
        UpdateDisplay();
    }

    // Method to update the display text
    void UpdateDisplay()
    {
        string displayText = "";
        foreach (string log in debugLogs)
        {
            displayText += log + "\n";
        }
        display.text = displayText;
    }
}
