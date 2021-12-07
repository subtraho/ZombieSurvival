using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSounds : MonoBehaviour
{
    public List<AudioSource> zombieAudio = new List<AudioSource>();

    private float soundTimer;
    private int randomInt;

    private void Update()
    {
        soundTimer += Time.deltaTime;

        if(soundTimer >= 8f)
        {
            randomInt = Random.Range(0, zombieAudio.Count);
            zombieAudio[randomInt].Play();
            soundTimer = 0f;
        }
    }
}
