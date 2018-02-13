using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreHolderScript : MonoBehaviour {

    public System.Timers.Timer timer;

	void Start () {
        timer = new System.Timers.Timer();
        timer.Start();
        DontDestroyOnLoad(gameObject);
	}

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "ScoreScene")
        {
            timer.Stop();
            GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>().text = timer.ToString();
        }
    }
}
