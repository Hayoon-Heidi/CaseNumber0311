using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCredit : MonoBehaviour
{

    private FadeManager theFade;
    public float delay;

    void Start()
    {
        theFade = FindObjectOfType<FadeManager>();

        StartCoroutine(GoToTitle(delay));
    }


    IEnumerator GoToTitle(float delay) {

        yield return new WaitForSeconds(delay);
        theFade.FadeOut();
        SceneManager.LoadScene("Cover2");

    }

    
}
