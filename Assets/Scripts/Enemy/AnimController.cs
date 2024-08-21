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

    private PlayerAnim player;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindAnyObjectByType<PlayerAnim>();
    }

    public void PlayerAnim(int value)
    {
        anim.SetInteger("transition", value);
    }

    public void Attack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attack.position, radius, playerLayer);

        if (hit != null) {
            player.onHit();
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
