using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event4Magic : MonoBehaviour
{
     [SerializeField]
    public Dialogue dialogue_1;
    public Dialogue dialogue_2;

    private DialogueManager theDM;
    private OrderManager theOrder;
    private PlayerManager thePlayer;
    private Event4Manager event4;

    private bool flag;
    private bool talk;

    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        theOrder = FindObjectOfType<OrderManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
        event4 = FindObjectOfType<Event4Manager>();
    }

    private void OnTriggerStay2D(Collider2D collision) {

        if(!flag && Input.GetKey(KeyCode.Z) ) {
            flag = true;
            StartCoroutine(EventCoroutine());
        }
    }

    IEnumerator EventCoroutine() {
        theOrder.NotMove();

        if(!talk) {
            talk = true;
            event4.canExitChange();
            theDM.ShowDialogue(dialogue_1);
        } else {
            theDM.ShowDialogue(dialogue_2);          
        }

            yield return new WaitUntil(() => !theDM.talking);
            theOrder.Move();
            flag = false;  

    }
}
