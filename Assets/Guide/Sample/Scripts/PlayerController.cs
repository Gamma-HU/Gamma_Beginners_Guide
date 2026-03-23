using UnityEngine;
using UnityEngine.InputSystem;

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
        if(Keyboard.current.upArrowKey.isPressed)
        {
            //this.transform.Translate(0, speed, 0);
            rb.linearVelocity = new Vector2(0, speed);
        }
        if(Keyboard.current.downArrowKey.isPressed)
        {
            //this.transform.Translate(0, -speed, 0);
            rb.linearVelocity = new Vector2(0, -speed);
        }
        if(Keyboard.current.rightArrowKey.isPressed)
        {
            //this.transform.Translate(speed, 0, 0);
            rb.linearVelocity = new Vector2(speed, 0);
        }
        if(Keyboard.current.leftArrowKey.isPressed)
        {
            //this.transform.Translate(-speed, 0, 0);
            rb.linearVelocity = new Vector2(-speed, 0);
        }
        if(!Keyboard.current.upArrowKey.isPressed && !Keyboard.current.downArrowKey.isPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        }
        if(!Keyboard.current.rightArrowKey.isPressed && !Keyboard.current.leftArrowKey.isPressed)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
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
