using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event5Manager : MonoBehaviour
{
    [SerializeField]
    public Dialogue dialogue_1;
    public Dialogue dialogue_2;
    public Dialogue dialogue_3;


    private PlayerManager thePlayer;
    private DialogueManager theDM;
    private OrderManager theOrder;
    private FadeManager theFade;

    private bool wood = false;
    private bool kerosene = false;
    private bool fire = false;
    private bool burningrose = false; 

    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        theFade = FindObjectOfType<FadeManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
        theDM = FindObjectOfType<DialogueManager>();
        theOrder = FindObjectOfType<OrderManager>();
    }

    public void changeWood() {
        wood = true;
    }
    public bool getWoodState() {
        return wood; 
    }
    
    public void changeKereosene() {
        kerosene = true;
    }
    public bool getKeroseneState() {
        return kerosene;
    }

    public void changeFire() {
        fire = true;
    }

    public void burningdown() {
        if(fire == true) {
            burningrose = true;
        } else {
            burningrose = false; 
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(!flag && thePlayer.animator.GetFloat("DirY") == 1f && Input.GetKey(KeyCode.Z)) {
            burningdown();

            if(burningrose) {
                //불타오르는 경우
                flag = true; 
                StartCoroutine(ACoroutine());
            } else {
                //그냥 아무일도 일어나지 않는 경우
                flag = true;
                StartCoroutine(BCoroutine());
            }
        }
    }

    IEnumerator ACoroutine() { // 타버린 맵으로 change
        theOrder.NotMove();
        theDM.ShowDialogue(dialogue_1);

        yield return new WaitUntil(() => !theDM.talking);
        theOrder.Move();

        theFade.FadeOut();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Stage05-1");
        theFade.FadeOut();
        yield return new WaitForSeconds(1.5f);
        theFade.FadeIn();
        //theDM.ShowDialogue(dialogue_3); // 모두 타버렸다!
    }

    IEnumerator BCoroutine() { //변화 없는 dialog
        theOrder.NotMove();
        theDM.ShowDialogue(dialogue_2);

        yield return new WaitUntil(() => !theDM.talking);
        theOrder.Move();
        flag = false;
    }







}
