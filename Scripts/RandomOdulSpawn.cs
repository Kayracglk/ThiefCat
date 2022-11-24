using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOdulSpawn : MonoBehaviour
{
    public GameObject[] oduller;
    public static RandomOdulSpawn instance;
    private int randomOdul;
    private void OnEnable()
    {
        instance = this;
        
        while (GameObject.FindGameObjectsWithTag("odul").Length <= 1)
        {
            randomOdul = Random.Range(0, oduller.Length);
            if(oduller[randomOdul].activeInHierarchy)
            {
                continue;
            }
            oduller[randomOdul].SetActive(true);
            oduller[randomOdul].transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        }
        if(GameObject.FindGameObjectWithTag("odul"))
        {
            FinishGame.instance.objeCount = GameObject.FindGameObjectsWithTag("odul").Length;
        }
    }
    private void Start()
    {
        FinishGame.instance.objeCount = GameObject.FindGameObjectsWithTag("odul").Length;
    }
}
