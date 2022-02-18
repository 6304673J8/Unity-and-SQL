using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateItems : MonoBehaviour
{
    [SerializeField] GameObject Ingredient;
    [SerializeField] Transform posToInstantiate;
    
    [SerializeField] RestaurentiDB database;

    public int id;

    // Start is called before the first frame update
    void Start()
    {
        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients = database.GetIngredients();
        for (int i = 0; i < ingredients.Count; i++)
        {
            GameObject ingredient = Instantiate(Ingredient, posToInstantiate);
            Text text = ingredient.GetComponentInChildren<Text>();

            id = ingredients[i].id_ingredient;

            text.text = id + (". ")+ ingredients[i].ingredient;
        }
    }
}