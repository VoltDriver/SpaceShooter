using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    // Controls the max tumble, in Unity
    public float m_tumble;

    private Rigidbody m_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();

        // Angular velocity is how fast a rigid body object is rotating.
        m_rigidbody.angularVelocity = Random.insideUnitSphere * m_tumble; // Inside unit sphere gives a point inside a sphere. That's a vector, and so we use that to set the roation.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
