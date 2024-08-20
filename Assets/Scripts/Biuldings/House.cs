using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [Header("Amouts")]
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float timeAmout;
    [SerializeField] private int woodAmout;

    [Header("Components")]
    [SerializeField] private SpriteRenderer houseSprite;
    [SerializeField] private Transform point;
    [SerializeField] private GameObject house;


    private bool detectingPlayer;
    private PlayerItens playerItens;
    private PlayerAnim playerAnim;
    private float timeCount;
    private bool isBeggining;

    // Start is called before the first frame update
    void Start()
    {
        playerItens = FindAnyObjectByType<PlayerItens>();
        playerAnim = playerItens.GetComponent<PlayerAnim>();
        isBeggining = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E) && playerItens.TotalWood >= woodAmout)
        {
            isBeggining = true;
            playerAnim.OnHammaringStarted();
            houseSprite.color = startColor;
            playerItens.transform.position = point.position;
            playerItens.TotalWood -= woodAmout;
        }

        if (isBeggining)
        {
            timeCount += Time.deltaTime;

            if (timeCount >= timeAmout) {
                playerAnim.OnHammaringEnded();
                houseSprite.color = endColor;
                house.SetActive(true);
            }
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
