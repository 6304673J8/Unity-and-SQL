using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RecipeComprobation : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] RestaurentiDB database;
    [SerializeField] Text recipe;
    //[SerializeField] Text ingredients;
    public bool victory;
    AudioSource audioData;

    // Start is called before the first frame update
    private void Start()
    {
        audioData = GetComponent<AudioSource>();

    }

    private void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audioData.Play(0);

        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }
}
