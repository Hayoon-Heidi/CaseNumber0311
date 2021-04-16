using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event2Safe : MonoBehaviour
{

     [SerializeField]
    public Dialogue dialogue_0;

    private DialogueManager theDM;

    private OrderManager theOrder;
    private NumberSystem theNumber;
    private PlayerManager thePlayer;
    private Event2Manager event2;

    public bool flag;
    public int correctNumber;

    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        theOrder = FindObjectOfType<OrderManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
        theNumber = FindObjectOfType<NumberSystem>();
        event2 = FindObjectOfType<Event2Manager>();
                
    }

    private void OnTriggerStay2D(Collider2D collision) {

         if(!flag && Input.GetKey(KeyCode.Z)) {
            StartCoroutine(ACoroutine());
        }
    }

    IEnumerator ACoroutine() {
        flag = true;
        theOrder.NotMove();

        theDM.ShowDialogue(dialogue_0);
        theNumber.ShowNumber(correctNumber);

        yield return new WaitUntil(() => !theNumber.activated);


        if(!theNumber.GetResult()) {
            flag = false;
        } else {
            event2.canExitChange();
        }

        yield return new WaitUntil(() => !theDM.talking);

        theOrder.Move();
    }


// 사랑해 신수현


}
