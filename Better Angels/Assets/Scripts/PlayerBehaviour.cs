using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int reference;
    [SerializeField]
    private int score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (reference == GameManager.instance.playerSelected);
        {
            transform.position = Vector3.Lerp(transform.position, GameManager.instance.tiles[score].transform.position,0.2f);
        }
    }

    public void incScore()
    {
        score++;
    }

    public void decScore()
    {
        score--;
    }
}
