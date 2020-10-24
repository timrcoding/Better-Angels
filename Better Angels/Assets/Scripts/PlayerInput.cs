using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInput : MonoBehaviour
{
    public int reference;
    public TMP_InputField input;
    
    void Update()
    {
        
        NameManager.instance.names[reference] = input.text.ToString();
    }
}
