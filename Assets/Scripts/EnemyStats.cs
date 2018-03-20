using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyStats : MonoBehaviour {

    public int m_fullhealth;
    private int m_health;
    public int m_fullstrength;
    private int m_strength;
    public bool lootable;
    public GameObject death, loot;
    private GameObject go;
    private bool m_hurt;
    public Slider m_healthslider;
    public EnemyControl control;
    // Use this for initialization
    void Start () {
        control = GetComponent<EnemyControl>();
        m_health = m_fullhealth;
        m_strength = m_fullstrength;
        m_healthslider.maxValue = m_fullhealth;
        m_healthslider.value = m_health;
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void subtractHealth(int health)
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            m_healthslider.gameObject.SetActive(true);
            health = health / m_strength;

            if (health <= 0)
            {
                return;
            }
            else
            {
                m_health -= health;
                m_healthslider.value = m_health;
            }

            if (m_health <= 0)
            {
                Kill();
            }
        } else
        {
            health = health / m_strength;

            if (health <= 0)
            {
                return;
            }
            else
            {
                m_health -= health;
                m_healthslider.value = m_health;
            }

            if (m_health <= 0)
            {
                Kill();
            }
        }

    }

    public void Kill()
    {
        Vector3 temprotation = transform.localEulerAngles;
        go = Instantiate(death) as GameObject;
        go.transform.SetParent(transform.parent.gameObject.transform);
        go.transform.localScale = transform.localScale;
        go.transform.localPosition = transform.localPosition;
        if (control.getDirection())
        {
            temprotation.y = Mathf.Abs(transform.localEulerAngles.y);
            death.transform.localEulerAngles = temprotation;
        }
        else
        {
            temprotation.y = Mathf.Abs(transform.localEulerAngles.y) *-1;
            death.transform.localEulerAngles = temprotation;
        };

        Destroy(gameObject);
        if (lootable)
        {
            go = Instantiate(loot) as GameObject;
            go.transform.position = transform.position + new Vector3(0,0.5f,0);
        }
    }
}
