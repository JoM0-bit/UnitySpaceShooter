using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _AudioSource;


    // Start is called before the first frame update
    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();

        if (_AudioSource == null)
        {
            Debug.LogError("Audio Source NULL");
        }
        else
        {
            //_AudioSource.clip = _explosionClip;
        }
    }


    public void explosion()
    {
        _AudioSource.Play();
    }
}
