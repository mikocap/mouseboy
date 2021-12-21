using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioMixer MUSIC;
    bool isIdle = false;
    bool isWalking = false;
    bool isRunning = false;
    public GameObject character;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = character.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetFloat("Speed") == 0)
        {
            isIdle = true;
        }
        else
        {
            isIdle = false;
        }
        if (animator.GetFloat("Speed") > 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        if (animator.GetFloat("Speed") <= 6 && animator.GetFloat("Speed") > 2)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        if (PickUp.isHolding == true)
        {
            MUSIC.SetFloat("HoldingVolume", 0f);
        }
        else
        {
            MUSIC.SetFloat("HoldingVolume", -80f);
        }
        if (SitOn.isSitting == true)
        {
            MUSIC.SetFloat("SittingVolume", 0f);
        }
        else
        {
            MUSIC.SetFloat("SittingVolume", -80f);
        }
        if (isWalking == true)
        {
            MUSIC.SetFloat("WalkingVolume", 0f);
        }
        else
        {
            MUSIC.SetFloat("WalkingVolume", -80f);
        }
        if (isRunning == true)
        {
            MUSIC.SetFloat("RunningVolume", 0f);
        }
        else
        {
            MUSIC.SetFloat("RunningVolume", -80f);
        }
        if (isIdle == true && SitOn.isSitting == false)
        {
            MUSIC.SetFloat("IdleVolume", 0f);
        }
        else
        {
            MUSIC.SetFloat("IdleVolume", -80f);
        }
        if (Talk.isTalking == true)
        {
            MUSIC.SetFloat("TalkingVolume", 0f);
        }
        else
        {
            MUSIC.SetFloat("TalkingVolume", -80f);
        }

    }
}
