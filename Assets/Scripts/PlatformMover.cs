using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{

    private float speed = 0;
    private enum MovingDirection
    {
        LEFT,
        RIGHT
    }
    private MovingDirection activeDirection;

    void Awake()
    {
        activeDirection = MovingDirection.LEFT;
    }

    public void SetSpeed(float newValue)
    {
        speed = newValue;
    }

    void Update()
    {
        if (activeDirection == MovingDirection.LEFT)
        {
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed);
            if (gameObject.transform.position.z >= 0)
            {
                activeDirection = MovingDirection.RIGHT;
            }
        }
        else
        {
            gameObject.transform.Translate(Vector3.back * Time.deltaTime * speed);
            if (gameObject.transform.position.z <= -31)
            {
                activeDirection = MovingDirection.LEFT;
            }
        }
    }
}
