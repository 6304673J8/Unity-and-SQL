using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeIngredients
{
    public int id_recipe_ingredient;
    public int id_recipe;
    public int id_ingredient;

    public RecipeIngredients(int _id_recipe_ingredient, int _id_recipe, int _id_ingredient)
    {
        id_recipe_ingredient = _id_recipe_ingredient;
        id_recipe = _id_recipe;
        id_ingredient = _id_ingredient;
    }
}