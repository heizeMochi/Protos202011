using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource backGround;
    public AudioSource sound;

    static Dictionary<string, AudioClip> backGroundList = new Dictionary<string, AudioClip>();
    static Dictionary<string, AudioClip> soundList = new Dictionary<string, AudioClip>();

    void BackGroundLoad(string Path = "Sound/BackGround/")
    {
        AudioClip[] audio = Resources.LoadAll<AudioClip>(Path);

        for (int i = 0; i < audio.Length; i++)
        {
            backGroundList.Add(audio[i].name, audio[i]);
        }
    }

    void BackGroundPlay(string name)
    {
        if(backGroundList.ContainsKey(name))
        {
            backGround.clip = backGroundList[name];
            backGround.Play();
        }
    }

    void SoundLoad(string Path = "Sound/Sound/")
    {
        AudioClip[] audio = Resources.LoadAll<AudioClip>(Path);

        for (int i = 0; i < audio.Length; i++)
        {
            soundList.Add(audio[i].name, audio[i]);
        }
    }

    public void SoundPlay(string name)
    {
        GameObject go = new GameObject("Sound");
        AudioSource source = go.AddComponent<AudioSource>();

        source.clip = soundList[name];
        source.Play();

        Destroy(go, soundList[name].length);
    }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        BackGroundLoad();
        SoundLoad();
    }
}