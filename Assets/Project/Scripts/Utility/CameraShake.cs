using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Animator camAnim;
    public AudioClip[] burnAudio;
    private AudioSource audioSource;

    private void Start()
    {
        camAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void CamShake()
    {
        camAnim.SetTrigger("Shake");
    }

    public void Return()
    {
        camAnim.SetTrigger("Return");
    }

    public void BurnSound()
    {
        int random = Random.Range(0, 4);
        audioSource.PlayOneShot(burnAudio[random], 2.0f);
    }
}
