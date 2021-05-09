using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float gameTimer { get; private set; } = 0.0f;
    [SerializeField] private float perfectEnding = 45.0f;
    [SerializeField] private float normalEnding = 60.0f;
    //Booleans
    private bool gotPerfect = false;
    private bool gotNormal = false;
    private bool gotBad = false;
    public bool dracScene { get; private set; } = false;
    public bool garsaScene { get; private set; } = false;

    private bool isTimer = true;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        if (isTimer) gameTimer += Time.deltaTime;
        //Debug.Log("Game Timer: " + gameTimer);

        if (gameTimer <= perfectEnding)
        {
            if (!gotPerfect)
            {
                dracScene = true;
                garsaScene = true;

                gotPerfect = true;
            }
        }
        else if (gameTimer <= normalEnding)
        {
            if (!gotNormal)
            {
                int randomizer = Random.Range(0, 2);
                switch (randomizer)
                {
                    case 0:
                        dracScene = false;
                        garsaScene = true;
                        break;
                    case 1:
                        dracScene = true;
                        garsaScene = false;
                        break;
                    default:
                        dracScene = false;
                        garsaScene = false;
                        Debug.LogError("Hasn't randomized garsa/drac");
                        break;
                }
                gotNormal = true;
            }
        }
        else if (gameTimer > normalEnding)
        {
            if (!gotBad)
            {
                dracScene = false;
                garsaScene = false;
                gotBad = false;
                isTimer = false;

                gotBad = true;
            }
        }
    }

    public void Load()
    {
        GameObject.Find("Fade").GetComponent<FadeScenes>().PlayLevel();
    }
}
