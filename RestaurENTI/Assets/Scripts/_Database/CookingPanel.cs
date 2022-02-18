using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingPanel : MonoBehaviour
{
    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    private IngredientSlot FindSlotForRecipeIngredient(RecipeIngredient recipeIngredient)
    {
        IngredientSlot result = null;

        foreach(var slot in CookingManager.Instance.Slots)
        {
            if (slot.IsEmpty)
            {
                break;
            }

            if (slot.FirstItem.Name == recipeIngredient.Item.Name)
            {
                if (slot.Count >= recipeIngredient.Count)
                {
                    result = slot;
                    break;
                }
            }
        }
        return result;
    }

    public void Close()
    {
        //Move all items to the inventory again
        foreach(var slot in CookingManager.Instance.Slots)
        {
            foreach(var item in slot.Items) {
                txtCount.txt = "";
            }
        }
    }

    private void UpdateCookingUI(IngredientsEventArgs e)
    {
        var ingredientsPanel = transform.Find("IngredientsPanel");
        int index = -1;
        foreach (Transform slotTransform in ingredientsPanel)
        {
            index++;

            Transform imageTransform = slotTransform.GetChild(0).GetChild(0);
            Transform textTransform = slotTransform.GetChild(0).GetChild(1);
            Image image = imageTransform.GetComponent<Image>();
            Text txtCount = textTransform.GetComponent<Text>();
            IngredientDragHandler ingredientDragHandler = imageTransform.GetComponent<IngredientDragHandler>();
        
            if (index == i.Slot.Id)
            {
                image.enabled = true;
                image.sprite = e.Item Image;

                ingredientDragHandler.Ingredient = e.Slot.FirstIngredient;
                break;
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        var dropIngredientDragHandler = eventData.pointerDrag.gameObject.GetComponent<IngredientDragHandler>();
        var dropSlotType = dropIngredientDragHandler.SlotType;

        if (dropSlotType == ISlotType.Ingredients)
        {
            var item = dropIngredientDragHandler.Ingredient;

            CookingManager.Instance.AddIngredient(dropIngredientDragHandler.Ingredient);

            Ingredients.Instance.RemoveIngredient(Ingredient);
        }



    }*/
}
