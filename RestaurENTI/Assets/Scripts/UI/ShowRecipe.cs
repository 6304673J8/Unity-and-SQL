using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShowRecipe : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject RecipeIngredient;
    [SerializeField] Transform posToInstantiate;
    [SerializeField] RestaurentiDB database;
    [SerializeField] GameObject recipeTitleText;
    [SerializeField] GameObject recipeBook;

    AudioSource audioData;
    //GameObject recipeTitleText;
    Text nameRecipe;

    private bool isShowing;

    private int idIngredient;
    private int idRecipe;
    private int idRecipeIngredients;

    private int confirmRecipeId;
    private int confirmIngredientId;

    private void Awake()
    {
        isShowing = false;
        recipeBook = GameObject.FindGameObjectWithTag("RecipeBook");
        //recipeTitleText = GameObject.FindGameObjectWithTag("RecipeRandom");
        recipeBook.SetActive(false);
    }

    // Start is called before the first frame update
    private void Start()
    {
        Text text;

        text = recipeTitleText.GetComponent<Text>();
        nameRecipe = text;
        audioData = GetComponent<AudioSource>();


        ListIngredients();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audioData.Play(0);
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        ComprobateState();
    }

    public void ComprobateState()
    {
        if (isShowing == false)
        {
            recipeBook.SetActive(true);
            isShowing = true;
        }
        else if (isShowing == true)
        {
            recipeBook.SetActive(false);
            isShowing = false;
        }
    }
    public void ListIngredients()
    {
        List<RecipeIngredients> recipeIngredients = new List<RecipeIngredients>();
        List<Recipe> recipes = new List<Recipe>();
        List<Ingredient> ingredients = new List<Ingredient>();

        recipeIngredients = database.GetRecipeIngredients();
        recipes = database.GetRecipes();
        ingredients = database.GetIngredients();

        for (int i = 0; i < recipes.Count; i++)
        {
            idRecipe = recipes[i].id_recipe;

            if (recipes[i].recipe == nameRecipe.text)
            {
                confirmRecipeId = idRecipe;
                Debug.Log(idRecipe + (". ") + recipes[i].recipe);
            }
            //Debug.Log("nameRecipe" + nameRecipe.text);
            //Debug.Log("recipe" + recipes[i].recipe);
        }

        for (int i = 0; i < recipeIngredients.Count; i++)
        {
            if (confirmRecipeId == recipeIngredients[i].id_recipe)
            {

                PrintIngredients(recipeIngredients[i].id_ingredient);
                Debug.Log("OOOOOOOOOOOOOMMMA" + confirmIngredientId);
                Debug.Log(" assa" + recipeIngredients[i].id_ingredient);
            }
        }
    }
    public void PrintIngredients(int idIngredient)
    {
        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients = database.GetIngredients();
        for (int i = 0; i < ingredients.Count; i++)
        {
            GameObject ingredient;
            Text text;

            //if (ingredients[i].id_ingredient == idRecipe)
            if (ingredients[i].id_ingredient == idIngredient)
            {
                ingredient = Instantiate(RecipeIngredient, posToInstantiate);
                text = ingredient.GetComponentInChildren<Text>();

                text.text = ingredients[i].ingredient;
                Debug.Log("DALE ESTO YA ACABA " + ingredients[i].ingredient);
            }
        }
    }
}
            //idRecipeIngredients = recipeIngredients[i].id_ingredient;

            //Debug.Log(idRecipeIngredients + (". ") + recipeIngredients[i].id_ingredient);

            /*for (int i = 0; i < ingredients.Count; i++)
            {
                idIngredient = ingredients[i].id_ingredient;

                if(ingredients[i].ingredient == nameRecipe.text)
                    Debug.Log(idIngredient + (". ") + ingredients[i].ingredient);
                Debug.Log("nameRecipe" + nameRecipe.text);
                Debug.Log("recipe" + ingredients[i].ingredient);
            }*/

            /*for (int i = 0; i < recipeIngredients.Count; i++)
            {
                idRecipeIngredients = recipeIngredients[i].id_ingredient;

                Debug.Log(idRecipeIngredients + (". ") + recipeIngredients[i].id_ingredient);
            }*/
            /*for (int i = 0; i < ingredients.Count; i++)
            {
                GameObject ingredient = Instantiate(RecipeIngredient, posToInstantiate);
                Text text = ingredient.GetComponentInChildren<Text>();

                id = ingredients[i].id_ingredient;

                text.text = id + (". ") + ingredients[i].ingredient;
            }*/
        
    
    /*public void ListIngredients()
    {
        List<RecipeIngredients> recipeIngredients = new List<RecipeIngredients>();
        List<Recipe> recipes = new List<Recipe>();
        List<Ingredient> ingredients = new List<Ingredient>();

        recipeIngredients = database.GetRecipeIngredients();
        recipes = database.GetRecipes();
        ingredients = database.GetIngredients();

        for (int i = 0; i < recipes.Count; i++)
        {
            idRecipe = recipes[i].id_recipe;

            if (recipes[i].recipe == nameRecipe.text)
            {
                confirmRecipeId = idRecipe;
                Debug.Log(idRecipe + (". ") + recipes[i].recipe);
            }
            //Debug.Log("nameRecipe" + nameRecipe.text);
            //Debug.Log("recipe" + recipes[i].recipe);
        }
        Debug.Log("VAMOOOOOOOOOOOOOO" + confirmRecipeId);
        Debug.Log("OOOOOOOOOOOOOMMMA" + confirmIngredientId);
        
        for (int i = 0; i < recipeIngredients.Count; i++)
        {
            if (confirmRecipeId == recipeIngredients[i].id_recipe)
            {
                Debug.Log("JEJE BOY" + recipeIngredients[i].id_ingredient);
                
            }
            //idRecipeIngredients = recipeIngredients[i].id_ingredient;

            //Debug.Log(idRecipeIngredients + (". ") + recipeIngredients[i].id_ingredient);
        }*/

    /*for (int i = 0; i < ingredients.Count; i++)
    {
        idIngredient = ingredients[i].id_ingredient;

        if(ingredients[i].ingredient == nameRecipe.text)
            Debug.Log(idIngredient + (". ") + ingredients[i].ingredient);
        Debug.Log("nameRecipe" + nameRecipe.text);
        Debug.Log("recipe" + ingredients[i].ingredient);
    }*/

    /*for (int i = 0; i < recipeIngredients.Count; i++)
    {
        idRecipeIngredients = recipeIngredients[i].id_ingredient;

        Debug.Log(idRecipeIngredients + (". ") + recipeIngredients[i].id_ingredient);
    }*/
    /*for (int i = 0; i < ingredients.Count; i++)
    {
        GameObject ingredient = Instantiate(RecipeIngredient, posToInstantiate);
        Text text = ingredient.GetComponentInChildren<Text>();

        id = ingredients[i].id_ingredient;

        text.text = id + (". ") + ingredients[i].ingredient;
    }*/
    //}
    /*public void PrintIngredients(int idRecipe)
    {
        List<Ingredient> ingredients = new List<Ingredient>();

        ingredients = database.GetIngredients();
        for (int i = 0; i < ingredients.Count; i++)
        {
            GameObject ingredient = Instantiate(RecipeIngredient, posToInstantiate);
            Text text = ingredient.GetComponentInChildren<Text>();

            if(ingredients[i].id_ingredient == idRecipe)
            {
                //text.text = ingredients[i].ingredient;
                Debug.Log("DALE ESTO YA ACABA " + ingredients[i].ingredient);
            }
        }
    }*/
