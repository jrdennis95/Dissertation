using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIScript : MonoBehaviour {

    private PlayerStats stats;
    public Text UIscore, UIlives;
    public Slider UIhealth;
    public Image UIhurt, UIshield;
    private Color hurtColourOn, shieldColourOn, hurtColourOff, shieldColourOff ;
    public float m_decaySpeed;
    bool shielded = false;

    // Use this for initialization
    void Start () {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        hurtColourOn = new Color(1f, 0f, 0f, 0.39f);
        shieldColourOn = new Color(0f, 0.54f, 1f, 0.39f);
    }
	
	// Update is called once per frame
	void Update () {
        UIscore.text = stats.getScore().ToString("D3");
        UIlives.text = stats.getLives().ToString();
        UIhealth.value = stats.getHealth();

        if (stats.Hurt())
        {
            UIhurt.color = hurtColourOn;
        } else
        {
            UIhurt.color = Color.Lerp(UIhurt.color, Color.clear, m_decaySpeed * Time.deltaTime);
        }

        if (shielded)
        {
            UIshield.color = shieldColourOn;
        }
        else
        {
            UIshield.color = Color.Lerp(UIshield.color, Color.clear, m_decaySpeed * Time.deltaTime);
        }
        stats.SetHurt(false);
        shielded = false;
    }
}
