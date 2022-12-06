using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Synchronization : MonoBehaviour
{
    public VideoPlayer player;
    public AudioSource audiosrc;
    private bool played = false;
    void Update()
    {
        if (player.isPlaying && !played)
        {
            played = true;
            audiosrc.Play();
        }
    }
}
