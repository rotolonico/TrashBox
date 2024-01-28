using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    
    public AudioClip[] audioClips;
    
    public void PlaySound(int index, bool loop = false)
    {
        if (index < 0 || index >= audioClips.Length)
            return;
        
        audioSource.clip = audioClips[index];
        audioSource.loop = loop;
        audioSource.Play();
    }
}
