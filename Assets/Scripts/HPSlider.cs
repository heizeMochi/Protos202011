using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    public MobData target;
    Slider slider;
    float up;

    private void Start()
    {
        Transform parent = GameObject.Find("Canvas").transform;
        transform.SetParent(parent);
        transform.localScale = Vector3.one;
        slider = GetComponent<Slider>();
    }

    public void Init(MobData data, float _up)
    {
        target = data;
        up = _up;
    }

    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(target.transform.position);
        transform.position = target.transform.position + (Vector3.up * up);

        slider.maxValue = target.MaxHP;
        slider.value = target.HP;
    }
}
