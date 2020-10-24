using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Winner : MonoBehaviour
{
    private TextMeshProUGUI winners;
    void Start()
    {
        winners = GetComponent<TextMeshProUGUI>();
        winners.text = "";
        for (int i = 0; i < GameManager.instance.winningPlayers.Count; i++)
        {
            winners.text += NameManager.instance.names[GameManager.instance.winningPlayers[i]] + '\n';
        }
        
    }

    
}
