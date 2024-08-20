using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AnimController : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Transform attack;
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
        Collider2D hit = Physics2D.OverlapCircle(attack.position, radius, playerLayer);

        if (hit != null) {
            Debug.Log("bateu");
        }
        else
        {

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attack.position, radius);
    }
}
