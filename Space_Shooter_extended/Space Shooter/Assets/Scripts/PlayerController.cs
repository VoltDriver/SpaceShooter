using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class PlayerController : MonoBehaviour
{
    #region Properties / Member Variables

    private Rigidbody m_rigidBody;
    // this value is controlled directly in Unity. We do NOT set it here, but in Unity, under the GameObject Player, in PlayerController Component (Script)
    public float m_speed;
    // Idem. Controls the tilt of the ship, when it moves.
    public float m_tilt;

    // This controls the fire rate.
    // Fire Rate is the time, in seconds, that it takes to ready another shot.
    public float m_fireRate = 0.5f;
    // NextFire is a value used to keep track of when the last shot was fired, and when we can fire another shot.
    // Because we want it to be solely handled by the code, we make it private
    private float m_nextFire = 0.0f;
    // Contains the boundaries of the play area
    public Boundary m_boundary;

    // Bound in unity to a Bolt GameObject.
    public GameObject m_shot;
    // unity will figure out that the object we link to that property has a transform, and that its the transform we want.
    public Transform m_shotSpawn;

    public AudioSource m_audio;

    #endregion

    private void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        m_audio = GetComponent<AudioSource>(); // This here allows us to play sounds.
    }

    // Usually, this method is SOLELY used for physics calculations. It is called according to a certain interval.
    // If you want to do something here that is NOT physics.... Use Update() instead.
    void FixedUpdate()
    {
        // This gets the Input of the player, between 0 and 1.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // We move the rigidBody by a certain vector. If this vector's values are between 0 and 1 for an axis, that means that you can
        // only move, at maximum, 1 unit per second on this axis.
        m_rigidBody.velocity = movement * m_speed;

        // Prevents the ship from leaving the play zone
        m_rigidBody.position = new Vector3
            (
                Mathf.Clamp(m_rigidBody.position.x, m_boundary.m_xMin, m_boundary.m_xMax),
                0, // We never move along the Y Axis.
                Mathf.Clamp(m_rigidBody.position.z, m_boundary.m_zMin, m_boundary.m_zMax)
            );

        // Rotates the ship, as it moves. Quaternion represents rotations of some degrees along the x, y, z axis. 
        m_rigidBody.rotation = Quaternion.Euler(0f, 0f, m_rigidBody.velocity.x * -m_tilt);
    }

    private void Update()
    {
        if ((Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space)) && Time.time > m_nextFire)
        {
            // The time we can fire our next shot is the current time, + the time it takes to ready another shot.
            m_nextFire = Time.time + m_fireRate;
            Instantiate(m_shot, m_shotSpawn.position, m_shotSpawn.rotation);
            // Play the pew pew sound.
            m_audio.Play();
        }
        
           
    }
}
