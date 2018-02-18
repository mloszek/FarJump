using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingAround : MonoBehaviour {

    public GameObject centerObject;
    [SerializeField] bool clockwise;
    public int speed;

    private Vector3 orientation;

    void Start()
    {
        if (clockwise)
        {
            orientation = Vector3.up;
        }
        else
        {
            orientation = Vector3.down;
        }
    }

	void Update () {
        transform.RotateAround(centerObject.transform.position, orientation, speed * Time.deltaTime);
	}
}
