using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PunchHand : MonoBehaviour
{
    public GameObject hand;
    private Rigidbody rBody;
    // Start is called before the first frame update
    void Start()
    {
        // hand = GameObject.Find("");
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rBody.MovePosition(hand.transform.position);
        rBody.MoveRotation(hand.transform.rotation);
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.LogError("HIT!");
        Rigidbody otherR = other.gameObject.GetComponentInChildren<Rigidbody>();
        if (other == null)
        {
            return;
        }
        Vector3 avgPoint = Vector3.zero;
        foreach (ContactPoint p in other.contacts)
        {
            avgPoint += p.point;
        }
        avgPoint /= other.contacts.Length;

        Vector3 dir = (avgPoint - transform.position).normalized;
        otherR.AddForceAtPosition(dir * 10f * rBody.velocity.magnitude, avgPoint);
    }
}
