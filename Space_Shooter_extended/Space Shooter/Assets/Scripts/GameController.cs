using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // These are the asteroids we throw.
    public GameObject[] m_hazards;
    // 2 out of 3 of the values here are set in the Unity editor (y and z). X here represents the min and max value of the playing field.
    // X of each hazard is going to be generated from -X to X
    public Vector3 m_spawnValues;
    // number of times we spawn a hazard.
    public int m_hazardCount;

    // Time to wait between each hazard.
    public float m_spawnWait;
    // Time before we start spawning waves
    public float m_startWait;
    // Time between waves
    public float m_waveWait;

    // The text that shows score on the screen.
    public Text m_scoreText;
    private int m_score;

    public Text m_restartText;
    private bool m_restart;

    public Text m_gameOverText;
    private bool m_gameOver;


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(m_startWait);
        while(true)
        {
            for (int i = 0; i < m_hazardCount; i++)
            {
                // Here, we use m_spawnValues X to define the minimum and maximum range.
                Vector3 spawnPosition = new Vector3(Random.Range(-m_spawnValues.x, m_spawnValues.x), m_spawnValues.y, m_spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity; // Quaternion.identity represents "no rotation"
                Instantiate(m_hazards[Random.Range(0, m_hazards.Length)], spawnPosition, spawnRotation);

                yield return new WaitForSeconds(m_spawnWait);
            }
            yield return new WaitForSeconds(m_waveWait);

            if(m_gameOver)
            {
                m_restartText.text = "Press 'R' for Restart";
                m_restart = true;
                break;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {       
        m_score = 0;
        m_gameOver = false;
        m_restart = false;
        m_gameOverText.text = "";
        m_restartText.text = "";
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {
        if(m_restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                // Loads level or scene file. This loads the current level again.
                //Application.LoadLevel(Application.loadedLevel);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void AddScore(int pNewScoreValue)
    {
        m_score += pNewScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        m_scoreText.text = "Score: " + m_score;
    }
    
    public void GameOver()
    {
        m_gameOverText.text = "Game Over!";
        m_gameOver = true;
    }
}
