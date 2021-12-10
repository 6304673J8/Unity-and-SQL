using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient
{
    public int id_ingredient;
    public string ingredient;
    public string image;

    public Ingredient(int _id_ingredient, string _ingredient, string _image)
    {
        id_ingredient = _id_ingredient;
        ingredient = _ingredient;
        image = _image;
    }
}
