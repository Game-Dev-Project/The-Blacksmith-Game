using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PivotSwordPlayer : MonoBehaviour
{
    Camera cam;
    PhotonView view;

     private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        view = transform.parent.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            Vector2 dir = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.rotation = rotation;
        }
    }
}
