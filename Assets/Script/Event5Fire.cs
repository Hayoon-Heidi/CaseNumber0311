using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event5Fire : MonoBehaviour
{
      [SerializeField]
    public Dialogue dialogue_1;
    public Dialogue dialogue_2;
    public Dialogue dialogue_3;
    public Dialogue dialogue_4;

    private DialogueManager theDM;
    private OrderManager theOrder;
    private PlayerManager thePlayer;
    private Event5Manager event5;

    private bool flag; //이벤트 두번 연속 발동 방지
    private bool isBurning; 

    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        theOrder = FindObjectOfType<OrderManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
        event5 = FindObjectOfType<Event5Manager>();
    }

    private void OnTriggerStay2D(Collider2D collision) {

        if(!flag && Input.GetKey(KeyCode.Z) && thePlayer.animator.GetFloat("DirY") == -1f) {
            flag = true;
            StartCoroutine(EventCoroutine());
        }
    }

    IEnumerator EventCoroutine() {
        theOrder.NotMove();
        if (!isBurning) { //횃불 비활성화 상태
            if(!event5.getWoodState()) { // 0. 아무것도 갖지 않은 상태: 
                theDM.ShowDialogue(dialogue_1);
            }else if(event5.getWoodState() && !event5.getKeroseneState()) { // 1. 나뭇가지만 가진 상태
                theDM.ShowDialogue(dialogue_2);
            }else if(event5.getWoodState() && event5.getKeroseneState()) { // 2. 나뭇가지/기름 둘다 가짐
                theDM.ShowDialogue(dialogue_3);
                isBurning = true;
                event5.changeFire(); // 횃불 활성화
            }
        } else { //횃불 활성화 상태
            theDM.ShowDialogue(dialogue_4); 
        }
        

        yield return new WaitUntil(() => !theDM.talking);
        theOrder.Move();
        flag = false; 
    }
}
