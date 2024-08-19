using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;
    bool playerHit;
    public DialogueSettings dialogue;
    private List<string> dialogueList = new List<string>();

    private void Start()
    {
        GetSpeaker();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DialogueControls.instance.Speech(dialogueList.ToArray());
        }
    }

    void GetSpeaker()
    {
        for (int i = 0; i < dialogue.dialogues.Count; i++)
        {
            switch (DialogueControls.instance.linguage)
            {
                case DialogueControls.idiom.portugues:
                    dialogueList.Add(dialogue.dialogues[i].sentence.portuguese);
                    break;
                case DialogueControls.idiom.english:
                    dialogueList.Add(dialogue.dialogues[i].sentence.english);
                    break;
                case DialogueControls.idiom.spanish:
                    dialogueList.Add(dialogue.dialogues[i].sentence.spanish);
                    break;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if (hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
