using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1Memo : MonoBehaviour
{
    
     [SerializeField]
    public Dialogue dialogue_1;

    private DialogueManager theDM;
    private OrderManager theOrder;
    private PlayerManager thePlayer;
    private Event1Manage event1;

    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        theOrder = FindObjectOfType<OrderManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
        event1 = FindObjectOfType<Event1Manage>();
    }

    private void OnTriggerStay2D(Collider2D collision) {

        if(!flag && Input.GetKey(KeyCode.Z) && (thePlayer.animator.GetFloat("DirX") == -1f || thePlayer.animator.GetFloat("DirY") == 1f)) { //dirX ==1f, DirY ==1f, DirY == -1f
            flag = true;
            StartCoroutine(EventCoroutine());
        }
    }

    IEnumerator EventCoroutine() {
        theOrder.NotMove();

        theDM.ShowDialogue(dialogue_1);

        yield return new WaitUntil(() => !theDM.talking);

        
        theOrder.Move();
        flag = false;
        event1.canExitChange();
    }
}
