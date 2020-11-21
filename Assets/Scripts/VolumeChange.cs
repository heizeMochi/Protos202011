using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChange : MonoBehaviour
{
    public Slider BGM;
    public Slider Sound;

    private void Update()
    {
        AudioManager.instance.backGroundSound = BGM.value;
        AudioManager.instance.effectSound = Sound.value;
    }
}
