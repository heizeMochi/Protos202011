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

            int unitrand = Random.Range(0, 5);


            switch (unitrand)
            {
                case 0:
                    ObjectPool.InstantiateMob<UnitOne>(mother, enemy);
                    break;
                case 1:
                    ObjectPool.InstantiateMob<UnitTwo>(mother, enemy);
                    break;
                case 2:
                    ObjectPool.InstantiateMob<UnitThree>(mother, enemy);
                    break;
                case 3:
                    ObjectPool.InstantiateMob<UnitFour>(mother, enemy);
                    break;
                case 4:
                    ObjectPool.InstantiateMob<UnitFive>(mother, enemy);
                    break;
            }
        }
    }
}
