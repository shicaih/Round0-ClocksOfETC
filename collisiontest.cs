using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisiontest : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("sth hit me!");
    }
}
