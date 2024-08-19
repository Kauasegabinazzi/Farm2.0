using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRender;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;

    [Header("Settings")]
    [SerializeField] private int digAmout; // quantidade vezes de escavação
    [SerializeField] private bool detecting;
    [SerializeField] private float waterAmout;

    private int initialDig;
    private float currentWater;
    private bool dugHole;

    PlayerItens playerItens;

    // Start is called before the first frame update
    void Start()
    {
        playerItens = FindObjectOfType<PlayerItens>();
        initialDig = digAmout;
    }

    // Update is called once per frame
    void Update()
    {
        if (dugHole)
        {
            if (detecting)
            {
                currentWater += 0.01f;
            }

            //enche o total de agua necessario
            if (currentWater >= waterAmout)
            {
                //plantar cenoura
                spriteRender.sprite = carrot;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    spriteRender.sprite = hole;
                    playerItens.carrots++;
                    currentWater = 0f;
                }
            }
        }
    }

    public void OnHit()
    {
        digAmout--;

        if (digAmout <= initialDig / 2)
        {
            spriteRender.sprite = hole;
            dugHole = true;
        }

        //if (digAmout <= 0)
        //{
        //    //plantar cenoura
        //    spriteRender.sprite = carrot;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("dig"))
        {
            OnHit();
        }

        if (collision.CompareTag("water"))
        {
            detecting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("water"))
        {
            detecting = false;
        }
    }
}
