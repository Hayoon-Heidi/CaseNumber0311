using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartRight : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    private PlayerManager thePlayer;
    private DialogueManager theDM;
    private OrderManager theOrder;
    private FadeManager theFade;
    
    public string sceneName;

    void Start()
    {
        theFade = FindObjectOfType<FadeManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
        theDM = FindObjectOfType<DialogueManager>();
        theOrder = FindObjectOfType<OrderManager>();

    }

    private void OnTriggerStay2D(Collider2D collision) {

        if (Input.GetKey(KeyCode.Z) && thePlayer.animator.GetFloat("DirX") == 1f) {
            StartCoroutine(ACoroutine()); 
        }

    }

    IEnumerator ACoroutine() {
        theOrder.NotMove();
        theFade.FadeOut();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);

    }
}
