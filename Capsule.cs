using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{

    public GameObject parController;
    public AudioSource pickupAudio;
    public GameManager gm;
    
    float deltaHeight = 1f;

    
    MeshRenderer render;

    private void Awake()
    {
        render = GetComponent<MeshRenderer>();
            parController.SetActive(false);
    }

    private void Update()
    {
        Vector3 localPos = transform.localPosition;
        localPos.y = gm.capHeight;
        transform.localPosition = localPos;
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("sth hit me");
        render.enabled = false;
        transform.gameObject.GetComponent<Collider>().enabled = false;
        parController.SetActive(true);
        pickupAudio.Play();
        gm.capHeight += deltaHeight;
        gm.collectable -= 1;
    }
}
