using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event5Wood : MonoBehaviour
{
    
     [SerializeField]
    public Dialogue dialogue_1;
    public Dialogue dialogue_2;

    private DialogueManager theDM;
    private OrderManager theOrder;
    private PlayerManager thePlayer;
    private Event5Manager event5;

    private bool get; // 나뭇가지 on/off
    private bool flag; //이벤트 두번 연속 발동 방지

    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        theOrder = FindObjectOfType<OrderManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
        event5 = FindObjectOfType<Event5Manager>();
    }

    private void OnTriggerStay2D(Collider2D collision) {

        if(!flag && Input.GetKey(KeyCode.Z) && thePlayer.animator.GetFloat("DirY") == 1f) {
            flag = true;
            StartCoroutine(EventCoroutine());
        }
    }

    IEnumerator EventCoroutine() {
        theOrder.NotMove();
        if(!get) { // 0. 아무것도 갖지 않은 상태: 나뭇가지를 얻음
            theDM.ShowDialogue(dialogue_1);
            get = true;
            event5.changeWood();
        }else { // 1. 나뭇가지를 이미 가진 상태: 나무에 대한 대화만 나옴
            theDM.ShowDialogue(dialogue_2);
        }

        yield return new WaitUntil(() => !theDM.talking);
        theOrder.Move();
        flag = false; 
    }
}
