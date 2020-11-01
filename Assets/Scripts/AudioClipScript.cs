using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipScript : MonoBehaviour
{
    private static AudioClipScript instance = null;
    public static AudioClipScript Instance { get { return instance; } }

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Play();
    }
    public void Play()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
    public void Stop()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
