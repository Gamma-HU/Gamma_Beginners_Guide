using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector2 initPos;
    [SerializeField] private float speed = 5f;

    private Rigidbody2D rb;

    [HideInInspector]
    public bool cleared = false;
    public bool death = false;
    void Start()
    {
        this.transform.position = initPos;
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        KeyCheck();
    }

    private void KeyCheck()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            //this.transform.Translate(0, speed, 0);
            rb.linearVelocity = new Vector2(0, speed);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            //this.transform.Translate(0, -speed, 0);
            rb.linearVelocity = new Vector2(0, -speed);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            //this.transform.Translate(speed, 0, 0);
            rb.linearVelocity = new Vector2(speed, 0);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            //this.transform.Translate(-speed, 0, 0);
            rb.linearVelocity = new Vector2(-speed, 0);
        }
        if(!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) &&!Input.GetKey(KeyCode.RightArrow) &&!Input.GetKey(KeyCode.LeftArrow))
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("House"))
        {
            cleared = true;
        }
        else if(other.CompareTag("Enemy"))
        {
            death = true;
        }
    }
}
