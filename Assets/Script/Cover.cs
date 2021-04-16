using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cover : MonoBehaviour
{

    private FadeManager theFade;

    // Start is called before the first frame update
    void Start()
    {
        theFade = FindObjectOfType<FadeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) {
            StartCoroutine(TransferCoroutine());
        }
    }


    IEnumerator TransferCoroutine() {
        theFade.FadeOut();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Stage00");
        theFade.FadeOut();
        yield return new WaitForSeconds(1.5f);
        theFade.FadeIn();
    }
}
