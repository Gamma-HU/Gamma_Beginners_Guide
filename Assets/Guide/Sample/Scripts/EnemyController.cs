using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector2 initPos;
    [SerializeField] private float haba = 1f;
    [SerializeField] private float speed = 0.5f;
    private int muki = 1;
    void Start()
    {
        initPos = this.transform.position;
    }

    void Update()
    {
        Vector2 currentPos = this.transform.position;
        currentPos += Vector2.right * muki * speed * Time.deltaTime;
        if(Mathf.Abs(currentPos.x - initPos.x) > haba) muki *= -1;
        this.transform.position = currentPos;
    }
}
