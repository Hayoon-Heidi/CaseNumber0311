using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event6Manager : MonoBehaviour
{


    private PlayerManager thePlayer;
    private DialogueManager theDM;
    private OrderManager theOrder;
    private NPCOrderManager theNPCOrder;
    private FadeManager theFade;

    private bool necklese = true;
    private bool curtain = false; 
    private bool destroyed = false; 

    

    public void changeCurtain() {
        if (curtain == false)
            curtain = true; //커텐이 열린 상태; 
        else
            curtain = false;
    }   

    public bool getCurtainState() {
        return curtain; 
    }

    public void changeNecklese() {
        necklese = false; // 목걸이를 빼서 그림자가 보이는 상태
    }

    public bool getNecklessState() {
        return necklese;
    }

    public void destroyShadow() {
        destroyed = true;
    }

    public bool getDestroyed() {
        return destroyed;
    }

    // Start is called before the first frame update
    void Start()
    {
        theFade = FindObjectOfType<FadeManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
        theDM = FindObjectOfType<DialogueManager>();
        theOrder = FindObjectOfType<OrderManager>();
        theNPCOrder = FindObjectOfType<NPCOrderManager>();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
