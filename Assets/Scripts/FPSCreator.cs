using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPSCreator : MonoBehaviour
{
    public GameObject FPS;
    private GameObject RespawnPoint;

    void OnEnable()
    {
        RespawnPoint = GameObject.FindWithTag("Respawn");
        var ThisSceneFPS = Instantiate(FPS, RespawnPoint.transform.position, RespawnPoint.transform.rotation);

        if (SceneManager.GetActiveScene().name == "1stLevel")
        {
            Component gravityController = ThisSceneFPS.GetComponent<GravityController>();
            Destroy(gravityController);
            ThisSceneFPS.transform.GetChild(1).transform.gameObject.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "2ndLevel")
        {
            ThisSceneFPS.GetComponent<GravityController>().SetAntigravity(0);
        }
    }
}
