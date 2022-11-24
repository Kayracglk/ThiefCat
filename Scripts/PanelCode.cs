using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;

public class PanelCode : MonoBehaviour
{
    [SerializeField] private GameObject[] playerStartPoint;
    [SerializeField] private GameObject[] enemyStartPoint;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    private void Awake()
    {
        NavMeshBuilder.ClearAllNavMeshes();
        NavMeshBuilder.BuildNavMesh();
    }

    public void NextLevel()
    {
        if (LevelManager.instance.levelCount == LevelManager.instance.levels.Length)
        {
            LevelManager.instance.levelCount = 0;
        }
        LevelSystem();
    }

    public void RestartLevel()
    {
        LevelSystem();
    }
    private void LevelSystem()
    {
        LevelManager.instance.levels[LevelManager.instance.levelCount].SetActive(true);
        player.transform.position = playerStartPoint[LevelManager.instance.levelCount].transform.position;
        enemy = GameObject.FindGameObjectWithTag("enemy");
        Enemy enemyCode = enemy.GetComponent<Enemy>();
        enemyCode.isChatched = false;
        enemyCode.IsNavMesh = true;
        StartCoroutine(enemyCode.NavMeshMovement(5));
        //enemy.transform.position = enemyStartPoint[LevelManager.instance.levelCount].transform.position; //nawmeshagent kapatmak lazým
        player.GetComponent<PlayerMovement>().enabled = true;
        FinishGame.instance.isCatch = false;
        SliderCode.instance.count = 0;
        SliderCode.instance.sliderUi.value = (float)SliderCode.instance.count / 2;
        NavMeshBuilder.ClearAllNavMeshes();
        NavMeshBuilder.BuildNavMesh();
    }
}
