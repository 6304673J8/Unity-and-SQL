using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public Transform toParent;
    public void OnDrop(PointerEventData eventData)
    {

        if (eventData != null)
        {
            DragAndDrop d = eventData.pointerDrag.GetComponent<DragAndDrop>();
            bool b = d.isIngredient;
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
