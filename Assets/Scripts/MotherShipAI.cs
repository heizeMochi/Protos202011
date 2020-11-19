using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipAI : MonoBehaviour
{
    MotherShip mother;

    bool enemy = true;
    float elapsedTime = 0;
    float spawnTime = 2f;

    private void Start()
    {
        mother = GetComponent<MotherShip>();
    }

    void Update()
    {
        if (mother.isAlive == false)
            return;
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= spawnTime)
        {
            elapsedTime = 0;
            int rand = Random.Range(0, 3);
            mother.line = rand;
            ObjectPool.InstantiateMob<ChildShip>(mother, enemy);
        }
    }
}
