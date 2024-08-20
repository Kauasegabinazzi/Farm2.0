using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [Header("Itens")]
    [SerializeField] private Image waterUI;
    [SerializeField] private Image woodUI;
    [SerializeField] private Image carrotUI;
    [SerializeField] private Image fishUI;

    [Header("Tools")]

    [SerializeField] private Image axeUI;
    [SerializeField] private Image shoveUI;
    [SerializeField] private Image bucketUI;

    public List<Image> tools = new List<Image>();

    [SerializeField] private Color selectColor;
    [SerializeField] private Color alphaColor;

    private PlayerItens playerItens;
    private Player player;

    private void Awake()
    {
        playerItens = FindAnyObjectByType<PlayerItens>();
        player = playerItens.GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        waterUI.fillAmount = 0f;
        woodUI.fillAmount = 0f;
        carrotUI.fillAmount = 0f;
        fishUI.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        waterUI.fillAmount = playerItens.currentWater / playerItens.WaterLimit1;
        woodUI.fillAmount = playerItens.TotalWood / playerItens.WoodLimit;
        carrotUI.fillAmount = playerItens.carrots / playerItens.CarrotLimit;
        fishUI.fillAmount = playerItens.fishes / playerItens.FishesLimit;

        for (int i = 0; i < tools.Count; i++)
        {
            if (i == player.HandLingObj)
            {
                tools[i].color = selectColor;
            }
            else
            {
                tools[i].color = alphaColor;
            }
        }
    }
}
