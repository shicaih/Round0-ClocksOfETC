using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class raytest : MonoBehaviour
{
    public Text text;
    Ray ray;
    RaycastHit hit;

    void FixedUpdate()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            
            if (hit.collider.gameObject.tag == "Exit")
            {
                Debug.Log("Exit");
            }
            else if (hit.collider.gameObject.tag == "NewGame")
            {
                Debug.Log("NewGame");
            }
            if (Input.GetMouseButtonDown(0))
                print(hit.collider.name);
        }
    }
}
