using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event9Back : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    private PlayerManager thePlayer;
    private DialogueManager theDM;
    private OrderManager theOrder;
    private FadeManager theFade;

    void Start()
    {
        theFade = FindObjectOfType<FadeManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
        theDM = FindObjectOfType<DialogueManager>();
        theOrder = FindObjectOfType<OrderManager>();

    }

    private void OnTriggerStay2D(Collider2D collision) {

        if(Input.GetKey(KeyCode.Z)) {
        StartCoroutine(ACoroutine()); // 나가는 경우.
        }

    }

    IEnumerator ACoroutine() {
        theOrder.NotMove();
        theFade.FadeOut();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Outro");

    }
}
