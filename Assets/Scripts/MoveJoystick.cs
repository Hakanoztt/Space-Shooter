using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyJoystick;

public class MoveJoystick : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    public float speed;

    Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 joyVec =new Vector3 (joystick.Horizontal(),0,joystick.Vertical());


        rigidbody.velocity = joyVec * speed;
    }
}
