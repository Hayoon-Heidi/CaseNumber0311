using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [System.Serializable]
public class NPCMove
{
    [Tooltip("NPCMove를 체크하면 NPC가 움직임")]
    public bool NPCmove;
    public string[] direction; //npc가 움직일 방향 설정
    [Range(1, 5)] [Tooltip("빈도: 1 - 천천히, 2 - 조금 천천히, 3 - 보통, 4 - 조금 빠르게, 5 - 연속적으로")]
    public int frequency; //npc가 움직일 방향으로 얼마나 빠른 속도로 움직일 것인가. 
}

public class NPCManager : MovingObject
{
    [SerializeField]
    public NPCMove shadow;

    public bool notMove = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveCoroutine());
    }

    

    public void SetMove() {
        notMove = false;
    }
    public void SetNotMove() {
        notMove = true;
    }

    IEnumerator MoveCoroutine() 
    {
        if(shadow.direction.Length != 0)
        {
            for(int i = 0; i < shadow.direction.Length; i++)
            {
                switch (shadow.frequency)
                {
                    case 1:
                        yield return new WaitForSeconds(100f);
                        break;
                    case 2:
                        yield return new WaitForSeconds(3f);
                        break;
                    case 3:
                        yield return new WaitForSeconds(2f);
                        break;
                    case 4:
                        yield return new WaitForSeconds(1f);
                        break;
                    case 5:
                        break;
                }

                //실질적인 이동 구간 ;
                yield return new WaitUntil(() => npcCanMove); //람다식,,
                // npcCanMove가 true가 될때까지 기다림. 코루틴이 끝날때까지 기다림
                if(!notMove)
                    base.Move(shadow.direction[i], shadow.frequency);


                if(i == shadow.direction.Length - 1) {
                    i = -1; // 위의 움직임을 무한 반복
                }
            }
        }
    }
}
