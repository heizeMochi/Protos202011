using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource backGround;
    public AudioSource sound;

    public float effectSound = 1f;
    public float backGroundSound = 1f;

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
            backGround.loop = true;
        }
    }

    void SoundLoad(string Path = "Sound/Sfx/")
    {
        AudioClip[] audio = Resources.LoadAll<AudioClip>(Path);

        for (int i = 0; i < audio.Length; i++)
        {
            soundList.Add(audio[i].name, audio[i]);
        }
    }

    public void SoundPlay(string name)
    {
        if (GameManager.instance.playing)
        {
            GameObject go = new GameObject("Sound");
            sound = go.AddComponent<AudioSource>();
            sound.volume = effectSound;

            sound.clip = soundList[name];
            sound.Play();

            Destroy(go, soundList[name].length);
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        BackGroundLoad();
        BackGroundPlay("Blackmoor_Tides_Loop");
        SoundLoad();
    }

    private void Update()
    {
        backGround.volume = backGroundSound;
    }
}