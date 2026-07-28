using UnityEngine;

public class Spiral : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float radius;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 position = transform.position;

        position.x += speed * Time.deltaTime;
        position.y = Mathf.Sin(position.x) * radius;
        position.z = Mathf.Cos(position.x) * radius;

        transform.position = position;
    }
}
