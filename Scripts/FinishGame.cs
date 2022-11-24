using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public bool isFinished = false;
    [SerializeField] private GameObject winPanel;
    public int objeCount;
    public static FinishGame instance;
    public bool isCatch = false;
    //[SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject map;

    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        if (instance) instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (other.gameObject.CompareTag("Player") && objeCount == 0 && !isCatch)
        {
            LevelManager.instance.levelCount++;
            CashManager.instance.totalCash += RandomOdulSpawn.instance.oduller.Length * 100;
            map.SetActive(false);
            winPanel.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = false;
        }

    }
}
