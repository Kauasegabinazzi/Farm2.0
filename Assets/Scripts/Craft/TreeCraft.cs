using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private int totalWood;
    [SerializeField] private ParticleSystem leafs;
    private bool isDead;
    public void OnHit()
    {
        treeHealth--;

        anim.SetTrigger("IsHit");
        leafs.Play();

        if (treeHealth <= 0)
        {
            for (int i = 0; i < totalWood; i++)
            {
                Instantiate(woodPrefab, transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0f), transform.rotation);
            }

            //cria o toco e instancia os drops
            anim.SetTrigger("IsCut");

            isDead = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("axe") && !isDead)
        {
            OnHit();
        }
    }
}
