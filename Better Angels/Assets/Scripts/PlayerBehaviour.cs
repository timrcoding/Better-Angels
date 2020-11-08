using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerBehaviour : MonoBehaviour
{
    public int reference;
    [SerializeField]
    public int score;
    [SerializeField]
    private float yOffset;
    [SerializeField]
    private TextMeshProUGUI nameText;
    public Image token;

    void Start()
    {
        string name = NameManager.instance.names[reference];
        char[] array = name.Take(2).ToArray();
        nameText.text = new string(array);
    }

    // Update is called once per frame
    void Update()
    {
        if (reference == GameManager.instance.playerSelected);
        {
            float numY = yOffset * GameManager.instance.yOff;
            transform.position = Vector3.Lerp(transform.position, new Vector3(GameManager.instance.tiles[score].transform.position.x, GameManager.instance.tiles[score].transform.position.y +numY,0), 0.2f);
        }
    }

    public void incScore(int i)
    {
        score += i;
        if(score >= GameManager.instance.tiles.Length - 1)
        {
            GameManager.instance.checkIfGameWon();
        }
    }

        public void decScore()
    {
        if (score > 0)
        {
            score--;
        }
    }
}
