using Microsoft.Mixer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inman : MonoBehaviour
{
    public string username;
    public Vector2 left;
    public Vector2 right;
    public bool a;
    public bool b;
    public string sessionId = null;

    public const string LeftStick = "LeftStick";
    public const string RightStick = "RightStick";
    public const string AButton = "A";
    public const string BButton = "B";
    public void Start()
    {
        MixerInteractive.GoInteractive();
        InteractivityManager.SingletonInstance.OnInteractiveJoystickControlEvent += OnInteractiveJoystickControlEvent;
        InteractivityManager.SingletonInstance.OnInteractiveButtonEvent += OnInteractiveButtonEvent;
    }

    private void OnInteractiveButtonEvent(object sender, InteractiveButtonEventArgs e)
    {
        print(e);
        if (e.Participant.SessionID != sessionId)
            return;
        var value = e.IsPressed;
        if (e.ControlID == AButton)
        {
            a = value;
        }
        if (e.ControlID == BButton)
        {
            b = value;
        }
    }

    
    private void OnInteractiveJoystickControlEvent(object sender, InteractiveJoystickEventArgs e)
    {
        if (e.Participant.SessionID != sessionId)
            return;
        var value = new Vector2((float)e.X, (float)e.Y);

        if(e.ControlID == LeftStick)
            left = value;
        if (e.ControlID == RightStick)
            right = value;
    }

    // Update is called once per frame
    public static void Update()
    {
        

    }
}
