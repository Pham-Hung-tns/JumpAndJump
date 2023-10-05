using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip soundCat;
    // Start is called before the first frame update
    public void playMusic()
    {
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    public void pauseMusic()
    {
        GetComponent<AudioSource>().Pause();
    }
    public void stopMusic()
    {
        GetComponent<AudioSource>().Stop();
    }
}
