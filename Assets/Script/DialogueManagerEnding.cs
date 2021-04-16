using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManagerEnding : MonoBehaviour
{
    
    public Text text;
    public SpriteRenderer rendererDialogueWindow;
    private FadeManager theFade;

    private List<string> listSentences;
    private List<Sprite> listDialogueWindows;

    private int count; //대화 진행 상황 카운트

    public Animator animDialogueWindow;
    //private OrderManager theOrder;
    public bool talking = false;
    private bool keyActivated = false;
    

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        text.text = "";
        listSentences = new List<string>();
        listDialogueWindows = new List<Sprite>();
        //theOrder = FindObjectOfType<OrderManager>();
    }

    public void ShowDialogue(Dialogue dialogue) {

        talking = true;

        for (int i=0; i < dialogue.sentences.Length; i++) {
            listSentences.Add(dialogue.sentences[i]);
            listDialogueWindows.Add(dialogue.dialogueWindows[i]);
        }
        animDialogueWindow.SetBool("Appear", true);
        StartCoroutine(StartDialogueCoroutine());
    }

    public void ExitDialogue() {
        
        text.text = "";
        count = 0;
        listSentences.Clear();
        listDialogueWindows.Clear();
        animDialogueWindow.SetBool("Appear", false);
        talking = false;
    }


    IEnumerator StartDialogueCoroutine() {

        if (count > 0) {        
            if(listDialogueWindows[count] != listDialogueWindows[count-1]) {
                animDialogueWindow.SetBool("Appear", false);
                yield return new WaitForSeconds(0.1f);
                rendererDialogueWindow.GetComponent<SpriteRenderer>().sprite = listDialogueWindows[count];
                animDialogueWindow.SetBool("Appear", true);
            }else {
                yield return new WaitForSeconds(0.05f);
            }
        } else {
             rendererDialogueWindow.GetComponent<SpriteRenderer>().sprite = listDialogueWindows[count];
        }
        
        keyActivated = true;
        for (int i=0; i < listSentences[count].Length; i++) {
            text.text += listSentences[count][i]; // 한 글자씩 출력.
            yield return new WaitForSeconds(0.02f); // 대기 시간.
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(talking && keyActivated) {
            if (Input.GetKeyDown(KeyCode.Z)) {
                keyActivated = false;
                count++;
                text.text = "";

                if (count == listSentences.Count) {
                    StopAllCoroutines();
                    ExitDialogue();
                }                
                else {
                    StopAllCoroutines();
                    StartCoroutine(StartDialogueCoroutine());
                }
            } else if (Input.GetKeyDown(KeyCode.C)) {
                    StopAllCoroutines();
                    ExitDialogue();
                    theFade.FadeOut();
                    SceneManager.LoadScene("EndingCredit");
            }
        }

        
    }
}
