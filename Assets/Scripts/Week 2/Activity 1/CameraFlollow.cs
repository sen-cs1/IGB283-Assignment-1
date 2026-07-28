using UnityEngine;

public class CameraFlollow : MonoBehaviour
{
    [SerializeField] private Transform straight;
    [SerializeField] private float xOffset;

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
        position.x = straight.transform.position.x + xOffset;
        transform.position = position;
    }
}
