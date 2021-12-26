using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialogueSystem : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    //public GameObject KeyToPrass;
    public Transform dialogueGUI;

    public float letterDelay = 0.1f;
    public float letterMultiplier = 0.5f;

    public KeyCode DialogueInput = KeyCode.F;

    public string Names;

    public string[] dialogueLines;

    public bool letterIsMultiplied = false;
    public bool dialogueActive = false;
    public bool dialogueEnded = false;
    public bool outOfRange = true;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = "";
    }

    /*public void EnterRangeOfNPC()
    {
        outOfRange = false;
        KeyToPrass.SetActive(true);
        if (dialogueActive == true)
        {
            KeyToPrass.SetActive(false);
        }
    }*/
    public void Dialogue()
    {
        outOfRange = false;
        dialogueGUI.gameObject.SetActive(true);
        Vector3 Pos = Camera.main.WorldToScreenPoint(this.transform.position);
        Pos.y += 150;
        GameObject.Find("dialogueImage").transform.position = Pos;
        NPCName();
        /*if (Input.GetKeyDown(DialogueInput))
        {
            if (!dialogueActive)
            {
                dialogueActive = true;
                StartCoroutine(StartDialogue());
            }
        }*/

        StartCoroutine(StartDialogue());
    }


    public void NPCName()
    {
        nameText.text = Names;
        return;
    }

    private IEnumerator StartDialogue()
    {
        Debug.Log("hyyy");
        if (outOfRange == false)
        {
            
            int dialogueLength = dialogueLines.Length;
            int currentDialogueIndex = 0;

            while (currentDialogueIndex < dialogueLength)
            {
                StartCoroutine(DisplayString(dialogueLines[currentDialogueIndex++]));

                if (currentDialogueIndex >= dialogueLength)
                {
                    dialogueEnded = true;
                }

                yield return new WaitForSeconds(5f); ;
            }

           /* while (true)
            {
                if (Input.GetKeyDown(DialogueInput) && dialogueEnded == false)
                {
                    break;
                }
                yield return 0;
            }*/
            /*dialogueEnded = false;
            dialogueActive = false;*/
            DropDialogue();
        }
    }

    private IEnumerator DisplayString(string stringToDisplay)
    {
        Debug.Log(stringToDisplay);
        if (outOfRange == false)
        {
            int stringLength = stringToDisplay.Length;
            int currentCharacterIndex = 0;

            dialogueText.text = "";

            while (currentCharacterIndex < stringLength)
            {
                dialogueText.text += stringToDisplay[currentCharacterIndex++];
                yield return new WaitForSeconds(5f);
            }
            /*while (true)
            {
                if (Input.GetKeyDown(DialogueInput))
                {
                    break;
                }
                yield return 0;
            }
            dialogueEnded = false;
            letterIsMultiplied = false;
            dialogueText.text = "";*/
            yield return 0;
        }
    }

    public void DropDialogue()
    {
        //KeyToPrass.SetActive(false);
        dialogueGUI.gameObject.SetActive(false);
    }

    public void OutOfRange()
    {
        outOfRange = true;
        if (outOfRange == true)
        {
            letterIsMultiplied = false;
            dialogueActive = false;
            StopAllCoroutines();
            //KeyToPrass.SetActive(false);
            dialogueGUI.gameObject.SetActive(false);
        }
    }
}
