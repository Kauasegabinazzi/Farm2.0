using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControls : MonoBehaviour
{
    [System.Serializable]
    public enum idiom
    {
        portugues,
        english,
        spanish
    }

    public idiom linguage;

    [Header("Components")]
    public GameObject dialogueOb; // janela dialogo
    public Image profileSprite; // sprite perfil
    public Text speechText; // texto fala
    public Text actorNameText; // nome npc

    [Header("Settings")]
    public float typingSpeed; // velocidade da fala

    //variaveis de controle
    public bool isShowing; // janela vizivel
    private int index; // index sentencia
    private string[] sentence;
    private string[] actorsName;
    private Sprite[] actorsProfile;

    public static DialogueControls instance;

    //awake é chamdo antes do start
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentence[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //pular para proxima fala
    public void NextSentence()
    {
        if (speechText.text == sentence[index]) {
            if (index < sentence.Length - 1) {
                index++;
                speechText.text = "";
                profileSprite.sprite = actorsProfile[index];
                actorNameText.text = actorsName[index];
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";
                index = 0;
                dialogueOb.SetActive(false);
                sentence = null;
                isShowing = false;
                actorNameText.text = "";
            }
        }
    }

    //chamar a fala do npc
    public void Speech(string[] txt, string[] actorName, Sprite[] actorProfile)
    {
        if (!isShowing)
        {
            dialogueOb.SetActive(true);
            sentence = txt;
            actorsName = actorName;
            actorsProfile = actorProfile;
            profileSprite.sprite = actorsProfile[index];
            actorNameText.text = actorsName[index];
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
