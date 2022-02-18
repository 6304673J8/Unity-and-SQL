using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public Transform toParent;
    private bool b;
    public void OnDrop(PointerEventData eventData)
    {

        if (eventData != null)
        {
            DragAndDrop d = eventData.pointerDrag.GetComponent<DragAndDrop>();
            b = d.isIngredient;
            if (b)
            {
                Instantiate(d, toParent);
            }
            else
            {
                eventData.pointerDrag.GetComponent<DragAndDrop>().parentToReturn = toParent;
            }

        }
    }
}
