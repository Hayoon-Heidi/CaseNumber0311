using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event3Manager : MonoBehaviour
{

    [SerializeField]
    public Dialogue dialogue_1;
    public Dialogue dialogue_2;

    public BoxCollider2D boxCollider;
    private PlayerManager thePlayer;
    private DialogueManager theDM;
    private OrderManager theOrder;
    private FadeManager theFade;
    
    private bool clock;
    private bool window;
    private bool piano;
    private bool canExit;

    private bool flag;

    void Start()
    {
        theFade = FindObjectOfType<FadeManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
        theDM = FindObjectOfType<DialogueManager>();
        theOrder = FindObjectOfType<OrderManager>();

    }

    public void changeClock() {
        clock = true;
    }

    public void changeWindow() {
        window = true;
    }

    public void changPiano() {
        piano = true;
    }

    public void canExitChange() {

        if (clock && window && piano) {
            canExit = true;
        } else {
            canExit = false;
        }

    }

    private void OnTriggerStay2D(Collider2D collision) {

        if(!flag && Input.GetKey(KeyCode.Z)) {

            canExitChange();

            if (canExit) {
                flag = true;
                StartCoroutine(ACoroutine()); // 나가는 경우.
            } else {
                flag = true;
                StartCoroutine(BCoroutine()); // 열쇠가 없는 경우. 
            }
        }
    }

    IEnumerator ACoroutine() {
        theOrder.NotMove();
        theDM.ShowDialogue(dialogue_1);

        yield return new WaitUntil(() => !theDM.talking);
        theOrder.Move();

        theFade.FadeOut();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Stage04");
        theFade.FadeOut();
        yield return new WaitForSeconds(1.5f);
        theFade.FadeIn();
    }

    IEnumerator BCoroutine() {
        theOrder.NotMove();
        theDM.ShowDialogue(dialogue_2);

        yield return new WaitUntil(() => !theDM.talking);
        theOrder.Move();
        flag = false;
    }
}
