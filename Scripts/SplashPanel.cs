using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashPanel : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("enumerator");
    }

    private IEnumerator enumerator()
    {
        yield return new WaitForSeconds(2f);
        Application.LoadLevel(1);
    }
}
