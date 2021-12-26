using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatToPrass : MonoBehaviour
{
    public GameObject KeyToPrass;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        KeyToPrass.SetActive(true);
        Vector3 Pos = Camera.main.WorldToScreenPoint(this.transform.position);
        Pos.y += 100;
        KeyToPrass.transform.position = Pos;
        this.gameObject.GetComponent<NPC_dialogue>().enabled=true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        KeyToPrass.SetActive(false);
        this.gameObject.GetComponent<NPC_dialogue>().enabled = false;
    }

}
