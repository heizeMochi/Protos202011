using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
[RequireComponent(typeof(MobData))]
public class SelectableModel : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool isSelectable = true;
    public bool isPickable = true;
    public bool isSelected = false;
    public bool isPicked = false;


    // 클릭 시 작동할 내용
    public void OnPointerClick(PointerEventData eventData)
    {
        if (MotherShip.EmbarkSelect)
        {
            GameManager.EmbarkMob = gameObject;
            MotherShip.EmbarkSelect = false;
        }
        else
        {
            isPickable = !isPickable;
            isPicked = !isPicked;
            GameManager.PickObj(gameObject);
            Debug.Log("Clicked");
        }
    }

    // Obeject 밖으로 마우스 커서를 이동할 때 작동할 내용
    public void OnPointerExit(PointerEventData eventData)
    {
        if (ReferenceEquals(gameObject, GameManager.selectedMob))
        {
            GameManager.UnSelectObj(gameObject);
            //Debug.Log("Pointer exit");
        }
    }

    // Object위에 마우스 포인터를 둘 때 작동할 내용
    // (선택 가능함을 볼 수 있음)
    public void OnPointerEnter(PointerEventData eventData)
    {
        GameManager.SelectObj(gameObject);
        //Debug.Log("Pointer up");
    }
}
