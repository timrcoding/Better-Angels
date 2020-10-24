using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] tiles;
    public List<GameObject> players;
    public int playerSelected;

    //CARD SELECTION
    public List<int> cardSelection;
    public List<TextMeshProUGUI> cardText;
    public TextAsset IndignitiesText;
    public TextMeshProUGUI turnText;
    public List<string> Indignities;

    public List<int> selections;
    public bool groupSelect;
    void Start()
    {
        instance = this;
        setIndignities();
        startTurn();
    }

    public void selectPlayer()
    {
        playerSelected++;
        if(playerSelected >= players.Count)
        {
            playerSelected = 0;
        }
    }

    public void incPlayerScore(int i)
    {
        players[i].GetComponent<PlayerBehaviour>().incScore();
    }

    public void decPlayerScore(int i)
    {
        players[i].GetComponent<PlayerBehaviour>().decScore();
    }

    public void startTurn()
    {
        selectIndignities();
        clearScores();
    }


    void setIndignities()
    {
        Indignities = new List<string>(IndignitiesText.text.Split('\n'));
    }

    public void selectIndignities()
    {
        for(int i = 0; i < cardSelection.Count; i++)
        {
            int num = Random.Range(0, Indignities.Count - 1);
            cardSelection[i] = num;
            cardText[i].text = Indignities[num];
        }
        if(cardSelection[0] == cardSelection[1])
        {
            selectIndignities();
        }
        turnText.text = "GROUP TURN";
        groupSelect = true;
    }

    public void Selection(int i)
    {
        if (groupSelect)
        {
            selections[0] = i;
            groupSelect = false;
            turnText.text = "PLAYER TURN";
        }
        else
        {
            selections[1] = i;
            compareAnswers();
        }
    }

    public void compareAnswers()
    {
        if(selections[0] == selections[1])
        {
            groupWins();
        }
        else
        {
            playerWins();
        }
    }

    public void groupWins()
    {
        for(int i = 0; i < players.Count; i++)
        {
            if(i == playerSelected)
            {
                decPlayerScore(i);
            }
            else
            {
                incPlayerScore(i);
            }
        }
        startTurn();
    }

    public void playerWins()
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (i == playerSelected)
            {
                incPlayerScore(i);
            }
            else
            {
                decPlayerScore(i);
            }
        }
        startTurn();
    }

    public void clearScores()
    {
        for(int i = 0; i < selections.Count; i++)
        {
            i = 0;
        }
    }
}
