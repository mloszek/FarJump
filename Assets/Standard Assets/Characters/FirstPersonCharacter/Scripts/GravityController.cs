using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityController : MonoBehaviour
{

    public delegate void OnClickAction();
    public static event OnClickAction OnClick;
    public Text antigravityAmount;
    public bool inputLocked;
    public int antigravity;

    private bool isAntigravityWorks;

    void Start()
    {
        isAntigravityWorks = false;
    }

    void Update()
    {
        antigravityAmount.text = antigravity.ToString();

        if (!inputLocked)
        {
            if (Input.GetButtonDown("Fire1") && antigravity > 0)
            {
                isAntigravityWorks = true;
                OnClick();
                StartCoroutine(DrainAntigravity());
            }

            if (Input.GetButtonUp("Fire1") && isAntigravityWorks)
            {
                isAntigravityWorks = false;
                OnClick();
            }
        }
    }

    IEnumerator DrainAntigravity()
    {
        while (antigravity > 0 && isAntigravityWorks)
        {
            antigravity--;
            yield return new WaitForSeconds(0.1f);
        }

        if (antigravity == 0)
        {
            isAntigravityWorks = false;
            OnClick();
            inputLocked = true;
        }
    }

    public void ReplenishAntigravity()
    {
        inputLocked = false;
        if (isAntigravityWorks)
        {
            OnClick();
        }
        isAntigravityWorks = false;
        antigravity = 100;
    }

    public void ResetAntigravityStatus()
    {
        inputLocked = false;
        antigravity = 100;
    }
}
