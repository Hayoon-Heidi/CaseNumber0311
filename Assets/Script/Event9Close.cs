using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event9Close : MonoBehaviour
{
     [SerializeField]
    public Dialogue dialogue_1;
    public Dialogue dialogue_2;

    private DialogueManager theDM;
    private OrderManager theOrder;
    private PlayerManager thePlayer;
    private FadeManager theFade;

    private bool flag;
    private bool ending;

    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        theOrder = FindObjectOfType<OrderManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
        theFade = FindObjectOfType<FadeManager>();
    }

    private void OnTriggerStay2D(Collider2D collision) {

        if(!flag && Input.GetKey(KeyCode.Z) && (thePlayer.animator.GetFloat("DirY") == -1f || thePlayer.animator.GetFloat("DirY") == 1f)) { //dirX ==1f, DirY ==1f, DirY == -1f
            
            if(!ending) {
                flag = true;
                StartCoroutine(ACoroutine());                
            } else {
                flag = true;
                StartCoroutine(BCoroutine());
            }

        } 
    }

    IEnumerator ACoroutine() {
        theOrder.NotMove();

        theDM.ShowDialogue(dialogue_1);
        yield return new WaitUntil(() => !theDM.talking);
        ending = true;
        theOrder.Move();
        flag = false;
    }

        IEnumerator BCoroutine() {
        theOrder.NotMove();
         theDM.ShowDialogue(dialogue_2);
        yield return new WaitUntil(() => !theDM.talking);
        theOrder.Move();
        theFade.FadeOut();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("EndingCredit");
    }
}
