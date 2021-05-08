using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject main = null;
    public GameObject credits = null;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        bool escape = Input.GetButtonDown("Cancel");

        if (escape)
        {
            if (main.activeSelf)
            {
                ExitGame();
            }
            else if(credits.activeSelf)
            {
                ToggleCredits();
            }
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ToggleCredits()
    {
        if (main != null && credits != null)
        {
            if (main.activeSelf)
            {
                main.SetActive(false);
                credits.SetActive(true);
            }
            else
            {
                credits.SetActive(false);
                main.SetActive(true);
            }
        }
    }

}
