using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchTarget : MonoBehaviour
{
    [SerializeField] private GameObject LosePanel;
    private Enemy enemy;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject level;

    private void OnEnable()
    {
        enemy = GetComponentInParent<Enemy>();
        level = GameObject.FindGameObjectWithTag("level");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            FinishGame.instance.isCatch = true;
            LosePanel.SetActive(true);
            enemy.GetComponent<Enemy>().isChatched = false;
            player.GetComponent<PlayerMovement>().enabled = false;
            level.SetActive(false);
        }
    }
}
/*
 [SerializeField] private GameObject LosePanel;
    private Enemy enemy;
    [SerializeField] private GameObject player;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            TimeManager.instance.IsGameContuine = false;
            enemy.GetComponent<g?zlemci>().breakForCorotine = false;
            enemy.GetComponent<g?zlemci>().enabled = false;
            enemy.GetComponent<Enemy>().enabled = false;
            //Door.instance.Restart();

        }
    }
 */