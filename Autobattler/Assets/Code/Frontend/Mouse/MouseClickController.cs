using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseClickController : MonoBehaviour
{
    PointerEventData pointerEventData;
    public EventSystem eventSystem;
    public GraphicRaycaster raycaster;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            raycaster.Raycast(pointerEventData, results);

            foreach(var result in results)
            {
                Debug.Log(result);
            }
        }
    }
}
