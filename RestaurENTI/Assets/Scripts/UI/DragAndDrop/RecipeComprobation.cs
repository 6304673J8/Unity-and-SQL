using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RecipeComprobation : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] testDB database;
    [SerializeField] Text recipe;
    //[SerializeField] Text ingredients;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }
}
