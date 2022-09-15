using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;


    private AudioSource _source;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }

        _source = GetComponent<AudioSource>();
        if (_source == null)
        {
            _source = gameObject.AddComponent<AudioSource>();
            _source.playOnAwake = false;
            _source.loop = false;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        _source.PlayOneShot(clip);
    }

}
