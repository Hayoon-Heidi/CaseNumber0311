using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCOrderManager : MonoBehaviour
{

    private NPCManager theNPC;

    // Start is called before the first frame update
    void Start()
    {
        theNPC = FindObjectOfType<NPCManager>();
    }


    public void NotMove(){
        theNPC.notMove = true;
    }

    public void Move() {
        theNPC.notMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
