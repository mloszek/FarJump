using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreHolderScript : MonoBehaviour {

    public static ScoreHolderScript instance = null;
    public System.Diagnostics.Stopwatch stopwatch;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
        }
    }

	void Start () {
        stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        DontDestroyOnLoad(gameObject);
	}

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "ScoreScene")
        {
            stopwatch.Stop();
            System.TimeSpan timeSpan = stopwatch.Elapsed;
            GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>().text = string.Format("your time: {0:00}:{1:00}:{2:00}.{3:00}",
            timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds,
            timeSpan.Milliseconds / 10);
        }
    }
}
