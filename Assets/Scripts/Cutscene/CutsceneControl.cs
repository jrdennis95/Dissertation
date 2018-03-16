using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneControl : MonoBehaviour {

    public Camera first, second, third;
    public GameObject player;
    Rigidbody rb;
    private Animator anim;
    private Vector3 firstpos, secondpos, firstpos2, secondpos2, firstpos3, secondpos3;
    private bool firstscene = false;
    public float m_speed;
    public float m_runspeed;
    public bool skip;
    public Image chatbox1, chatbox2;
    public Text t1, t2, t3, t4, t5, t6, t7, t8;
    public Text m_title;
    public Text m_skip;
    public Button m_start;
    float t = 0.0f;
    float tt = 0.0f;
    float tt2 = 0.0f;
    float fadetime = 0.0f;
    float starttime = 0.0f;
    float overalltime = 0.0f;
    bool frozen, frozen2, frozen3;
    // Use this for initialization
    void Start () {
        anim = player.GetComponent<Animator>();
        rb = player.GetComponent<Rigidbody>();
        firstpos = first.transform.position;
        secondpos = firstpos - new Vector3(0, 10, 0);
        frozen = true;
        frozen2 = false;
        frozen3 = false;
        skip = false;
        m_skip.gameObject.SetActive(true);
        m_title.gameObject.SetActive(false);
        m_start.gameObject.SetActive(false);
        m_start.onClick.RemoveAllListeners();
        first.gameObject.SetActive(true);
        second.gameObject.SetActive(false);
        third.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            ResetColours();
            skip = true;
        }
        if (skip == false) {
            starttime += Time.deltaTime;
            overalltime += Time.deltaTime;
            //Debug.Log(fadetime);
            Debug.Log(overalltime);
            if (starttime > 0.1f && frozen) {
                anim.enabled = false;
            }
            if (overalltime > 0.1f && overalltime < 3.0f)
            {
                firstscene = true;
            }
            if (overalltime > 3.0f && overalltime < 3.5f)
            {
                chatbox1.color = new Color(0, 0, 0, (fadetime += Time.deltaTime) * 2);
                chatbox2.color = new Color(1, 1, 1, (fadetime += Time.deltaTime) * 2);
                t1.color = new Color(1, 0, 0, (fadetime += Time.deltaTime) * 2);
            }
            if (overalltime > 3.5f && overalltime < 4.0f)
            {
                chatbox1.color = new Color(0, 0, 0, (fadetime -= Time.deltaTime) * 2);
                chatbox2.color = new Color(1, 1, 1, (fadetime -= Time.deltaTime) * 2);
                t1.color = new Color(1, 0, 0, (fadetime -= Time.deltaTime) * 2);
            }
            if (overalltime > 4.0f && overalltime < 4.1f)
            {
                fadetime = 0.0f;
                //ResetColours();
            }
            if (overalltime > 4.5f && overalltime < 9.0f)
            {
                chatbox1.color = new Color(0, 0, 0, (fadetime += Time.deltaTime) * 2);
                chatbox2.color = new Color(1, 1, 1, (fadetime += Time.deltaTime) * 2);
                t2.color = new Color(1, 0, 0, (fadetime += Time.deltaTime) * 2);
                frozen = false;
                anim.enabled = true;
            }
            if (overalltime > 9.0f && overalltime < 9.2f)
            {
                fadetime = 2.0f;
                chatbox1.color = new Color(0, 0, 0, 1);
                chatbox2.color = new Color(1, 1, 1, 1);
                t2.color = new Color(1, 0, 0, 1);
            }
            if (overalltime > 9.2f && overalltime < 10.8f)
            {
                chatbox1.color = new Color(0, 0, 0, (fadetime -= Time.deltaTime) * 2);
                chatbox2.color = new Color(1, 1, 1, (fadetime -= Time.deltaTime) * 2);
                t2.color = new Color(1, 0, 0, (fadetime -= Time.deltaTime) * 2);
            }
            if (overalltime > 10.8f && overalltime < 11.5f)
            {
                ResetColours();
                player.transform.Rotate(Vector3.up * 110 * Time.deltaTime);
            }
            if (overalltime > 11.5f && overalltime < 11.6f)
            {
                fadetime = 0.0f;
            }
            if (overalltime > 11.6f && overalltime < 12.5f)
            {
                chatbox1.color = new Color(0, 0, 0, (fadetime += Time.deltaTime) * 2);
                chatbox2.color = new Color(1, 1, 1, (fadetime += Time.deltaTime) * 2);
                t3.color = new Color(1, 0, 0, (fadetime += Time.deltaTime) * 2);
            }
            if (overalltime > 12.5f && overalltime < 13.5f)
            {
                chatbox1.color = new Color(0, 0, 0, (fadetime -= Time.deltaTime) * 2);
                chatbox2.color = new Color(1, 1, 1, (fadetime -= Time.deltaTime) * 2);
                t3.color = new Color(1, 0, 0, (fadetime -= Time.deltaTime) * 2);
            }
            if (overalltime > 13.5f && overalltime < 13.6f)
            {
                ResetColours();
                fadetime = 0.0f;
                anim.SetBool("looking", true);
            }
            if (overalltime > 14.0f && overalltime < 15.0f)
            {
                chatbox1.color = new Color(0, 0, 0, (fadetime += Time.deltaTime) * 2);
                chatbox2.color = new Color(1, 1, 1, (fadetime += Time.deltaTime) * 2);
                t4.color = new Color(1, 0, 0, (fadetime += Time.deltaTime) * 2);
            }
            if (overalltime > 15.0f && overalltime < 15.1f)
            {
                anim.SetBool("looking", false);
            }
            if (overalltime > 15.1f && overalltime < 17.0f)
            {
                chatbox1.color = new Color(0, 0, 0, (fadetime -= Time.deltaTime) * 2);
                chatbox2.color = new Color(1, 1, 1, (fadetime -= Time.deltaTime) * 2);
                t4.color = new Color(1, 0, 0, (fadetime -= Time.deltaTime) * 2);
            }
            if (overalltime > 17.0f && overalltime < 17.1f)
            {
                ResetColours();
                fadetime = 0.0f;
                firstpos2 = player.transform.position;
                secondpos2 = player.transform.position - new Vector3(0, 0, 6);
                player.transform.Rotate(Vector3.up * 10);
            }
            if (overalltime > 17.1f && overalltime < 19.0f)
            {
                anim.SetFloat("velocity", 1);
                tt += Time.deltaTime;
                player.transform.position = Vector3.Lerp(firstpos2, secondpos2, tt / m_runspeed);
            }
            if (overalltime > 19.0f && overalltime < 20.0f)
            {
                chatbox1.color = new Color(0, 0, 0, (fadetime += Time.deltaTime) * 2);
                chatbox2.color = new Color(1, 1, 1, (fadetime += Time.deltaTime) * 2);
                t5.color = new Color(1, 0, 0, (fadetime += Time.deltaTime) * 2);
            }
            if (overalltime > 20.0f && overalltime < 21.0f)
            {
                chatbox1.color = new Color(0, 0, 0, (fadetime -= Time.deltaTime) * 2);
                chatbox2.color = new Color(1, 1, 1, (fadetime -= Time.deltaTime) * 2);
                t5.color = new Color(1, 0, 0, (fadetime -= Time.deltaTime) * 2);
            }
            if (overalltime > 21.0f && overalltime < 21.1f)
            {
                ResetColours();
                fadetime = 0.0f;
                firstpos3 = player.transform.position;
                secondpos3 = player.transform.position + new Vector3(0, 0, 6);
                player.transform.Rotate(Vector3.up * -30);
            }
            if (overalltime > 21.1f && overalltime < 23.0f)
            {
                tt2 += Time.deltaTime;
                player.transform.position = Vector3.Lerp(firstpos3, secondpos3, tt2 / m_runspeed);
            }
            if (overalltime > 23.0f && overalltime < 23.1f)
            {
                player.transform.Rotate(Vector3.up * 20);
                anim.SetFloat("velocity", 0);
            }
            if (firstscene)
            {
                t += Time.deltaTime;
                first.transform.position = Vector3.Lerp(firstpos, secondpos, t / m_speed);
            }

            if (overalltime > 23.1f && overalltime < 24.1f)
            {
                chatbox1.color = new Color(0, 0, 0, (fadetime += Time.deltaTime) * 2);
                chatbox2.color = new Color(1, 1, 1, (fadetime += Time.deltaTime) * 2);
                t6.color = new Color(1, 0, 0, (fadetime += Time.deltaTime) * 2);
            }
            if (overalltime > 24.1f && overalltime < 25.1f)
            {
                chatbox1.color = new Color(0, 0, 0, (fadetime -= Time.deltaTime) * 2);
                chatbox2.color = new Color(1, 1, 1, (fadetime -= Time.deltaTime) * 2);
                t6.color = new Color(1, 0, 0, (fadetime -= Time.deltaTime) * 2);
            }
            if (overalltime > 25.1f && overalltime < 25.2f)
            {
                ResetColours();
                fadetime = 0.0f;
            }
            if (overalltime > 25.2f && overalltime < 26.2f)
            {
                chatbox1.color = new Color(0, 0, 0, (fadetime += Time.deltaTime) * 2);
                chatbox2.color = new Color(1, 1, 1, (fadetime += Time.deltaTime) * 2);
                t7.color = new Color(1, 0, 0, (fadetime += Time.deltaTime) * 2);
            }
            if (overalltime > 26.2f && overalltime < 27.2f)
            {
                chatbox1.color = new Color(0, 0, 0, (fadetime -= Time.deltaTime) * 2);
                chatbox2.color = new Color(1, 1, 1, (fadetime -= Time.deltaTime) * 2);
                t7.color = new Color(1, 0, 0, (fadetime -= Time.deltaTime) * 2);
            }
            if (overalltime > 27.2f && overalltime < 27.3f)
            {
                ResetColours();
                fadetime = 0.0f;
            }
            if (overalltime > 27.3f && overalltime < 28.3f)
            {
                chatbox1.color = new Color(0, 0, 0, (fadetime += Time.deltaTime) * 2);
                chatbox2.color = new Color(1, 1, 1, (fadetime += Time.deltaTime) * 2);
                t8.color = new Color(1, 0, 0, (fadetime += Time.deltaTime) * 2);
            }
            if (overalltime > 28.3f && overalltime < 29.3f)
            {
                chatbox1.color = new Color(0, 0, 0, (fadetime -= Time.deltaTime) * 2);
                chatbox2.color = new Color(1, 1, 1, (fadetime -= Time.deltaTime) * 2);
                t8.color = new Color(1, 0, 0, (fadetime -= Time.deltaTime) * 2);
            }
            if (overalltime > 29.3f && overalltime < 29.4f)
            {
                ResetColours();
                fadetime = 0.0f;
                first.gameObject.SetActive(false);
                second.gameObject.SetActive(true);
            }
            if (overalltime > 29.4f && overalltime < 30.9f)
            {
                second.gameObject.transform.Rotate(Vector3.up * 110 * Time.deltaTime);
            }
            if (overalltime > 30.9f)
            {
                first.gameObject.SetActive(false);
                second.gameObject.SetActive(false);
                third.gameObject.SetActive(true);
                m_skip.gameObject.SetActive(false);
                m_title.gameObject.SetActive(true);
                m_start.gameObject.SetActive(true);
                m_start.onClick.AddListener(TaskOnClick);
            }
        } else
        {
            first.gameObject.SetActive(false);
            second.gameObject.SetActive(false);
            third.gameObject.SetActive(true);
            m_skip.gameObject.SetActive(false);
            m_title.gameObject.SetActive(true);
            m_start.gameObject.SetActive(true);
            m_start.onClick.AddListener(TaskOnClick);
        }
    }

    private void TaskOnClick()
    {
        SceneManager.LoadScene("Final");
    }

        void ResetColours()
    {
        chatbox1.color = new Color(0, 0, 0, 0);
        chatbox2.color = new Color(1, 1, 1, 0);
        t1.color = new Color(1, 0, 0, 0);
        t2.color = new Color(1, 0, 0, 0);
        t3.color = new Color(1, 0, 0, 0);
        t4.color = new Color(1, 0, 0, 0);
        t5.color = new Color(1, 0, 0, 0);
        t6.color = new Color(1, 0, 0, 0);
        t7.color = new Color(1, 0, 0, 0);
        t8.color = new Color(1, 0, 0, 0);
    }
    void FixedUpdate()
    {
    }


}
