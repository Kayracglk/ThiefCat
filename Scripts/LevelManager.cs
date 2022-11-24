using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameObject[] levels;
    public int levelCount;

    private void Awake()
    {
        instance = this;
    }
}

