using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGravityScript : MonoBehaviour {

	void OnEnable () {
        Physics.gravity = new Vector3(-20.0f, 0, 0);
	}
}
