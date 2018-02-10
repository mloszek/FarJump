using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

    public Canvas FadeOutScreen;
    public GameObject RespawnPoint;

    private CanvasGroup group;
    private Vector3 initialPosition;

    void OnEnable()
    {
        group = FadeOutScreen.GetComponent<CanvasGroup>();
        initialPosition = RespawnPoint.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(FadeOut(other.gameObject));
        }
    }

   IEnumerator FadeOut(GameObject player)
    {
        while (group.alpha < 1)
        {
            group.alpha += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        
        player.transform.position = initialPosition;
        group.alpha = 0;
    }
}
