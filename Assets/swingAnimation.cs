using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swingAnimation : MonoBehaviour
{
    protected float currentTime = 0f;
    [SerializeField] public float timeBetweenSpawns = 0.5f;
    [SerializeField] public KeyCode keyToPress;
    private Animator sordAnimation;
    // Start is called before the first frame update
    void Start()
    {
        sordAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress) && Time.time > currentTime + timeBetweenSpawns)
        {
            //show animation
            //sordAnimation.SetTrigger("SwingSord");

            currentTime = Time.time;
        }
    }
}
