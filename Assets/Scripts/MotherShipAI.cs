using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipAI : MonoBehaviour
{
    MotherShip mother;

    bool enemy = true;
    float elapsedTime = 0;

    private void Start()
    {
        mother = GetComponent<MotherShip>();
    }

    void Update()
    {
        if (mother.isAlive == false || !GameManager.Instance.playing)
            return;
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= GameManager.Instance.SpawnTime)
        {
            elapsedTime = 0;
            int rand = Random.Range(0, 3);
            mother.line = rand;

            int unitrand = Random.Range(0, 101);

            if(unitrand < 50)
                ObjectPool.InstantiateMob<Unit>(mother, mother.stat.enemy, Define.MobType.One);
            else if(unitrand < 70)
                ObjectPool.InstantiateMob<Unit>(mother, mother.stat.enemy, Define.MobType.Two);
            else if(unitrand < 80)
                ObjectPool.InstantiateMob<Unit>(mother, mother.stat.enemy, Define.MobType.Three);
            else if(unitrand < 95)
                ObjectPool.InstantiateMob<Unit>(mother, mother.stat.enemy, Define.MobType.Four);
            else if(unitrand <= 100)
                ObjectPool.InstantiateMob<Unit>(mother, mother.stat.enemy, Define.MobType.Five);
        }
    }
}
