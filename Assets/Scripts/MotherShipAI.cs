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
        if (mother.isAlive == false || !GameManager.instance.playing)
            return;
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= spawnTime)
        {
            elapsedTime = 0;
            int rand = Random.Range(0, 3);
            mother.line = rand;

            int unitrand = Random.Range(0, 101);

            if(unitrand < 50)
                ObjectPool.InstantiateMob<UnitOne>(mother, enemy);
            else if(unitrand < 75)
                ObjectPool.InstantiateMob<UnitTwo>(mother, enemy);
            else if(unitrand < 90)
                ObjectPool.InstantiateMob<UnitThree>(mother, enemy);
            else if(unitrand < 97)
                ObjectPool.InstantiateMob<UnitFour>(mother, enemy);
            else if(unitrand < 100)
                    ObjectPool.InstantiateMob<UnitFive>(mother, enemy);
        }
    }
}
