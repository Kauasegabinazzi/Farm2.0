using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AnimController : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float radius; 

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayerAnim(int value)
    {
        anim.SetInteger("transition", value);
    }

    public void Attack()
    {
        //Collider2D hit = Physics2D.OverlapCircle();
    }
}
