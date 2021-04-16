using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event6Couch : MonoBehaviour
{
     [SerializeField]
    public Dialogue dialogue_1;

    private DialogueManager theDM;
    private OrderManager theOrder;

    private bool couch;


    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        theOrder = FindObjectOfType<OrderManager>();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(!couch&& Input.GetKey(KeyCode.Z)) {
            couch = true;
            StartCoroutine(CouchCoroutine());
        }
    }

    IEnumerator CouchCoroutine() {
        theOrder.NotMove();
        theDM.ShowDialogue(dialogue_1);

        yield return new WaitUntil(() => !theDM.talking);
        theOrder.Move();
        couch = false;
    }
}
