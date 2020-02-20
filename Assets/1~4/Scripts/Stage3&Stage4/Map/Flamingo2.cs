using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamingo2 : MonoBehaviour
{//머리 꺾이는 플라밍고

    public HingeJoint2D hinge;

    void Start()
    {
        JointMotor2D motor = hinge.motor;
        hinge.useMotor = true;
        motor.motorSpeed = -100f;
    }

    void Update()
    {

    }
}
