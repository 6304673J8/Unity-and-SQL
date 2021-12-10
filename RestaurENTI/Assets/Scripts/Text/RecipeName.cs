using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeName : MonoBehaviour
{
    Text instruction;
    void Start()
    {
        instruction = GetComponent<Text>();
    }
}
