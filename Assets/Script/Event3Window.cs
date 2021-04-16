using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event3Window : MonoBehaviour
{
     [SerializeField]
    public Dialogue dialogue_1;
    public Dialogue dialogue_2;

    private DialogueManager theDM;
    private OrderManager theOrder;
    private PlayerManager thePlayer;
    private Event3Manager event3;

    private bool flag;
    private bool get;

    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        theOrder = FindObjectOfType<OrderManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
        event3 = FindObjectOfType<Event3Manager>();
    }

    private void OnTriggerStay2D(Collider2D collision) {

        if(!flag && Input.GetKey(KeyCode.Z)  && thePlayer.animator.GetFloat("DirY") == 1f) {
            flag = true;
            StartCoroutine(EventCoroutine());
        }
    }

    IEnumerator EventCoroutine() {
        theOrder.NotMove();

        if (!get) {
            theDM.ShowDialogue(dialogue_1); // 첫번째 이벤트, 열쇠조각을 얻음.
            get = true;
            event3.changeWindow();
        } else{
            theDM.ShowDialogue(dialogue_2); // 첫번째 이후 이벤트, 열쇠조각에 대한 글 없음. 
        }
        yield return new WaitUntil(() => !theDM.talking);
        theOrder.Move();
        flag = false;
    }
}
