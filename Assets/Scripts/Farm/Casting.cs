using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{
    [SerializeField] private bool detectingPlayer;
    [SerializeField] private int percentage; // procentagem de chance de pegar um peixe
    [SerializeField] private GameObject fishPrefab;

    private PlayerItens playerItens;
    private PlayerAnim playerAnim;



    // Start is called before the first frame update
    void Start()
    {
        playerItens = FindObjectOfType<PlayerItens>();
        playerAnim = FindObjectOfType<PlayerAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            playerAnim.OnCastingStarted();
        }
    }

    public void OnCasting()
    {
        int randomValue = Random.Range(1, 100);

        if (randomValue <= percentage)
        {
            Instantiate(fishPrefab, playerItens.transform.position + new Vector3(Random.Range(-2.5f,-1f), 0f,0f), Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
