using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Buttonish : MonoBehaviour
{
    public UnityEvent pressed = new UnityEvent();
    public UnityEvent activate = new UnityEvent();
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Input.mousePosition, out hit, Mathf.Infinity, layerMask) && hit.collider.gameObject == gameObject)
        {
            Debug.DrawRay(Camera.main.transform.position, Input.mousePosition * hit.distance, Color.yellow);
            activate.Invoke();
            if (Input.GetMouseButtonDown(0))
            {
                pressed.Invoke();
            }
                
        }

    }
}
