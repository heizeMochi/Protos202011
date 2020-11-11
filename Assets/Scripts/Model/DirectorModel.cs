using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DirectorModel : MonoBehaviour, IPointerClickHandler
{
    private Vector2 clickPos;
    private List<IEnumerator> ExcutionSlot;

    public static bool move = false;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (move)
        {
            clickPos = eventData.pressPosition;
            clickPos = Camera.main.ScreenToWorldPoint(clickPos);
            GameManager.pickedMob.GetComponent<MobBehavior>().MoveTo(clickPos);
            move = false;
        }
        
        
    }

    private IEnumerator WaitMoveCommand()
    {
        while (true)
        {
            yield return new WaitUntil(() => !(GameManager.pickedMob is null));

        }
    }

    
}
