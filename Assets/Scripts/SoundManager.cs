using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }

    //SoundFX
    [SerializeField] AudioSource dropItemSound, pickupaudioSoud, stepsSound;

    //Music
    [SerializeField] AudioSource startingZoneBGMusic;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlayDropSound()
    {
        if (!dropItemSound.isPlaying)
            dropItemSound.Play();
    }
    public void PlayPickupSound()
    {
        if (!pickupaudioSoud.isPlaying)
            pickupaudioSoud.Play();
    }
    public void PlayStepsSound()
    {
        if (!stepsSound.isPlaying &&ThirdHeroMovment.walking)
        {
            stepsSound.Play();
            stepsSound.loop = true;
        }
        else if(!ThirdHeroMovment.walking)
        {
            stepsSound.loop = false;
            stepsSound.Stop();
        }


    }

}
