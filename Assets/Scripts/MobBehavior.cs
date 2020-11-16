using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (MobData))]

public class MobBehavior : MonoBehaviour
{
    protected MobData myData;
    protected IEnumerator coroutine;
    public bool isExcuting = false;
    public bool isEmbark;
    public bool Enemy = false;

    private void Awake()
    {
        myData = GetComponent<MobData>();
    }
    /// <summary>
    /// 배열 안에서 공격 대상을 찾습니다.
    ///  경고! 미완성된 기능입니다.
    ///  기능 구현 예시로만 사용 해 주시길 바랍니다.
    /// </summary>
    /// <returns>가장 가까운 거리의 적오브젝트와 입력받은 배열의 오브젝트 인덱스 번호를 반환합니다.</returns>
    public Tuple<GameObject, int> FindClosestAttackTarget(List<Transform> list)
    {
        //throw new NotImplementedException();
        if (list.Count == 0 || list is null) return null;

        float distance;
        float closestDistance = float.MaxValue;
        int index = 0;
        int closestItemIndex = 0;
        foreach (var item in list)
        {
            distance = Vector2.Distance(transform.position, item.position);
            if (distance < closestDistance)
            {
                closestItemIndex = index;
            }
            index++;
        }
        return new Tuple<GameObject, int>(list[closestItemIndex].gameObject, closestItemIndex);
    }

    public void AttackTargetSetting()
    {
        Tuple<GameObject, int> tuple = FindClosestAttackTarget(myData.enemyList);

        myData.attackTarget = myData.enemyList[tuple.Item2];
        Debug.Log($"item 1 : {tuple.Item1} \nitem 2 : {myData.enemyList[tuple.Item2]}");
    }


    /*//////////////////////////////////
    /// MOVE
    //////////////////////////////////*/
    public void MoveTo(Transform target)
    {
        if (isExcuting)
        {
            CancelMovement();
        }
        coroutine = Move();
        StartCoroutine(coroutine);
        IEnumerator Move()
        {
            isExcuting = true;
            while (transform.position == target.position)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, myData.moveSpeed*Time.deltaTime);
                yield return null;
            }
            isExcuting = false;
        }
    }
    public void MoveTo(Vector2 target)
    {
        if (isExcuting)
        {
            CancelMovement();
        }
        coroutine = Move();
        StartCoroutine(coroutine);
        IEnumerator Move()
        {
            isExcuting = true;
            myData.state = State.MOVING;
            while ((Vector2)transform.position != target )
            {
                //print("Excuted!");
                transform.position = Vector2.MoveTowards((Vector2)transform.position, target, myData.moveSpeed*Time.deltaTime);
                yield return null;
            }
            myData.state = State.IDLE;
            isExcuting = false;
        }
    }

    public void CancelMovement()
    {
        StopCoroutine(coroutine);
    }
}
