using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public static IntroManager instance;
    
    void Start()
    {
        instance = this;
    }

    public void removeBlankPlayers()
    {
        for(int i = 0; i < NameManager.instance.names.Count; i++)
        {
            if(NameManager.instance.names[i] == "")
            {
                NameManager.instance.names.RemoveRange(i, NameManager.instance.names.Count-i);
            }
        }
    }

    public void loadNextLevel()
    {
        removeBlankPlayers();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
}
