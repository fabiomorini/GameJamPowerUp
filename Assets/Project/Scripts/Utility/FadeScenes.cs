using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeScenes : MonoBehaviour
{
    public Animator animator;

    public void PlayLevel()
    {
        StartCoroutine(PlayGame());
    }

    public IEnumerator PlayGame()
    {
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1.0f);
    }
}
