using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// BackGround 에 들어간 컴포넌트

public class DirectorModel : MonoBehaviour, IPointerClickHandler, IDragHandler, IBeginDragHandler
{
    public Camera theCamera;
    Vector3 cameraPos;
    float mouseX;


    private Vector2 clickPos;
    private List<IEnumerator> ExcutionSlot;

    public static bool move = false;

    // 클릭 시 해당 마우스 위치에 있는 gameObject를 GameManager.pickedMob 에 할당
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


    // 드래그로 맵 이동
    public void OnBeginDrag(PointerEventData eventData)
    {
        cameraPos = theCamera.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        mouseX = Input.GetAxis("Mouse X");
        cameraPos.x = Mathf.Clamp((cameraPos.x - mouseX), 0, 31);
        theCamera.transform.position = cameraPos;
    }


}
