using Lowscope.Saving;
using Microsoft.Mixer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inman : MonoBehaviour
{
    public static Inman I;
    public string username;
    public Vector2 left;
    public Vector2 right;
    
    public bool a;
    public bool b;
    public bool x;


    public string sessionId = null;

    public float joinTime;

    public bool HasPlayer => !string.IsNullOrEmpty(sessionId);


    public const string LeftStick = "LStick";
    public const string RightStick = "RStick";
    public const string AButton = "A";
    public const string BButton = "B";
    public const string XButton = "X";


    public const string JoinButton = "join";
    public const string LeaveButton = "leave";

    
    private InteractiveScene controlsScene;

    public void Start()

    {
        I = this;
        MixerInteractive.GoInteractive();
        InteractivityManager.SingletonInstance.OnInteractiveJoystickControlEvent += OnInteractiveJoystickControlEvent;
        InteractivityManager.SingletonInstance.OnInteractiveButtonEvent += OnInteractiveButtonEvent;
        InteractivityManager.SingletonInstance.OnInteractiveMessageEvent += SingletonInstance_OnInteractiveMessageEvent;
        InteractivityManager.SingletonInstance.OnParticipantStateChanged += SingletonInstance_OnParticipantStateChanged;
    }

    private void SingletonInstance_OnParticipantStateChanged(object sender, InteractiveParticipantStateChangedEventArgs e)
    {
        if (e.State == InteractiveParticipantState.Left || e.State == InteractiveParticipantState.InputDisabled)
            RelinquishControl(e.Participant);
    }

    private void SingletonInstance_OnInteractiveMessageEvent(object sender, InteractiveMessageEventArgs @event)
    {

        //print("uwu " + e.EventType + " " + e.Message);


        var save =
            Newtonsoft.Json.JsonConvert.DeserializeObject <UwuJson>(@event.Message);

        if (save.method == "giveInput") {
            var p = save.Params;
            if (p?.participantID != sessionId)
                return;

            // p?.input?._event != "controller"
            //print("nmn " + @event.Message);
            var e = p.input.param;
            if (e == null)
                return;

            var stickValue = new Vector2(e.x??0, -e.y??0);
            var buttonValue = e.value == 1;
            if (e.ControlID == LeftStick)
                left = stickValue;
            if (e.ControlID == RightStick)
                right = stickValue;

            if (e.ControlID == AButton)
            {
                a = buttonValue;
            }
            if (e.ControlID == BButton)
            {
                b = buttonValue;
            }

            if (e.ControlID == XButton)
            {
                x = buttonValue;
            }

        }
    }

    InteractiveParticipant participant;

    public float playTime = 300;

    private void OnInteractiveButtonEvent(object sender, InteractiveButtonEventArgs e)
    {
        var participant = e.Participant;
        if (e.ControlID == JoinButton && (!HasPlayer || Time.time - joinTime >= playTime ))
        {
            GiveControl(participant);
        }

        if (e.Participant.SessionID != sessionId)
            return;
        var value = e.IsPressed;

        if (e.ControlID == LeaveButton)
        {
            RelinquishControl(participant);
        }
        //if (e.ControlID == AButton)
        //{
        //    a = value;
        //}
        //if (e.ControlID == BButton)
        //{
        //    b = value;
        //}
    }

    private void RelinquishControl(InteractiveParticipant participant = null)
    {
        var group = InteractivityManager.SingletonInstance.GetGroup("default");
        (participant??this.participant).Group = group;
        sessionId = null;
        SaveMaster.SyncSave();
    }

    private void GiveControl(InteractiveParticipant participant)
    {
        
        var group = InteractivityManager.SingletonInstance.GetGroup("controlling");
        participant.Group = group;
        SaveMaster.SyncSave();

        this.participant = participant;
        sessionId = participant.SessionID;
        username = participant.UserName ?? "user";
    }

    [System.Serializable]
    public class UwuJson
    {
        public string type;
        public string method;
        public Params Params { get; set; }
        public int id;
        public int seq;
        public bool discard;
    }

    [System.Serializable]
    public class Params
    {
        public string participantID;
        public Input input;
    }

    [System.Serializable]
    public class Input
    {
        public string _event;
        public Param param;
        public string controlID;
    }

    [System.Serializable]
    public class Param
    {
        public string _event;
        public float? x;
        public float? y;
        public int? value;
        public string button;

        public string ControlID { get; set; }
    }

    private void OnInteractiveJoystickControlEvent(object sender, InteractiveJoystickEventArgs e)
    {
        joinTime = Time.time;
        if (e.Participant.SessionID != sessionId)
            return;
    }

    // Update is called once per frame
    public static void Update()
    {


    }
}
