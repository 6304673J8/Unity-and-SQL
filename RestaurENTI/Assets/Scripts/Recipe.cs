using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    public int id_recipe;
    public string recipe;
    public string image;

    public Recipe(int _id_recipe, string _recipe, string _image)
    {
        id_recipe = _id_recipe;
        recipe = _recipe;
        image = _image;
    }
}
