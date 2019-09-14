using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    // After this amount of seconds, the object is destroyed.
    public float m_lifetime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, m_lifetime);
    }

    
}
