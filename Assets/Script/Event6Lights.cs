using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event6Lights : MonoBehaviour
{

    [SerializeField]
    public Dialogue dialogue_1;
    public Dialogue dialogue_2;
    public Dialogue dialogue_3;
    public Dialogue dialogue_4;

    private DialogueManager theDM;
    private OrderManager theOrder;
    private NPCOrderManager theNPCOrder;
    private PlayerManager thePlayer;
    private Event6Manager event6;

    public GameObject shadow;
    //public GameObject windowOpen; 
    public GameObject transferPoint;
    public GameObject BGMforOutro;

    private bool flag; 

    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        theOrder = FindObjectOfType<OrderManager>();
        theNPCOrder = FindObjectOfType<NPCOrderManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
        event6 = FindObjectOfType<Event6Manager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(!flag && collision.tag != "Player") {
            flag = true; 
            
            StartCoroutine(EventCoroutine());

        }
    }

    IEnumerator EventCoroutine() {
        theOrder.NotMove();
        //theNPCOrder.NotMove();
        shadow.SetActive(false);
        event6.destroyShadow();
        transferPoint.SetActive(true);
        BGMforOutro.SetActive(true);
        theDM.ShowDialogue(dialogue_1);
        yield return new WaitUntil(() => !theDM.talking);
        
        theOrder.Move();
        flag = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
