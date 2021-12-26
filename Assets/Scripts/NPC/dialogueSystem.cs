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
    public GameObject dialogueImage;

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
        //dialogueImage = GameObject.Find("dialogueImage");
        /*Debug.Log("found" + dialogueImage.name);*/
        Debug.Log(this.name);
        outOfRange = false;
        dialogueImage.SetActive(true);
        /*Vector3 Pos = Camera.main.WorldToScreenPoint(transform.position);
        Pos.y += 150;
        dialogueImage.transform.position = Pos;*/
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
        if (outOfRange == false)
        {
            
            int dialogueLength = dialogueLines.Length;
            int currentDialogueIndex = 0;

            while (currentDialogueIndex < dialogueLength)
            {
                int currentdialogueLineLength = dialogueLines[currentDialogueIndex].Length;
                StartCoroutine(DisplayString(dialogueLines[currentDialogueIndex++]));

                if (currentDialogueIndex >= dialogueLength)
                {
                    dialogueEnded = true;
                }

                yield return new WaitForSeconds(currentdialogueLineLength*0.2f +0.5f); ;
            }
            DropDialogue();
        }
    }

    private IEnumerator DisplayString(string stringToDisplay)
    {
        if (outOfRange == false)
        {
            int stringLength = stringToDisplay.Length;
            int currentCharacterIndex = 0;

            dialogueText.text = "";

            while (currentCharacterIndex < stringLength)
            {
                dialogueText.text += stringToDisplay[currentCharacterIndex++];
                yield return new WaitForSeconds(0.1f);
            }
            yield return 0;
        }
    }

    public void DropDialogue()
    {
        //KeyToPrass.SetActive(false);
        dialogueImage.SetActive(false);
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
            dialogueImage.SetActive(false);
        }
    }
}
