using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class JumpControllerScript : MonoBehaviour {

    public FirstPersonController controller;
    public Rigidbody rdgbd;

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            SwitchGravity();
        }
    }

    void SwitchGravity()
    {
        controller.m_GravityMultiplier = controller.m_GravityMultiplier == 0f ? 2f : 0;
        rdgbd.useGravity = rdgbd.useGravity == true ? false : true;
    }

}
