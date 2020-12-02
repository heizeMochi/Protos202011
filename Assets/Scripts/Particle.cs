using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class Particle : MonoBehaviour
{
    public ParticleSystem par;

    private void Start()
    {
        Invoke("Loop", 2f);
    }

    void Loop()
    {
        par.Stop();
    }
}
