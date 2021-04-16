using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event6Curtain : MonoBehaviour
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
  
    public GameObject windowOpen; 
    public GameObject lights;

    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        theOrder = FindObjectOfType<OrderManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
        event6 = FindObjectOfType<Event6Manager>();
    }

    private void OnTriggerStay2D(Collider2D collision) {

        if(!flag && Input.GetKey(KeyCode.Z) && thePlayer.animator.GetFloat("DirY") == 1f && (collision.tag == "Player")) {
            flag = true;
            StartCoroutine(EventCoroutine());
        }
    }

    IEnumerator EventCoroutine() {
        //theOrder.NotMove();


            if(!event6.getCurtainState() && flag) { // 커텐이 열리지 않은 상태
                event6.changeCurtain();//
                windowOpen.SetActive(true);
                lights.SetActive(true);

                yield return new WaitForSeconds(3f);

                if (event6.getDestroyed()) {
                     lights.SetActive(false);                   
                } else {
                    lights.SetActive(false);
                    windowOpen.SetActive(false);
                    event6.changeCurtain();                    
                }
                

                
            } else {
                yield return new WaitForSeconds(0.01f);
            }

            theOrder.Move();
            flag = false;



    }
    
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
