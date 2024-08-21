using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AnimController anim;

    [Header("Stats")]
    private Player player;
    public float totalHealth;
    public float currenthealth;
    public Image healthBar;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<Player>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;
        currenthealth = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            agent.SetDestination(player.transform.position);

            if (Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
            {
                // o inimigo para
                anim.PlayerAnim(2);
            }
            else
            {
                // o inimigo segue o player
                anim.PlayerAnim(1);
            }

            float x = player.transform.position.x - transform.position.x;

            if (x > 0)
            {
                transform.eulerAngles = new Vector3(0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180);
            }
        }
    }
}
