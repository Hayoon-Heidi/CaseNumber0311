using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{

    private FadeManager theFade;


    // Start is called before the first frame update
    void Start()
    {
        theFade = FindObjectOfType<FadeManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.name == "Character_00") {
            StartCoroutine(TransferCoroutine00());
        } else if (collision.gameObject.name == "Character_01") {
            StartCoroutine(TransferCoroutine01());
        } else if (collision.gameObject.name == "Character_02") {
            StartCoroutine(TransferCoroutine02());
        } else if (collision.gameObject.name == "Character_03") {
            StartCoroutine(TransferCoroutine03());
        }else if (collision.gameObject.name == "Character_04") {
            StartCoroutine(TransferCoroutine04());
        }else if (collision.gameObject.name == "Character_05") {
            StartCoroutine(TransferCoroutine05());
        }else if (collision.gameObject.name == "Character_06") {
            StartCoroutine(TransferCoroutine06());
        }
    }

    IEnumerator TransferCoroutine00() {
        theFade.FadeOut();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Stage01");
        theFade.FadeOut();
        yield return new WaitForSeconds(1.5f);
        theFade.FadeIn();
    }

    IEnumerator TransferCoroutine01() {

        theFade.FadeOut();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Stage02");
        theFade.FadeOut();
        yield return new WaitForSeconds(1.5f);
        theFade.FadeIn();                
    }

    IEnumerator TransferCoroutine02() {
        theFade.FadeOut();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Stage03");
        theFade.FadeOut();
        yield return new WaitForSeconds(1.5f);
        theFade.FadeIn();
    }


    IEnumerator TransferCoroutine03() {
        theFade.FadeOut();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Stage04");
        theFade.FadeOut();
        yield return new WaitForSeconds(1.5f);
        theFade.FadeIn();
    }


    IEnumerator TransferCoroutine04() {
        theFade.FadeOut();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Stage05");
        theFade.FadeOut();
        yield return new WaitForSeconds(1.5f);
        theFade.FadeIn();
    }

    IEnumerator TransferCoroutine05() {
        theFade.FadeOut();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Stage06");
        theFade.FadeOut();
        yield return new WaitForSeconds(1.5f);
        theFade.FadeIn();
    }

    IEnumerator TransferCoroutine06() {
        theFade.PlashOut();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Outro");
    }
    
}
