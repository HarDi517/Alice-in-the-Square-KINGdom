using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamItem3 : MonoBehaviour
{//플라밍고2 목 꺾이는 아이템
    
    public HingeJoint2D hinge;
    public Animator item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            item.SetTrigger("item");
        }
        //JointMotor2D motor = hinge.motor;

        //if (collision.CompareTag("Player"))
        //{
        //    hinge.useMotor = true;
        //    motor.motorSpeed = -100f;
        //    gameObject.SetActive(false);
        //}
    }
}
