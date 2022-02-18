using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum ISlotType
{
    Ingredients,
    Recipe
}

public class IngredientDragHandler : MonoBehaviour//, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    /*public InventoryIngredientBase Ingredient { get; set; }

    public ISlotType SlotType = ISlotType.Ingredients;

    private GameObject mDragImage;
    private RectTransform mDragSurface;


    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        var canvas = FindInParents<Canvas>(gameObject);
        if (canvas == null)
            return;

        mDragImage = new GameObject("Drag_Image");

        mDragImage.transform.SetParent(canvas.transform, false);
        mDragImage.transform.SetAsLastSibling();

        var image = mDragImage.AddComponent<Image>();

        image.sprite = GetComponent<Image>().sprite;

        image.raycastTarget = false;

        mDragSurface = canvas.transform as RectTransform;

        SetDraggedPosition(eventData);
    }

    private void  SetDraggedPosition(PointerEventData data)
    {
        var rt = mDragImage.GetComponent<RectTransform>();
        Vector3 mousePosition;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(mDragSurface,
            data.position, data.pressEventCamera, out mousePosition))
        {
            rt.position = mousePosition;
            rt.rotation = mDragSurface.rotation;
        }

    }
    private object FindInParents<T>(GameObject gameObject)
    {
        throw new System.NotImplementedException();
    }*/
}
