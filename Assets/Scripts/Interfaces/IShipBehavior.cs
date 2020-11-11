using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShipBehavior
{
    void DisEmbark(int index);
    void Embark(Transform obj);
    void Embark(List<Transform> mobs);
}
