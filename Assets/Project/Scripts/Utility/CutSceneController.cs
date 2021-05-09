using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneController : MonoBehaviour
{
    private bool garsa = false;
    private bool drac = false;

    private void Start()
    {
        garsa = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().garsaScene;
        drac = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().dracScene;

        if(garsa)
        {
            GameObject.Find("GarsaCutScene").SetActive(true);
        }
        else
        {
            GameObject.Find("GarsaCutScene").SetActive(false);
        }

        if (drac)
        {
            GameObject.Find("DracCutScene").SetActive(true);
        }
        else
        {
            GameObject.Find("DracCutScene").SetActive(false);
        }
    }
}
