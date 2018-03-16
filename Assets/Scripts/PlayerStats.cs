using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public int m_fullhealth;
    private int m_health;
    public int m_fulllives;
    private int m_lives;
    public int m_startscore;
    private int m_score;
    private bool m_hurt;
    // Use this for initialization
    void Start () {
        m_health = m_fullhealth;
        m_lives = m_fulllives;
        m_score = m_startscore;
        m_hurt = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addHealth(int health)
    {
        m_health += health;
    }

    public void subtractHealth(int health)
    {
        m_health -= health;
        m_hurt = true;

        if (m_health <= 0)
        {
            Kill();
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
    }

    public void subtractLives(int lives)
    {
        m_lives -= lives;
    }

    public void addScore(int score)
    {
        m_score += score;
    }

    public void subtractScore(int score)
    {
        m_score -= score;
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
        Destroy(gameObject);
    }
}
