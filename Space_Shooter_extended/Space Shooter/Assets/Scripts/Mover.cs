using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody m_rigidbody;
    public float m_speed;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();

        m_rigidbody.velocity = transform.forward * m_speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
