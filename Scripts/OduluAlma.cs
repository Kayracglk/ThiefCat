using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OduluAlma : MonoBehaviour
{
    [SerializeField] private GameObject particalEffect;
    [SerializeField] private GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            StartCoroutine(enumerator());
        }
    }

    private IEnumerator enumerator()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(2f);
        gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        FinishGame.instance.objeCount--;
        SliderCode.instance.sliderUi.value = FinishGame.instance.objeCount / (float)2;
        StartCoroutine(enumerator0());
        player.GetComponent<PlayerMovement>().enabled = true;
    }
    private IEnumerator enumerator0()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(particalEffect, gameObject.transform.position, gameObject.transform.rotation);
        gameObject.SetActive(false);
    }
}
