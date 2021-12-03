using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsManager : MonoBehaviour
{
    [SerializeField] GameObject item;
    [SerializeField] int count;
    [SerializeField] Transform posToInstantiate;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(item, posToInstantiate);
        }
    }


}
