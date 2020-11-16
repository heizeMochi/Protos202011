using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//몹 (모선 , 자식선) 에 들어간 컴포넌트

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
        // MotherShip의 EmbarkSelect가 true(활성화) 되어있으면 선택된 몹을 GameManager.EmbarkMob에 할당
        // 이후 EmbarkSelect 를 false(비활성화)
        if (MotherShip.EmbarkSelect)
        {
            GameManager.EmbarkMob = gameObject;
            MotherShip.EmbarkSelect = false;
        }
        // GameManager.PickObj에 클릭된 gameObject를 할당
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
