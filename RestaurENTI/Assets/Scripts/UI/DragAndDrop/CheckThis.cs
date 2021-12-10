using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckThis : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] testDB database;
    // Start is called before the first frame update
    void Start()
    {
        text.text = DisplayRandomRecipe();
    }

    public string DisplayRandomRecipe()
    {
        List<Recipe> recipes = new List<Recipe>();
        recipes = database.GetRecipes();

        return recipes[Random.Range(0, recipes.Count)].recipe;
    }
}
