using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Animator camAnim;
    [SerializeField] private AudioClip burnAudio = null;
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
        audioSource.PlayOneShot(burnAudio, 1.0f);
    }

}
