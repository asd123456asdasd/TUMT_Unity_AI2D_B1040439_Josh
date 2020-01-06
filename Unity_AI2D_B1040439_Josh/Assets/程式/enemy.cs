using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 50;

    private Rigidbody2D r2d;
    public Transform checkpoint;

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(checkpoint.position, -checkpoint.up * 2);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "play")
        {
            Track(collision.transform.position);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "play")
        {
            collision.gameObject.GetComponent<player>().Damage(damage);

            print("123");
        }
    }

    private void Move()
    {
        r2d.AddForce(-transform.right * speed);

        RaycastHit2D hit = Physics2D.Raycast(checkpoint.position, -checkpoint.up, 2, 1 << 8);

        if (hit == false)
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
        }
    }

    private void Track(Vector3 target)
    {
        if (target.x < transform.position.x)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
