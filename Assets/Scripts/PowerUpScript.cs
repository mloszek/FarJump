using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {

    private AudioSource source;
    private MeshCollider mCollider;
    private MeshRenderer mRenderer;

    void OnEnable()
    {
        source = GetComponent<AudioSource>();
        mCollider = GetComponent<MeshCollider>();
        mRenderer = GetComponent<MeshRenderer>();
    }

    void FixedUpdate()
    {
        gameObject.transform.RotateAround(gameObject.transform.position, Vector3.up, 30 * Time.deltaTime * 2);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.SendMessage("ReplenishAntigravity");
            StartCoroutine(PowerUpLifecycle());
        }
    }

    IEnumerator PowerUpLifecycle()
    {
        mCollider.enabled = false;
        mRenderer.enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        source.Play();
        yield return new WaitForSeconds(10f);
        mCollider.enabled = true;
        mRenderer.enabled = true;
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
