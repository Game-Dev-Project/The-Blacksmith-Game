using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_dialogue : MonoBehaviour
{
    public GameObject dialogueImage;
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
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject.Find("CanvasPress").SetActive(false);
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences;
            Vector3 Pos = Camera.main.WorldToScreenPoint(transform.position);
            Pos.y += 150;
            dialogueImage.transform.position = Pos;
            FindObjectOfType<dialogueSystem>().Dialogue();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueSystem.OutOfRange();
            this.gameObject.GetComponent<NPC_dialogue>().enabled = false;
        }
    }
}
