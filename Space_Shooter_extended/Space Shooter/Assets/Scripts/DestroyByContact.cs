using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject m_explosion;
    public GameObject m_playerExplosion;
    public int m_scoreValue;
    private GameController m_gameController;

    private void Start()
    {
        // Scans our scene, finds the first object with this tag. This is always our gamecontroller.
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            // Attaching gamecontroller component to hazard.
            m_gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(m_gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Boundary is the tag issued to our game boundary object, in Unity. Boundary deletes objects that leaves it, as it is the game area.
        // In this case, we want our Destroy By contact to ignore the boundary.... As it is always in contact with it.
        if(other.tag == "Boundary")
        {
            return;
        }       
        // Player is the tag of the Player Game Object. This is a special case, to show the ship exploding if it comes into contact with the asteroid.
        if(other.tag == "Player")
        {
            Instantiate(m_playerExplosion, other.transform.position, other.transform.rotation);
            m_gameController.GameOver();
        }

        if(other.tag == "Asteroid")
        {
            Debug.Log("Boink");
        }
        m_gameController.AddScore(m_scoreValue);
        Instantiate(m_explosion, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
