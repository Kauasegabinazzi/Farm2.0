using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.Rendering.DebugUI;

public class AnimController : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Transform attack;

    private PlayerAnim player;
    private Enemy enemy;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindAnyObjectByType<PlayerAnim>();
        enemy = GetComponentInParent<Enemy>();
    }

    public void PlayerAnim(int value)
    {
        anim.SetInteger("transition", value);
    }

    public void Attack()
    {
        if (!enemy.isDead)
        {
            Collider2D hit = Physics2D.OverlapCircle(attack.position, radius, playerLayer);

            if (hit != null)
            {
                player.onHit();
            }
        }
    }

    public void OnHit()
    {
        if (enemy.currenthealth <= 0)
        {
            enemy.isDead = true;
            anim.SetTrigger("death");
            Destroy(enemy.gameObject, 1f);
        }
        else
        {
            anim.SetTrigger("hit");
            enemy.currenthealth--;

            enemy.healthBar.fillAmount = enemy.currenthealth / enemy.totalHealth;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attack.position, radius);
    }
}
