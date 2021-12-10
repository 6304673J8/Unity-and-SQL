using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateItems : MonoBehaviour
{
    [SerializeField] GameObject Item;
    [SerializeField] Transform posToInstantiate;
    
    [SerializeField] testDB database;

    // Start is called before the first frame update
    void Start()
    {
        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients = database.GetIngredients();
        for (int i = 0; i < ingredients.Count; i++)
        {
            GameObject item = Instantiate(Item, posToInstantiate);
            Text text = item.GetComponentInChildren<Text>();
            text.text = ingredients[i].ingredient;
        }
    }
}