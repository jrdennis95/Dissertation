using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTextScript : MonoBehaviour {

    private bool decaying;
    private GameObject boss;
    BossControl bc;
    private float decay;
	// Use this for initialization
	void Start () {
        decay = 2.0f;
        bc = GetComponent<BossControl>();
        boss = GetComponent<BossControl>().gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        if(bc.GetMeleePhaseText() || bc.GetFirePhaseText() || bc.GetIcePhaseText())
        {
            DisplaySpeech();
            bc.SetFirePhaseText(false);
            bc.SetMeleePhaseText(false);
            bc.SetIcePhaseText(false);
        }
        if (decaying)
        {
            decay -= Time.deltaTime;

            if (decay < 0)
            {
                HideSpeech();
                decaying = false;
            }
        }
	}

    private void DisplaySpeech()
    {
        if (bc.GetMeleePhaseText()) {
            boss.transform.root.GetChild(0).GetChild(0).gameObject.SetActive(true);
            boss.transform.root.GetChild(0).GetChild(1).gameObject.SetActive(true);
            decay = 2.0f;
            decaying = true;
        } else if (bc.GetFirePhaseText()){
            boss.transform.root.GetChild(0).GetChild(0).gameObject.SetActive(true);
            boss.transform.root.GetChild(0).GetChild(2).gameObject.SetActive(true);
            decay = 2.0f;
            decaying = true;
        } else if (bc.GetIcePhaseText())
        {
            boss.transform.root.GetChild(0).GetChild(0).gameObject.SetActive(true);
            boss.transform.root.GetChild(0).GetChild(3).gameObject.SetActive(true);
            decay = 2.0f;
            decaying = true;
        }
    }

    private void HideSpeech()
    {
        boss.transform.root.GetChild(0).GetChild(0).gameObject.SetActive(false);
        boss.transform.root.GetChild(0).GetChild(1).gameObject.SetActive(false);
        boss.transform.root.GetChild(0).GetChild(2).gameObject.SetActive(false);
        boss.transform.root.GetChild(0).GetChild(3).gameObject.SetActive(false);
    }

}
