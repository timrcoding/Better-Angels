﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] tiles;
    public List<GameObject> players;
    public List<GameObject> tileTiers;
    public int playerSelected;

    //CARD SELECTION
    public List<GameObject> cards;
    public List<int> cardSelection;
    public List<TextMeshProUGUI> cardText;
    public TextAsset IndignitiesText;
    public GameObject turnIndicator;
    public TextMeshProUGUI turnText;
    public GameObject playerIndicatorImage;
    public TextMeshProUGUI playerIndicatorText;
    public List<string> Indignities;
    public List<int> winningPlayers;

    public List<int> selections;
    public bool groupSelect;
    public float yOff = 1;
    public GameObject nextRoundButton;

    //WINNING TEXT
    public GameObject winnerObj;
    public TextMeshProUGUI winnerList;
    void Start()
    {
        instance = this;
        setIndignities();
        setUpPlayers();
        startTurn();
    }

    public void nextPlayer()
    {
        playerSelected++;
        if (playerSelected >= players.Count)
        {
            playerSelected = 0;
        }
    }

    public void incPlayerScore(int i, int score)
    {
        players[i].GetComponent<PlayerBehaviour>().incScore(score);
    }

    public void decPlayerScore(int i)
    {
        players[i].GetComponent<PlayerBehaviour>().decScore();
    }

    public void startTurn()
    {
        clearScores();
        selectIndignities();
        turnOnCards(false);
        turnOnCards(true);
        nextRoundButton.SetActive(false);
        setIndicatorImage();

    }

    void setUpPlayers()
    {
        for(int i = 0; i < players.Count; i++)
        {
            if (i < NameManager.instance.names.Count)
            {
                players[i].SetActive(true);
                tileTiers[i].SetActive(true);
            }
            else
            {
                players.RemoveRange(i, players.Count-i);
                tileTiers.RemoveRange(i,tileTiers.Count-i);
            }
                
            
        }
    }


    void setIndignities()
    {
        Indignities = new List<string>(IndignitiesText.text.Split('\n'));
    }

    public void selectIndignities()
    {
        for (int i = 0; i < cardSelection.Count; i++)
        {
            int num = Random.Range(0, Indignities.Count - 1);
            cardSelection[i] = num;
            cardText[i].text = Indignities[num];
            Indignities.RemoveAt(num);
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
            turnIndicator.SetActive(false);
            turnIndicator.SetActive(true);
            turnText.text = "PLAYER TURN";
        }
        else
        {
            turnIndicator.SetActive(false);
            turnIndicator.SetActive(true);
            selections[1] = i;
            compareAnswers();
        }
    }

    public void compareAnswers()
    {
        if (selections[0] == selections[1])
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
        for (int i = 0; i < players.Count; i++)
        {
            if (i == playerSelected)
            {
                //decPlayerScore(i);
            }
            else
            {
                incPlayerScore(i,1);
            }
        }
        turnText.text = "DISCUSSION TIME!";
        nextRoundButton.SetActive(true);

    }

    public void playerWins()
    {
        incPlayerScore(playerSelected,2);
        turnText.text = "DISCUSSION TIME!";
        nextRoundButton.SetActive(true);


    }

    public void clearScores()
    {
        for (int i = 0; i < selections.Count; i++)
        {
            selections[i] = 0;
        }
    }

    public void turnOnCards(bool active)
    {
        foreach(GameObject g in cards)
        {
            g.SetActive(active);
        }
    }

    public void checkIfGameWon()
    {
        for(int i = 0; i < players.Count; i++)
        {
            if(players[i].GetComponent<PlayerBehaviour>().score >= tiles.Length - 1)
            {
                winningPlayers.Add(i);
                winnerObj.SetActive(true);
            }
        }
    }

    public void setIndicatorImage()
    {
        playerIndicatorText.text = NameManager.instance.names[playerSelected] + '\n' + "Write down which is WORST" +'\n' + "Then proceed to...";
        Color playerColour = players[playerSelected].GetComponent<PlayerBehaviour>().token.color;
        playerIndicatorImage.GetComponent<Image>().color = playerColour;
    }

    public void groupDiscussion()
    {
        nextPlayer();
        startTurn();
    }

  
}
