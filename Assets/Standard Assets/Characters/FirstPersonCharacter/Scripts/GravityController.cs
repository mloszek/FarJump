using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityController : MonoBehaviour
{

    public delegate void OnClickAction();
    public static event OnClickAction OnClick;
    public Text antigravityAmount;

    int antigravity;

    private CharacterController m_CharacterController;
    private bool isAntigravityWorks;
    private bool inputLocked;

    void Start()
    {
        antigravity = 100;
        m_CharacterController = GetComponent<CharacterController>();
        isAntigravityWorks = false;
        inputLocked = false;
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

            if (Input.GetButtonUp("Fire1"))
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
}
