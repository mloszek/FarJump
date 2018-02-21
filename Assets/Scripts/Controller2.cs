using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2 : MonoBehaviour
{
    public Mesh mesh;
    public Material material;
    public int iteration;
    public float childScale;

    private int currentIteration;

    private static Vector3[] childDirections = {
        Vector3.up,
        Vector3.right,
        Vector3.left,
        Vector3.forward,
        Vector3.back,
        Vector3.down
    };

    private static Quaternion[] childOrientations = {
        Quaternion.identity,
        Quaternion.Euler (0f, 0f, -90f),
        Quaternion.Euler (0f, 0f, 90f),
        Quaternion.Euler (90f, 0f, 0f),
        Quaternion.Euler (-90f, 0f, 0f),
        Quaternion.Euler (-180f, 0f, 0f),
    };

    private void Start()
    {
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;

        if (currentIteration < iteration)
        {
            StartCoroutine(CreateChildren());
        }
    }

    private IEnumerator CreateChildren()
    {
        var currentLength = currentIteration == 0 ? 6 : 5;

        for (int i = 0; i < currentLength; i++)
        {
            yield return null;
            GameObject child = new GameObject("Child Object");
            child.AddComponent<Controller2>().Initialize(this, i);
            child.AddComponent<RotatorScript>();
            if (i == 5)
                child.GetComponent<RotatorScript>().speed *= 2;
        }
    }

    private void Initialize(Controller2 parent, int childIndex)
    {
        mesh = parent.mesh;
        material = parent.material;
        iteration = parent.iteration;
        currentIteration = parent.currentIteration + 1;
        childScale = parent.childScale;
        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition = childDirections[childIndex] * (0.5f + 0.5f * childScale);
        transform.localRotation = childOrientations[childIndex];
    }
}
