using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameManager : MonoBehaviour
{
    public static NameManager instance;
    public List<string> names;
    void Start()
    {
        instance = this;
    }

    public void setListLength(int i)
    {
        names.Clear();
        names = new List<string>(i);
    }
}
