using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform followTransform;


    private void Start()
    {
        followTransform = GameObject.Find("Player").GetComponent<Transform>();
    }
    // Update is called once per frame
    private void LateUpdate()
    {
        this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);
    }
}
