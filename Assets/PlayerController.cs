using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController uwu;
    public float camAngle;
    public float maxCameraAngle = 40;

    public float moveSpeed = 3;
    public float turnSpeed = 300;

    public Camera pov;
    // Start is called before the first frame update
    void Start()
    {
        uwu = GetComponent<CharacterController>();
        pov = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
    }
    struct PlayerInput
    {
        public Vector2 move;
        public Vector2 rotation;
    }

    // Update is called once per frame
    void Update()
    {
        var input = new PlayerInput();



        input.move = Inman.I.left;
        input.rotation = Inman.I.right;

        var move = moveSpeed*(transform.forward * input.move.y + transform.right * input.move.x);
        var rotX = input.rotation.x * Time.deltaTime * turnSpeed;
        var rotY = input.rotation.y * Time.deltaTime * turnSpeed;


        transform.Rotate(0, rotX, 0);

        camAngle = Mathf.Clamp(camAngle - rotY, -maxCameraAngle, maxCameraAngle);


        var rot = pov.transform.localEulerAngles;
        rot.x = camAngle;
        pov.transform.localEulerAngles = rot;

        uwu.SimpleMove(move);
    }
}
