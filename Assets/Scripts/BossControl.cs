using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour {

    private float movement;
    public float m_speed;
    bool grounded = false;
    public Transform m_feet;
    public float m_jump;
    private bool m_shielded;
    bool taunted, leftdirection, above;
    Animator anim;
    Rigidbody rb;
    public float threephasetimer;
    private float timer, timer2, timer3;
    private float m_distance;
    private bool startcasting;
    public LayerMask m_ground, m_platform;
    Collider[] groundArray, platformArray;
    private GameObject player;
    public GameObject JumpArea1, JumpArea2;
    public GameObject shield;
    private Material mat;
    public bool meleephase, firephase, icephase;
    private bool lastphasenotmelee, lastphasenotfire;
    private bool[] threephaseselecter;
    public bool meleephasetext, firephasetext, icephasetext;
    public int phaseNo;
    public bool seeking, needtojump, needtofall;
    Vector3 q;
    //public GameObject boss;

    // Use this for initialization
    void Start () {
        startcasting = false;
        timer3 = threephasetimer;
        meleephase = true;
        meleephasetext = true;
        lastphasenotmelee = true;
        lastphasenotfire = true;
        threephaseselecter = new bool[] { meleephase, firephase, icephase };
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        mat = shield.GetComponent<Renderer>().material;
        taunted = false;
        leftdirection = true;
        above = false;
        timer = 0;
        timer2 = 0;
        timer3 = 0;
        q = ClosestPad();
    }
	
	// Update is called once per frame
	void Update () {
        if (timer3 <= 0)
        {
            if (lastphasenotmelee) {
                m_shielded = false;
                meleephase = true;
                meleephasetext = true;
                firephase = false;
                icephase = false;
                timer3 = threephasetimer;
                lastphasenotmelee = false;
            } else
            {
                if (lastphasenotfire)
                {
                    m_shielded = true;
                    meleephase = false;
                    firephase = true;
                    firephasetext = true;
                    icephase = false;
                    timer3 = threephasetimer;
                    lastphasenotmelee = true;
                    lastphasenotfire = false;
                }else{
                    m_shielded = true;
                    meleephase = false;
                    firephase = false;
                    icephase = true;
                    icephasetext = true;
                    timer3 = threephasetimer;
                    lastphasenotmelee = true;
                    lastphasenotfire = true;
                }
            }
        } else
        {
            timer3 -= Time.deltaTime;
        }
        
        if (meleephase) {
            Melee();
        } else if (firephase){
            Fireball();
        } else if (icephase){
            Ice();
        }
    }


    private void OnTriggerStay(Collider hit)
    {

    }

    public bool getDirection()
    {
        return leftdirection;
    }

    private void Fireball()
    {
        GetToTop();
        if (phaseNo == 5)
        {
            if (timer3 < threephasetimer - 6.0f && timer3 > 0)
            {
                startcasting = true;
                anim.SetBool("casting", true);
                shield.gameObject.SetActive(true);
                rb.constraints = RigidbodyConstraints.FreezeAll;
                mat.mainTextureOffset = new Vector2(0, Time.time * 0.2f);
            }
            else if (timer3 < 0)
            {
                startcasting = false;
                anim.SetBool("casting", false);
                shield.gameObject.SetActive(false);
                rb.constraints = RigidbodyConstraints.None;
                rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                transform.Rotate(new Vector3(0, -90, 0));
                phaseNo = 1;
                firephase = false;
            }
        }
    }

    private void Ice()
    {
        GetToTop();
        if (phaseNo == 5)
        {
            if (timer3 < threephasetimer-6.0f && timer3 > 0)
            {
                startcasting = true;
                anim.SetBool("casting", true);
                shield.gameObject.SetActive(true);
                rb.constraints = RigidbodyConstraints.FreezeAll;
                mat.mainTextureOffset = new Vector2(0, Time.time * 0.2f);
            }
            else if (timer3 < 0)
            {
                startcasting = false;
                anim.SetBool("casting", false);
                shield.gameObject.SetActive(false);
                rb.constraints = RigidbodyConstraints.None;
                rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                transform.Rotate(new Vector3(0, -90, 0));
                phaseNo = 1;
                icephase = false;
            }
        }
    }

    private void Melee()
    {
        float distbetween = Vector3.Distance(transform.position, player.transform.position);
        if (distbetween > 1.8f)
        {
            seeking = true;
        } else {
            seeking = false;
        }
        GetIntoPosition(q);
        LookAt(player.transform.position);
        HeightChange();
    }

    private void GetToTop()
    {
        if (timer2 <= 0)
        {
            timer2 = 0;
        }
        else
        {
            timer2 -= Time.deltaTime;
        }
        Vector3 bottom = new Vector3(105.8f, transform.position.y, transform.position.z);
        Vector3 right = new Vector3(109.5f, transform.position.y, transform.position.z);
        Vector3 top = new Vector3(105.8f, 53.41f, transform.position.z);
        float distbetween1 = Vector3.Distance(transform.position, bottom);
        float distbetween2 = Vector3.Distance(transform.position, right);
        float distbetween3 = Vector3.Distance(transform.position, top);
        if (phaseNo == 1)
        {
            anim.SetFloat("velocity", 1);
            LookAt(bottom);
            transform.position = Vector3.Lerp(transform.position, bottom, m_speed / 75);
            if (distbetween1 < 0.37f)
            {
                phaseNo = 2;
            }
        }
        else if (phaseNo == 2)
        {
            LookAt(right);
            transform.position = Vector3.Lerp(transform.position, right, m_speed / 75);
            if (distbetween2 < 0.37f)
            {
                needtojump = false;
                anim.SetFloat("velocity", 0);
                phaseNo = 3;
            }
        }
        else if (phaseNo == 3)
        {
            LookAt(top);
            Jump();
            timer2 = 1.0f;
            phaseNo = 4;
        }
        else if (phaseNo == 4 && timer2 <= 0)
        {
            needtojump = true;
            DiagonalJump(true);
            transform.Rotate(new Vector3(0, 90, 0));
            phaseNo = 5;
        }
    }

    private void FixedUpdate()
    {
        if (timer <= 0)
        {
            timer = 0;
        }
        else
        {
            timer -= Time.deltaTime;
        }

        groundArray = Physics.OverlapSphere(m_feet.position, 0.2f, m_ground);
        platformArray = Physics.OverlapSphere(m_feet.position, 0.2f, m_platform);

        if (groundArray.Length > 0 || platformArray.Length > 0)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, m_distance + 0.1f);
    }

    void LookAt(Vector3 position)
    {
            Vector3 tempscale = transform.localScale;
            if (position.x < transform.position.x)
            {
                movement = -1;
                tempscale.z = Mathf.Abs(transform.localScale.z);
                transform.localScale = tempscale;
            }
            else if (position.x > transform.position.x)
            {
                movement = 1;
                tempscale.z = Mathf.Abs(transform.localScale.z) * -1;
                transform.localScale = tempscale;
            }  
    }

    public void Jump()
    {
        if (grounded && timer <= 0 && needtojump)
        {
            grounded = false;
            rb.AddForce(new Vector3(0, m_jump, 0));
        }
        timer = 0.1f;
    }

    public void LargeJump()
    {
        if (grounded && timer <= 0 && needtojump)
        {
            grounded = false;
            rb.AddForce(new Vector3(0, m_jump * 2, 0));
        }
        timer = 0.2f;
    }

    public void DiagonalJump(bool leftdir)
    {
        if (leftdir)
        {
            if (grounded && timer2 <= 0 && needtojump)
            {
                grounded = false;
                rb.AddForce(new Vector3(-m_jump/2, m_jump, 0));
            }
            timer = 0.1f;
        }
        else
        {
            if (grounded && timer <= 0 && needtojump)
            {
                grounded = false;
                rb.AddForce(new Vector3(m_jump/2, m_jump, 0));
            }
            timer = 0.1f;
        }
    }

    void HeightChange()
    {
        if (player.transform.position.y > transform.position.y){
            needtojump = true;
            needtofall = false;
        }
        else if(player.transform.position.y < transform.position.y) {
            needtojump = false;
            needtofall = true;
        } else if(player.transform.position.y == transform.position.y)
        {
            needtojump = false;
            needtofall = false;
        }
    }

    public bool GetNeedToFall()
    {
        return needtofall;
    }

    public bool GetNeedToJump()
    {
        return needtojump;
    }

    public void NeedToJump()
    {
        needtojump = true;
    }

    public bool GetCasting()
    {
        return startcasting;
    }

    public Vector3 ClosestPad()
    {
        float dist1 = Vector3.Distance(JumpArea1.transform.position, transform.position);
        float dist2 = Vector3.Distance(JumpArea2.transform.position, transform.position);
        if (dist1 < dist2)
        {
            return JumpArea1.GetComponent<Collider>().transform.position;
        }
        else if (dist2 < dist1)
        {
            return JumpArea2.GetComponent<Collider>().transform.position;
        } else
        {
            return Vector3.zero;
        }
    }

    public void GetIntoPosition(Vector3 g)
    {
        if (seeking)
        {
            anim.SetFloat("velocity", 1);
            rb.velocity = new Vector3(movement * m_speed, rb.velocity.y, 0);
        } else
        {
            anim.SetFloat("velocity", 0);
        }
    }


    private void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag == "Player") {
        Physics.IgnoreCollision(GetComponent<Collider>(), hit.collider);
            }
    }

    public bool GetShielded()
    {
        return m_shielded;
    }

    public void SetShielded(bool t)
    {
        m_shielded = t;
    }
    public float GetSpeed()
    {
        return m_speed;
    }

    public float GetJumpHeight()
    {
        return m_jump;
    }

    public bool GetSeeking()
    {
        return seeking;
    }

    public void SetSeeking(bool t)
    {
        seeking = t;
    }

    public bool GetMeleePhaseText()
    {
        return meleephasetext;
    }

    public bool GetFirePhaseText()
    {
        return firephasetext;
    }

    public bool GetIcePhaseText()
    {
        return icephasetext;
    }

    public void SetMeleePhaseText(bool t)
    {
        meleephasetext = t;
    }

    public void SetFirePhaseText(bool t)
    {
        firephasetext = t;
    }

    public void SetIcePhaseText(bool t)
    {
        icephasetext = t;
    }

    public int GetPhaseNo()
    {
        return phaseNo;
    }
    public bool GetMeleePhase()
    {
        return meleephase;
    }

    public bool GetFirePhase()
    {
        return firephase;
    }

    public bool GetIcePhase()
    {
        return icephase;
    }

}
