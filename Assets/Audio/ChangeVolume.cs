using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider master;
    [SerializeField] private Slider sfx;
    [SerializeField] private Slider music;

    private void Start()
    {
        master.value = AudioManager.Instance.master;
        sfx.value = AudioManager.Instance.sfx;
        music.value = AudioManager.Instance.music;
        audioMixer.SetFloat("Master", master.value);
        audioMixer.SetFloat("SFX", master.value);
        audioMixer.SetFloat("Music", master.value);
    }

    public void SetMaster()
    {
        audioMixer.SetFloat("Master", master.value);
        AudioManager.Instance.master = master.value;
    }

    public void SetSFX()
    {
        audioMixer.SetFloat("SFX", sfx.value);
        AudioManager.Instance.sfx = sfx.value;
    }

    public void SetMusic()
    {
        audioMixer.SetFloat("Music", music.value);
        AudioManager.Instance.music = music.value;
    }
}
