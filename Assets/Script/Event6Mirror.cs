using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event6Mirror : MonoBehaviour
{
    [SerializeField]
    public Dialogue dialogue_1;
    public Dialogue dialogue_2;
    public Dialogue dialogue_3;
    public Dialogue dialogue_4;

    private DialogueManager theDM;
    private OrderManager theOrder;
    private PlayerManager thePlayer;
    private Event6Manager event6;

    private bool flag; 

    public GameObject shadowVisible;
    public GameObject neck;
  
    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        theOrder = FindObjectOfType<OrderManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
        event6 = FindObjectOfType<Event6Manager>();
    }

    private void OnTriggerStay2D(Collider2D collision) {

        if(!flag && Input.GetKey(KeyCode.Z) && thePlayer.animator.GetFloat("DirY") == 1f) {
            flag = true;
            StartCoroutine(EventCoroutine());
        }
    }

    IEnumerator EventCoroutine() {
        theOrder.NotMove();
        if(event6.getNecklessState()) { //목걸이 걸려있어서 그림자 안보이는 상태
            event6.changeNecklese();
            theDM.ShowDialogue(dialogue_1); //
            yield return new WaitUntil(() => !theDM.talking);
            shadowVisible.SetActive(true);
            neck.SetActive(true);
        }else { // 목걸이 안걸려있음 그림자 보임
            theDM.ShowDialogue(dialogue_2);
            yield return new WaitUntil(() => !theDM.talking);
        }

        
        
        
        theOrder.Move();
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
