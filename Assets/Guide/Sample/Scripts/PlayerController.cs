using UnityEngine;
using UnityEngine.InputSystem;

namespace GuideSample
{
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
            float x = 0f;
            float y = 0f;

            if (Keyboard.current.rightArrowKey.isPressed) x += 1f;
            if (Keyboard.current.leftArrowKey.isPressed) x -= 1f;
            if (Keyboard.current.upArrowKey.isPressed) y += 1f;
            if (Keyboard.current.downArrowKey.isPressed) y -= 1f;

            Vector2 input = new Vector2(x, y).normalized; // 斜め移動が速くなりすぎない
            rb.linearVelocity = input * speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("House"))
            {
                cleared = true;
            }
            else if (other.CompareTag("Enemy"))
            {
                death = true;
            }
        }
    }
}