using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateRecipe : MonoBehaviour
{
    [SerializeField] Text recipeName;
    [SerializeField] RestaurentiDB database;

    private void Awake()
    {
        recipeName.text = DisplayRandomRecipe();
    }

    public string DisplayRandomRecipe()
    {
        List<Recipe> recipes = new List<Recipe>();
        recipes = database.GetRecipes();

        return recipes[Random.Range(0, recipes.Count)].recipe;
    }
}