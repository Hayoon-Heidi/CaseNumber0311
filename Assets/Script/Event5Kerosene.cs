using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event5Kerosene : MonoBehaviour
{
     [SerializeField]
    public Dialogue dialogue_1;
    public Dialogue dialogue_2;

    private DialogueManager theDM;
    private OrderManager theOrder;
    private PlayerManager thePlayer;
    private Event5Manager event5;

    private bool flag; //이벤트 두번 연속 발동 방지
    private bool havingWood;

    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        theOrder = FindObjectOfType<OrderManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
        event5 = FindObjectOfType<Event5Manager>();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        havingWood = event5.getWoodState();

        if(!flag && Input.GetKey(KeyCode.Z) && thePlayer.animator.GetFloat("DirX") == 1f) {
            flag = true;
            StartCoroutine(EventCoroutine(havingWood));
        }
    }

    IEnumerator EventCoroutine(bool _wood) {
        theOrder.NotMove();
        
        if(!_wood) { // 0. 아무것도 갖지 않은 상태: 아무일도 일어나지 않음
            theDM.ShowDialogue(dialogue_1);
        }else { // 1. 나뭇가지를 가진 상태: 나뭇가지에 기름을 묻힘
            theDM.ShowDialogue(dialogue_2);
            event5.changeKereosene();
        }

        yield return new WaitUntil(() => !theDM.talking);
        theOrder.Move();
        flag = false; 
    }

    // Update is called once per frame
    
}
