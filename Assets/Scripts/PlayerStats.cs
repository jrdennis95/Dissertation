using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

    public int m_fullhealth;
    private int m_health;
    public int m_fulllives;
    private int m_lives;
    public int m_startscore;
    private int m_score;
    private bool m_hurt;
    SceneManager manager;
    // Use this for initialization
    void Start () {
        m_health = m_fullhealth;
        if (PlayerPrefs.HasKey("lives"))
        {
            m_lives = PlayerPrefs.GetInt("lives");
        } else
        {
            m_lives = m_fulllives;
        }

        if (PlayerPrefs.HasKey("score"))
        {
            m_score = PlayerPrefs.GetInt("score");
        }
        else
        {
            m_score = m_startscore;
        }
        m_hurt = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (m_lives == 0)
        {
            Kill();
        }

    }

    public void addHealth(int health)
    {
        m_health += health;
    }

    public void subtractHealth(int health)
    {
        AudioSource audio;
        audio = GetComponent<AudioSource>();
        AudioSource.PlayClipAtPoint(audio.clip, transform.position);
        m_health -= health;
        m_hurt = true;

        if (m_health <= 0 && m_lives > 0)
        {
            subtractLives(1);
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene(2);
            } else if (SceneManager.GetActiveScene().buildIndex == 6)
            {
                SceneManager.LoadScene(6);
            }
        }
    }

    public bool Hurt()
    {
        return m_hurt;
    }
    public void SetHurt(bool h)
    {
        m_hurt = h;
    }


    public void addLives(int lives)
    {
        m_lives += lives;
        PlayerPrefs.SetInt("lives", m_lives);
    }

    public void subtractLives(int lives)
    {
        m_lives -= lives;
        PlayerPrefs.SetInt("lives", m_lives);
    }

    public void addScore(int score)
    {
        m_score += score;
        PlayerPrefs.SetInt("score", m_score);
    }

    public void subtractScore(int score)
    {
        m_score -= score;
        PlayerPrefs.SetInt("score", m_score);
    }

    public int getHealth()
    {
        return m_health;
    }

    public int getLives()
    {
        return m_lives;
    }

    public int getScore()
    {
        return m_score;
    }


    public void Kill()
    {
        PlayerPrefs.SetInt("lives", 3);
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene(7);
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("lives", 3);
        PlayerPrefs.SetInt("score", 0);
    }
}
