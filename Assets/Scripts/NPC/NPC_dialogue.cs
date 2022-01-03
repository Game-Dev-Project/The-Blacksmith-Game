using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_dialogue : MonoBehaviour
{
    GameObject dialogueImage;
    GameObject dialugeGui;

    [SerializeField]
    public string Name;
    [TextArea(5, 10)]
    public string[] sentences;

    private dialogueSystem dialogueSystem;

    bool prassed = false;


    // Start is called before the first frame update
    void Start()
    {
        dialogueSystem = FindObjectOfType<dialogueSystem>();
        dialugeGui = GameObject.Find("dialogueGUI");
        dialogueImage = FindObject(dialugeGui, "dialogueImage");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && prassed == false)
        {
            prassed = true;
            GameObject.Find("CanvasPress").SetActive(false);
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences;
            Vector3 Pos = Camera.main.WorldToScreenPoint(transform.position);
            Pos.y += 150;
            dialogueImage.transform.position = Pos;
            FindObjectOfType<dialogueSystem>().Dialogue(dialogueImage);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(prassed ==true)
            {
                dialogueSystem.OutOfRange();
            }
            prassed = false;
            this.gameObject.GetComponent<NPC_dialogue>().enabled = false;
        }
    }

    public GameObject FindObject(GameObject parent, string name)
    {
        Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trs)
        {
            if (t.name == name)
            {
                return t.gameObject;
            }
        }
        return null;
    }
}
