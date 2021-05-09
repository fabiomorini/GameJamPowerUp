using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject credits;
    public GameObject buttons;


    public void Exit()
    {
        Application.Quit();
    }

    public void PlayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Credits()
    {
        buttons.SetActive(false);
        credits.SetActive(true);
    }
    public void Return()
    {
        buttons.SetActive(true);
        credits.SetActive(false);
    }
}