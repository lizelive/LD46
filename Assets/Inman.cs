using Microsoft.Mixer;
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
    public string sessionId = null;

    public const string LeftStick = "LStick";
    public const string RightStick = "RStick";
    public const string AButton = "A";
    public const string BButton = "B";

    public const string JoinButton = "join";


    private InteractiveScene controlsScene;

    public void Start()

    {
        I = this;
        MixerInteractive.GoInteractive();
        InteractivityManager.SingletonInstance.OnInteractiveJoystickControlEvent += OnInteractiveJoystickControlEvent;
        InteractivityManager.SingletonInstance.OnInteractiveButtonEvent += OnInteractiveButtonEvent;
        InteractivityManager.SingletonInstance.OnInteractiveMessageEvent += SingletonInstance_OnInteractiveMessageEvent;
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
            print("nmn " + @event.Message);
            var e = p.input.param;
            if (e == null)
                return;

            var stickValue = new Vector2(e.x??0, e.y??0);
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

        }
    }

    private void OnInteractiveButtonEvent(object sender, InteractiveButtonEventArgs e)
    {
        print($"b {e.ControlID}");

        var participant = e.Participant;
        if (e.ControlID == JoinButton)
        {
            print("join it good");

            GiveControl(participant);
        }

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

    private void GiveControl(InteractiveParticipant participant)
    {
        var group = InteractivityManager.SingletonInstance.GetGroup("controlling");
        participant.Group = group;

        //controlID: "crowdController"



        sessionId = participant.SessionID;


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

        print($"j {e.ControlID}");
        if (e.Participant.SessionID != sessionId)
            return;
    }

    // Update is called once per frame
    public static void Update()
    {


    }
}
