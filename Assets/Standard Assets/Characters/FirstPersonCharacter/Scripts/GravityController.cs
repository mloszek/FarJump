using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour {

    public delegate void OnClickAction();
    public static event OnClickAction OnClick;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            OnClick();
        }
    }
}
