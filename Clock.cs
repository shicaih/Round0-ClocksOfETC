using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    Transform hourArmPivot, minuteArmPivot;

    [SerializeField]
    float hourArmSpeed = 10f, minuteArmSpeed = 60f, hourArmAcceleration = 1f, 
        minArmAcceleration = 10f, armCo = 0.2f;

    AudioSource hitAudio;

    private void Awake()
    {
        hitAudio = gameObject.GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hourY = hourArmPivot.localEulerAngles.y;
        float minuteY = minuteArmPivot.localEulerAngles.y;
        hourArmPivot.localEulerAngles = new Vector3(0, hourY + hourArmSpeed * Time.deltaTime, 0);
        minuteArmPivot.localEulerAngles = new Vector3(0, minuteY + minuteArmSpeed * Time.deltaTime, 0);

        hourArmSpeed += hourArmAcceleration * Time.deltaTime;
        minuteArmSpeed += minArmAcceleration * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("we hit sth");
        for (int i = 0; i < collision.contactCount; i++)
        {
            Vector3 contactPoint = collision.GetContact(0).point;
            Debug.Log(contactPoint);
            Vector3 targetPoint = collision.transform.position;
            Rigidbody rb = collision.rigidbody;
            rb.AddForce((targetPoint - contactPoint) * armCo * hourArmSpeed);
            hitAudio.Play();

        }

    }
}
