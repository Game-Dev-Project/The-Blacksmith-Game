using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCdialogue : MonoBehaviour
{
    [SerializeField]
    public string Name;
    [TextArea(5, 10)]
    public string[] sentences;

    private dialogueSystem dialogueSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        dialogueSystem = FindObjectOfType<dialogueSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.GetComponent<NPCdialogue>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<dialogueSystem>().Dialogue();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueSystem.OutOfRange();
            this.gameObject.GetComponent<NPCdialogue>().enabled = false;
        }  
    }
}
