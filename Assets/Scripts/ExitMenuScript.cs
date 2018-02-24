using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitMenuScript : MonoBehaviour {

    public Text text;

    private bool isTextShown = false;

    void Start()
    {
        text.gameObject.SetActive(false);
    }
	
	void Update ()
    {
        if (Input.GetKeyDown("escape"))
        {
            text.gameObject.SetActive(text.gameObject.activeInHierarchy == false ? true : false);
        }

        if (Input.GetKeyDown("n"))
        {
            if (text.gameObject.activeInHierarchy == true)
            {
                text.gameObject.SetActive(false);
            }
        }

        if (Input.GetKeyDown("y"))
        {
            if (text.gameObject.activeInHierarchy == true)
            {
                SceneManager.LoadScene("titleScene");
            }
        }
    }
}
