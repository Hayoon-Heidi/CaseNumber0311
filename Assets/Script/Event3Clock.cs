using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event3Clock : MonoBehaviour
{
    [SerializeField]
    public Dialogue dialogue_0;
    public Dialogue dialogue_1;

    private DialogueManager theDM;
    private OrderManager theOrder;
    private PlayerManager thePlayer;
    private NumberSystem theNumber;
    private Event3Manager event3;

    public GameObject newClock;

    private bool flag;
    public int correctNumber;

    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        theOrder = FindObjectOfType<OrderManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
        event3 = FindObjectOfType<Event3Manager>();
        theNumber = FindObjectOfType<NumberSystem>();
    }

    private void OnTriggerStay2D(Collider2D collision) {

        if(!flag && Input.GetKey(KeyCode.Z)  && thePlayer.animator.GetFloat("DirY") == 1f) {
            flag = true;
            StartCoroutine(EventCoroutine());
        }
    }

    IEnumerator EventCoroutine() {
        theOrder.NotMove();
    
        if (theNumber.GetResult()) {
            theDM.ShowDialogue(dialogue_0);
        } else{
            theDM.ShowDialogue(dialogue_1);
            theNumber.ShowNumber(correctNumber);
            yield return new WaitUntil(() => !theNumber.activated); 

            if(theNumber.GetResult()) {
            event3.changeClock();
            newClock.SetActive(true);
            }           
        }



        yield return new WaitUntil(() => !theDM.talking);
        theOrder.Move();
        flag = false;
    }
}
