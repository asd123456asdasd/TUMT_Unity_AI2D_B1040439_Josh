using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class player : MonoBehaviour
{
    public int speed = 150;
    public float jump = 50f;
    public bool pass = false;
    public bool isGround = false;
    public float hp = 100;

    private Rigidbody2D r2d;
    private Transform tra;
    public Animator ani;
    private AudioSource aud;

    public AudioClip coinsound;

    public Image hpBar;
    private float maxHP;

    public GameObject END;

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        tra = GetComponent<Transform>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();

        maxHP = hp;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) Turn(0);
        if (Input.GetKeyDown(KeyCode.A)) Turn(180);
    }

    private void FixedUpdate()
    {
        Walk();   
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
        Debug.Log("碰到" + collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coin")
        {
            Destroy(collision.gameObject);
            npc.count.count_player += 1;
            aud.PlayOneShot(coinsound, 0.5f);
        }
    }


    void Walk()
    {
        r2d.AddForce(new Vector2(speed * (Input.GetAxis("Horizontal")), 0));
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            isGround = false;
            r2d.AddForce(new Vector2(0, jump));
            ani.SetTrigger("jump");
        }
    }

    void Turn(int direction)
    {
        tra.eulerAngles = new Vector3(0, direction, 0);
    }

    public void Damage(float damage)
    {
        hp -= damage;
        hpBar.fillAmount = hp / maxHP;

        if (hp <= 0)
        {
            END.SetActive(true);
        }

    }
}
