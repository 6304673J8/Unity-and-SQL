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
    [SerializeField] GameObject recipeCanvas;
    GameObject recipeBook;

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
        recipeBook.SetActive(true);
    }

    // Start is called before the first frame update
    private void Start()
    {
        Text text;

        text = recipeTitleText.GetComponent<Text>();
        nameRecipe = text;
        audioData = GetComponent<AudioSource>();


        ListIngredients();
        recipeCanvas.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        recipeBook.SetActive(false);
        audioData.Play(0);
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        ComprobateState();
    }

    public void ComprobateState()
    {
        if (isShowing == false)
        {
            recipeCanvas.SetActive(true);
            recipeBook.SetActive(false);
            isShowing = true;
        }
        else if (isShowing == true)
        {
            recipeCanvas.SetActive(false);
            recipeBook.SetActive(true);
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
        }

        for (int i = 0; i < recipeIngredients.Count; i++)
        {
            if (confirmRecipeId == recipeIngredients[i].id_recipe)
            {
                PrintIngredients(recipeIngredients[i].id_ingredient);
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

            if (ingredients[i].id_ingredient == idIngredient)
            {
                ingredient = Instantiate(RecipeIngredient, posToInstantiate);
                text = ingredient.GetComponentInChildren<Text>();

                text.text = ingredients[i].ingredient;
            }
        }
    }
}