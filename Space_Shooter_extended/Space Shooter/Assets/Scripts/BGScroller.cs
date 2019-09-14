using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    // Speed at which it will scroll
    public float m_scrollSpeed;

    // The size of the Background, along the Z axis.
    public float m_tileSizeZ;
    private Vector3 m_startPosition;


    // Start is called before the first frame update
    void Start()
    {
        m_startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Repeat is like a modulo, but not defined for negative numbers, and works with floating point numbers.
        float newPosition = Mathf.Repeat(Time.time * m_scrollSpeed, m_tileSizeZ);
        transform.position = m_startPosition + Vector3.forward * newPosition;
        /* So here, we scroll the background in the following way:
        * We calculate a new position. This is actually just a number that we will use to multiply a vector.
        * This new position, is always different because it is based on time elapsed. So it changes ever so slightly every frame.
        * But we never want it to be larger than our tile... Otherwise, when we add the vectors, they are gonna reach outside our background. No bueno.
        * Then, once we have our multiplier (new position) we construct the real new position of our background. How do we do that?
        * Well we want to move it along the Z axis, forward (so vector3.forward which is (0,0,1). This vector does not change X or Y, only Z.
        * Then we multiply that vector by our multiplier. That will tell us how much it has to move (our bg) from it's start position.
        * And then we update the current position by adding the Start Position with our new vector. */
    }
}
