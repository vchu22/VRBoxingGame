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
}
