using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MovingObject
{


    // public AudioClip walkSound_1; //사운드파일 1
    // public AudioClip walkSound_2; //사운드파일 2
    // private AudioSource audioSource; //사운드플레이어 
    
    public string walkSound_1; 
    public string walkSound_2; 
    public string walkSound_3; 
    public string walkSound_4; 

    private AudioManager theAudio;

    public float runSpeed;
    private float applyRunSpeed;
    private bool applyRunFlag = false;

    public bool notMove = false;
    private bool canMove = true;



    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        theAudio = FindObjectOfType<AudioManager>();
    }

    IEnumerator MoveCoroutine()
    {

        while (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0 && !notMove)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                applyRunSpeed = runSpeed;
                applyRunFlag = true;
            }
            else
            {
                applyRunSpeed = 0;
                applyRunFlag = false;
            }

            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);

            if(vector.x != 0)
            {
                vector.y = 0;
            }

            animator.SetFloat("DirX", vector.x);
            animator.SetFloat("DirY", vector.y);

            RaycastHit2D hit;
            // A 지점에서 B 지점에 레이저를 쏜다고 했을 때, 
            // B 지점에 도달하면 hit = null;
            // 도달하지 못하면 hit = 방해물

            Vector2 start = transform.position; // A 지점: 캐릭터의 현지 위치 값
            Vector2 end = start + new Vector2(vector.x * speed * walkCount, vector.y * speed * walkCount); // B 지점: 캐릭터가 도달하고자 하는 위치 값

            boxCollider.enabled = false;
            hit = Physics2D.Linecast(start, end, layerMask);
            boxCollider.enabled = true;

            if(hit.transform != null)
            {
                break;
            }

            animator.SetBool("Walking", true);

            /*
            int temp = Random.Range(1,4); 
            switch (temp)
            {
                case 1:
                    theAudio.Play(walkSound_1);
                    break;
                case 2:
                    theAudio.Play(walkSound_2);
                    break;
                case 3:
                    theAudio.Play(walkSound_3);
                    break;
                case 4:
                    theAudio.Play(walkSound_4);
                    break;
            }*/
            

            while (currentWalkCount < walkCount)
            {
                if (vector.x != 0)
                {
                    transform.Translate(vector.x * (speed + applyRunSpeed), 0, 0);
                }
                else if (vector.y != 0)
                {
                    transform.Translate(0, vector.y * (speed + applyRunSpeed), 0);
                }

                if (applyRunFlag)
                {
                    currentWalkCount++;
                }
                currentWalkCount++;
                yield return new WaitForSeconds(0.001f);

                
            }
            currentWalkCount = 0;

        }

        animator.SetBool("Walking", false);
        canMove = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(canMove && !notMove)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                canMove = false;
                StartCoroutine(MoveCoroutine());

            }
        }
    }

    public void Move() {
        notMove = false;
    }

    public void NotMove() {
        notMove = true;
    }
}
