using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour
{
    public Rigidbody rigidbody;
    public AudioClip acceleratingAudio;
    public AudioClip constantSpeedAudio;
    public AudioSource audioSource;

    public float maxVolume = 0.65f;
    public float deltaVolume = 0.02f;

    private float minVolume = 0.1f;

    private enum SoundState
    {
        ACCELERATING,
        MAINTAINING,
        NO_SOUND
    }

    private SoundState soundState = SoundState.NO_SOUND;
    private Vector3 prevVelocity = Vector3.zero;
    private Vector3 currVelocity = Vector3.zero;

    void Start()
    {
        audioSource.volume = 0.0f;
        audioSource.clip = acceleratingAudio;
        audioSource.Play();
    }

    public void IncreaseVolume()
    {
        if (audioSource.volume >= maxVolume)
            return;

        audioSource.volume += deltaVolume;
    }

    public void DecreaseVolume()
    {
        if (audioSource.volume <= minVolume)
            return;

        audioSource.volume -= (6 * deltaVolume);
    }

}
