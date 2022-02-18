using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RecipeComprobation : MonoBehaviour, IPointerClickHandler
{
    //[SerializeField] Text ingredients;
    public bool victory;
    AudioSource audioData;
    [SerializeField] RestaurentiDB database;
    [SerializeField] GameObject recipeTitleText;
    [SerializeField] GameObject cookingCanvas;
    
    Text nameRecipe;

    private int idIngredient;
    private int idRecipe;
    private int idRecipeIngredients;

    private int confirmRecipeId;
    private int confirmIngredientId;

    private void Awake()
    {
        audioData = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Text text;

        text = recipeTitleText.GetComponent<Text>();
        nameRecipe = text;
        
        //CheckIngredients();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audioData.Play(0);
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }
}
