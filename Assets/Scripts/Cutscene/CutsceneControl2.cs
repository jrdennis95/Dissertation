using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneControl2 : MonoBehaviour {

    public Camera cam1, cam2, cam3, cam4, cam5, cam6, cam7, cam8, cam9;
    public GameObject player, boss;
    Rigidbody rb;
    private Animator anim, bossanim;
    private Vector3 firstpos, secondpos, firstpos2, secondpos2, firstpos3, secondpos3;
    private bool firstscene = false;
    public float m_speed;
    public float m_runspeed;
    public bool skip;
    public Image chatbox1, chatbox2, chatbox3, chatbox4;
    public Text text1, text2, text3, text4, text5, text6, text7, text8, text9, text10, text11;
    //public Text t1, t2, t3, t4, t5, t6, t7, t8;
    public Text m_title;
    public Text m_skip;
    public Button m_start;
    float t1, t2, t3, t4, t5, t6, t7, t8, t9 = 0.0f;
    float fadetime = 0.0f;
    float starttime = 0.0f;
    float overalltime = 0.0f;
    float restarttime = 5.0f;
    bool frozen, frozen2, frozen3;
    // Use this for initialization
    void Start () {
        anim = player.GetComponent<Animator>();
        bossanim = boss.GetComponent<Animator>();
        rb = player.GetComponent<Rigidbody>();
        frozen = true;
        frozen2 = false;
        frozen3 = false;
        skip = false;
        restarttime = 5.0f;
        cam1.gameObject.SetActive(true);
        cam2.gameObject.SetActive(false);
        cam3.gameObject.SetActive(false);
        cam4.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(overalltime);
        overalltime += Time.deltaTime;
        if (overalltime > 0.1f && overalltime < 2.5f)
        {
            Vector3 pos1 = new Vector3(115.51f, 51.96103f, 95.36f);
            Vector3 pos2 = new Vector3(110.65f, 51.96103f, 97.13f);
            t1 += Time.deltaTime;
            player.transform.position = Vector3.Lerp(pos1, pos2, t1 / m_runspeed);
            anim.SetFloat("velocity", 1);
        }
        if (overalltime > 2.5f && overalltime < 4.7f)
        {
            cam1.gameObject.SetActive(false);
            cam2.gameObject.SetActive(true);
            anim.SetFloat("velocity", 0);
            player.transform.eulerAngles = new Vector3(0, -87.16f, 0);
            Vector3 pos1 = new Vector3(112.77f, 55.54f, 97.71f);
            Vector3 pos2 = new Vector3(112.77f, 53.72f, 97.71f);
            t2 += Time.deltaTime;
            cam2.gameObject.transform.position = Vector3.Lerp(pos1, pos2, t2 / 2);
        }
        if (overalltime > 4.7f && overalltime < 5.7f)
        {
            FadeIn(chatbox4, text1, 0, 1);
        }
        if (overalltime > 5.7f && overalltime < 6.7f)
        {
            FadeOut(chatbox4, text1, 0, 1);
        }
        if (overalltime > 6.7f && overalltime < 6.8f)
        {
            fadetime = 0;
            ResetColours();
            cam2.gameObject.SetActive(false);
            cam3.gameObject.SetActive(true);
            Vector3 pos1 = new Vector3(95.69103f, 53.16011f, 98.87218f);
            cam3.gameObject.transform.position = pos1;
        }
        if (overalltime > 6.8f && overalltime < 8.1f)
        {
            FadeIn(chatbox4, text2, 0, 1);
        }
        if (overalltime > 8.1f && overalltime < 9.2f)
        {
            FadeOut(chatbox4, text2, 0, 1);
        }
        if (overalltime > 9.2f && overalltime < 9.3f)
        {
            fadetime = 0;
            ResetColours();
        }
        if (overalltime > 9.3f && overalltime < 11.5f)
        {
            Vector3 pos1 = new Vector3(95.69103f, 53.16011f, 98.87218f);
            Vector3 pos2 = new Vector3(107.137f, 53.48811f, 97.64819f);
            t3 += Time.deltaTime;
            cam3.gameObject.transform.position = Vector3.Lerp(pos1, pos2, t3 / 2);
        }
        if (overalltime > 11.5f && overalltime < 12.6f)
        {
            FadeIn(chatbox2, text3, 1, 0);
        }
        if (overalltime > 12.6f && overalltime < 13.7f)
        {
            FadeOut(chatbox2, text3, 1, 0);
        }
        if (overalltime > 13.7f && overalltime < 14.0f)
        {
            fadetime = 0;
            ResetColours();
            cam3.gameObject.SetActive(false);
            cam4.gameObject.SetActive(true);
        }
        if (overalltime > 14.0f && overalltime < 15.1f)
        {
            FadeIn(chatbox4, text4, 0, 1);
        }
        if (overalltime > 15.1f && overalltime < 16.2f)
        {
            FadeOut(chatbox4, text4, 0, 1);
        }
        if (overalltime > 16.2f && overalltime < 16.5f)
        {
            fadetime = 0;
            ResetColours();
        }
        if (overalltime > 16.5f && overalltime < 20.0f)
        {
            cam4.gameObject.SetActive(false);
            cam5.gameObject.SetActive(true);
            Vector3 pos1 = new Vector3(96.70703f, 64.27811f, 98.77818f);
            Vector3 pos2 = new Vector3(114.717f, 64.27811f, 98.77818f);
            t4 += Time.deltaTime;
            cam5.gameObject.transform.position = Vector3.Lerp(pos1, pos2, t4 / 4.5f);
            FadeIn(chatbox4, text5, 0, 1);
        }
        if (overalltime > 20.0f && overalltime < 21.0f)
        {
            FadeOut(chatbox4, text5, 0, 1);
        }
        if (overalltime > 21.0f && overalltime < 21.1f)
        {
            fadetime = 0;
            ResetColours();
        }
        if (overalltime > 21.1f && overalltime < 22.2f)
        {
            cam5.gameObject.SetActive(false);
            cam6.gameObject.SetActive(true);
            FadeIn(chatbox2, text6, 1, 0);
        }
        if (overalltime > 22.2f && overalltime < 23.4f)
        {
            FadeOut(chatbox2, text6, 1, 0);
        }
        if (overalltime > 23.4f && overalltime < 23.5f)
        {
            fadetime = 0;
            ResetColours();
        }
        if (overalltime > 23.5f && overalltime < 25.2f)
        {
            cam6.gameObject.SetActive(false);
            cam7.gameObject.SetActive(true);
            FadeIn(chatbox4, text7, 0, 1);
        }
        if (overalltime > 25.2f && overalltime < 26.9f)
        {
            FadeOut(chatbox4, text7, 0, 1);
        }
        if (overalltime > 26.9f && overalltime < 28.6f)
        {
            t5 += Time.deltaTime;
            fadetime = 0;
            ResetColours();
            boss.transform.Rotate(new Vector3(0, t5 * 2, 0));
        }
        if (overalltime > 28.6f && overalltime < 30.8f)
        {
            FadeIn(chatbox4, text8, 0, 1);
            Vector3 pos1 = new Vector3(97.43703f, 53.10812f, 99.29818f);
            Vector3 pos2 = new Vector3(101.5f, 53.10812f, 99.29818f);
            Vector3 pos3 = new Vector3(96.44f, 51.96103f, 99.36f);
            Vector3 pos4 = new Vector3(99.23f, 51.96103f, 99.36f);
            t6 += Time.deltaTime;
            t7 += Time.deltaTime;
            cam7.gameObject.transform.position = Vector3.Lerp(pos1, pos2, t6 / 2f);
            bossanim.SetFloat("velocity", 1);
            boss.transform.position = Vector3.Lerp(pos3, pos4, t6 / 2);
        }
        if (overalltime > 30.8f && overalltime < 32.3f)
        {
            FadeOut(chatbox4, text8, 0, 1);
            bossanim.SetFloat("velocity", 0);
        }
        if (overalltime > 32.3f && overalltime < 33.6f)
        {
            fadetime = 0;
            ResetColours();
            Vector3 pos3 = new Vector3(103.12f, 51.96103f, 97.77f);
            boss.gameObject.transform.position = pos3;
            cam7.gameObject.SetActive(false);
            cam8.gameObject.SetActive(true);
            anim.SetBool("backup", true);
            Vector3 pos1 = new Vector3(110.65f, 51.96103f, 97.13f);
            Vector3 pos2 = new Vector3(111.37f, 51.96103f, 97.13f);
            t8 += Time.deltaTime;
            player.gameObject.transform.position = Vector3.Lerp(pos1, pos2, t8);
        }
        if (overalltime > 33.6f && overalltime < 34.7f)
        {
            anim.SetBool("backup", false);
            FadeIn(chatbox2, text9, 1, 0);
        }
        if (overalltime > 34.7f && overalltime < 35.8f)
        {
            FadeOut(chatbox2, text9, 1, 0);
        }
        if (overalltime > 35.8f && overalltime < 35.9f)
        {
            fadetime = 0;
            ResetColours();
            cam8.gameObject.SetActive(false);
            cam9.gameObject.SetActive(true);
        }
        if (overalltime > 35.9f && overalltime < 37.3f)
        {
            FadeIn(chatbox3, text10, 0, 1);
        }
        if (overalltime > 37.3f && overalltime < 38.7f)
        {
            FadeOut(chatbox3, text10, 0, 1);
        }
        if (overalltime > 38.7f && overalltime < 39.0f)
        {
            bossanim.SetTrigger("salute");
            fadetime = 0;
            ResetColours();
        }
        if (overalltime > 39.0f && overalltime < 40.2f)
        {
            FadeIn(chatbox3, text11, 0, 1);
        }
        if (overalltime > 40.02f && overalltime < 41.4f)
        {
            FadeOut(chatbox3, text11, 0, 1);
        }
        if (overalltime > 43f)
        {
            SceneManager.LoadScene(5);
        }

    }

    void FadeIn(Image i, Text t, int x, int y)
    {
        chatbox1.color = new Color(0, 0, 0, (fadetime += Time.deltaTime) * 2);
        i.color = new Color(1, 1, 1, (fadetime += Time.deltaTime) * 2);
        t.color = new Color(x, y, 0, (fadetime += Time.deltaTime) * 2);
    }

    void FadeOut(Image i, Text t, int x, int y)
    {
        chatbox1.color = new Color(0, 0, 0, (fadetime -= Time.deltaTime) * 2);
        i.color = new Color(1, 1, 1, (fadetime -= Time.deltaTime) * 2);
        t.color = new Color(x, y, 0, (fadetime -= Time.deltaTime) * 2);
    }

    void ResetColours()
    {
        chatbox1.color = new Color(0, 0, 0, 0);
        chatbox2.color = new Color(1, 1, 1, 0);
        chatbox3.color = new Color(1, 1, 1, 0);
        chatbox4.color = new Color(1, 1, 1, 0);
        text1.color = new Color(0, 1, 0, 0);
        text2.color = new Color(0, 1, 0, 0);
        text3.color = new Color(1, 0, 0, 0);
        text4.color = new Color(0, 1, 0, 0);
        text5.color = new Color(0, 1, 0, 0);
        text6.color = new Color(1, 0, 0, 0);
        text7.color = new Color(0, 1, 0, 0);
        text8.color = new Color(0, 1, 0, 0);
        text9.color = new Color(1, 0, 0, 0);
        text10.color = new Color(0, 1, 0, 0);
        text11.color = new Color(0, 1, 0, 0);
    }
    void FixedUpdate()
    {
    }


}
