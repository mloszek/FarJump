using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpawnerScript : MonoBehaviour
{

    public Canvas FadeOutScreen;
    public GameObject RespawnPoint;
    [SerializeField] public Color fadeColor;
    [SerializeField] public string nextScene;

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
        FadeOutScreen.GetComponentInChildren<Image>().color = fadeColor;
        if (gameObject.name == "ExitSpot")
        {
            player.SendMessage("Lock");
        }

        while (group.alpha < 1)
        {
            group.alpha += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }

        if (gameObject.name == "ExitSpot")
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            player.transform.SendMessage("ResetAntigravityStatus");
            player.transform.position = initialPosition;
        }

        group.alpha = 0;
    }
}
