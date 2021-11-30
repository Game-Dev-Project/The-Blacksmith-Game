using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class textScript : MonoBehaviour
{
    /*public string textValue;
    public Text textElement;
    [SerializeField]
    float Start_Showing;
    [SerializeField]
    float duration;

    *//*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            Debug.Log("show text");
            textElement.text = textValue;
        }
    }*//*

    public void Hide()
    {

    }

    // Update is called once per frame
    void Update()
    {
       if(Time.time -Start_Showing >duration)
        {
            this.mesh
        }
    }*/
    private TextMeshPro activeBox = null;
    public TextMeshPro[] allTextBoxes;
    [SerializeField]
    float duration;
    private int index = 0;

    private void Start()
    {
        StartCoroutine(do_somthig());

    }
    private IEnumerator do_somthig()
    {
        foreach(TextMeshPro t in allTextBoxes)
        {
            activeBox = t;
            activeBox.color += new Color(0, 0, 0, 200);
            yield return new WaitForSeconds(duration/2);

            for (float i = duration / 2; i > 0; i--)
            {
                Debug.Log("Shield: " + i + " seconds remaining!");
                activeBox.color += new Color(0, 0, 0, -5);
                yield return new WaitForSeconds(1);
            }
        }
    }

    /*ublic IEnumerator show()
    {
        
    }

    public IEnumerator disapper()
    {
        
    }*/

}
