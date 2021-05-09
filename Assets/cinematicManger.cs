using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cinematicManger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SkipCinematic());
    }

    private IEnumerator SkipCinematic()
    {
        yield return new WaitForSeconds(31.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
