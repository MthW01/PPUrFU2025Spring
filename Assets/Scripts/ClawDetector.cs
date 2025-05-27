using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawDetector : MonoBehaviour
{
    public bool Contacting => Bodies.Count > 0;

    public List<Rigidbody> Bodies;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null)
        {
            Bodies.Add(collision.rigidbody);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.rigidbody != null)
        {
            Bodies.Remove(collision.rigidbody);
            if (collision.rigidbody.isKinematic)
            {
                collision.rigidbody.isKinematic = false;
                collision.transform.parent = null;
            }
        }
    }
}