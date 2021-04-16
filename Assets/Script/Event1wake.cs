using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1wake : MonoBehaviour
{
     [SerializeField]
    public Dialogue dialogue_1;

    private DialogueManager theDM;
    private OrderManager theOrder;
    private PlayerManager thePlayer;
    public Animator animator;

    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        theOrder = FindObjectOfType<OrderManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if(!flag && collision.gameObject.name == "Character_01") {
            flag = true;
            StartCoroutine(EventCoroutine());
            animator.SetFloat("DirY", -1f);
        }
    }

    IEnumerator EventCoroutine() {
        theOrder.NotMove();
        theDM.ShowDialogue(dialogue_1);

        yield return new WaitUntil(() => !theDM.talking);
        theOrder.Move();
    }
}
