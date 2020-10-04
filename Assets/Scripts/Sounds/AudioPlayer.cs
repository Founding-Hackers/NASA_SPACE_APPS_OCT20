using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] List<AudioClip> soundBank = new List<AudioClip>();

    public void PlaySound()
    {
        AudioManager.Instance.PlaySFX(
            soundBank[Random.Range(0, soundBank.Count)]
            );
    }
}
