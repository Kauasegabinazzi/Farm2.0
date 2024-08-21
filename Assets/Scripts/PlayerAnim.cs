using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAnim : MonoBehaviour
{
    [Header("attack settings")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask enemy;


    private Player player;
    private Animator anim;
    private Casting cast;
    private bool isHitting;
    private float timeCount;
    private float recoverTime;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
        cast = FindAnyObjectByType<Casting>();
        recoverTime = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        onMove();
        onRun();

        if (isHitting)
        {
            timeCount += Time.deltaTime;

            if (timeCount >= recoverTime)
            {
                isHitting = false;
                recoverTime = 0f;
            }
        }
    }

    #region moviment

    void onMove()
    {
        if (player.direction.sqrMagnitude > 0)
        {
            if (player.isRolling)
            {
                anim.SetTrigger("isRoll");
            }
            else
            {
                anim.SetInteger("transition", 1);
            }
        }
        else
        {
            anim.SetInteger("transition", 0);
        }

        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        if (player.IsCutting == true)
        {
            anim.SetInteger("transition", 3);
        }
        if (player.IsDigging == true)
        {
            anim.SetInteger("transition", 4);
        }
        if (player.IsWatering == true)
        {
            anim.SetInteger("transition", 5);
        }
    }

    void onRun()
    {
        if (player.isRunning)
        {
            anim.SetInteger("transition", 2);
        }

    }
    #endregion

    #region attack

    public void onAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, enemy);

        if (hit != null) {
            // procura os objetos filhos desse objeto
            hit.GetComponentInChildren<AnimController>().OnHit();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }

    #endregion

    // chamado quando o player precciona o botao
    public void OnCastingStarted()
    {
        anim.SetTrigger("IsCasting");
        player.isPaused = true;
    }

    // é chamado quando termina a animacao
    public void OnCastingEnded()
    {
        cast.OnCasting();
        player.isPaused = false;
    }

    public void OnHammaringStarted()
    {
        anim.SetBool("Hammering", true);
        player.isPaused = true;
    }

    public void OnHammaringEnded()
    {
        anim.SetBool("Hammering", false);
        player.isPaused = false;
    }

    public void onHit()
    {
        if (!isHitting)
        {
            anim.SetTrigger("hit");
            isHitting = true;
        }
    }
}
