using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChange : MonoBehaviour
{
    public Slider BGM;
    public Slider Sound;
    private void Start()
    {
        BGM.value = AudioManager.instance.backGroundSound;
        Sound.value = AudioManager.instance.effectSound;
    }
    private void Update()
    {
        AudioManager.instance.backGroundSound = BGM.value;
        AudioManager.instance.effectSound = Sound.value;
    }
}
