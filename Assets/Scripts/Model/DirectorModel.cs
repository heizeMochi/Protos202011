using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DirectorModel : MonoBehaviour, IPointerClickHandler, IDragHandler, IBeginDragHandler
{
    public Camera theCamera;
    Vector3 cameraPos;
    float mouseX;


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
