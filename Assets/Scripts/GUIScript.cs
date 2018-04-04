using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIScript : MonoBehaviour {

    private PlayerStats stats;
    public Text UIscore, UIlives;
    public Slider UIhealth;
    public GameObject UIpaused;
    public Button m_button1, m_button2;
    public Image UIhurt, UIshield;
    private Color hurtColourOn, hurtColourOff;
    public float m_decaySpeed;
    bool paused = false;

    // Use this for initialization
    void Start () {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        hurtColourOn = new Color(1f, 0f, 0f, 0.39f);
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

        stats.SetHurt(false);

        if (Input.GetKey("escape") && paused == false)
        {
            paused = true;
            UIpaused.SetActive(true);
            m_button1.onClick.AddListener(TaskOnClick1);
            m_button2.onClick.AddListener(TaskOnClick2);
            Time.timeScale = 0;
        }

    }

    private void TaskOnClick1()
    {
        paused = false;
        Time.timeScale = 1;
        UIpaused.SetActive(false);
        m_button1.onClick.RemoveAllListeners();
        m_button2.onClick.RemoveAllListeners();
    }

    private void TaskOnClick2()
    {
        paused = false;
        Time.timeScale = 1;
        UIpaused.SetActive(false);
        m_button1.onClick.RemoveAllListeners();
        m_button2.onClick.RemoveAllListeners();
        PlayerPrefs.SetInt("lives", 3);
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene(0);
    }

}
