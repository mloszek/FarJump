using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {

    void FixedUpdate()
    {
        gameObject.transform.RotateAround(gameObject.transform.position, Vector3.up, 30 * Time.deltaTime * 2);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.SendMessage("ReplenishAntigravity");
            Destroy(gameObject);
        }
    }
}
