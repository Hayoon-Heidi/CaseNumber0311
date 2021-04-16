using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event2Wake : MonoBehaviour
{
      
    private OrderManager theOrder;
    private PlayerManager thePlayer;
    public Animator animator;

    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        theOrder = FindObjectOfType<OrderManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if(!flag && collision.gameObject.name == "Character_02") {
            flag = true;
            animator.SetFloat("DirX", 1f);
        }
    }

}
