using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    public AudioSource audioSource;
    public List<AudioClip> bgms;
 
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBgm1Min(int idx=0)
    {
        audioSource.clip = bgms[idx];
        audioSource.Play();

    }

    public void StopBgm()
    {
        audioSource.Pause();
    }
    public void AudioPlay(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}