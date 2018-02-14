using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour {

	void Update ()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Application.Quit();
        }

    }
}
