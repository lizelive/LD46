/*
 * Mixer Unity SDK
 *
 * Copyright (c) Microsoft Corporation
 * All rights reserved.
 *
 * MIT License
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this
 * software and associated documentation files (the "Software"), to deal in the Software
 * without restriction, including without limitation the rights to use, copy, modify, merge,
 * publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
 * to whom the Software is furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or
 * substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
 * PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
 * FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
 * OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
 * DEALINGS IN THE SOFTWARE.
 */
using Microsoft.Mixer;
using UnityEngine;

namespace MixerInteractiveExamples
{
    public class ControlCharacter : MonoBehaviour
    {
        public float speed;
        public float turnSpeed = 200;

        private string participantID;
        public const string Move = "LeftStick";
        public const string Spin = "RightStick";

        public CharacterController uwu;
        public Camera pov;

        // Use this for initialization
        void Start()
        {
            MixerInteractive.GoInteractive();

            uwu = GetComponent<CharacterController>();
            pov = GetComponentInChildren<Camera>();
        }
        public float maxCameraAngle = 45;


public float camAngle = 0;

        // Update is called once per frame
        void Update()
        {
            foreach (var player in MixerInteractive.Participants)
            {
                var participantID = player.SessionID;
                var move = (float)InteractivityManager.SingletonInstance.GetJoystick(Move).GetY(participantID);

                var rotX = (float)InteractivityManager.SingletonInstance.GetJoystick(Spin).GetX(participantID)* Time.deltaTime* turnSpeed;

                var rotY = (float)InteractivityManager.SingletonInstance.GetJoystick(Spin).GetY(participantID)* Time.deltaTime* turnSpeed;


                transform.Rotate(0, rotX , 0);

                camAngle= Mathf.Clamp(camAngle + rotY, -maxCameraAngle, maxCameraAngle);

                
                var rot = pov.transform.localEulerAngles;
                rot.x = camAngle;
                pov.transform.localEulerAngles = rot;

               //var nope =  rot.x.CompareTo(sbyte.MaxValue).ToString()??"uwu whats that".ToLowerInvariant().TrimStart();


                //print($"rot {rotation} move {move} {x}");
                uwu.SimpleMove(transform.forward * move * speed);
            }

        }
    }
}
