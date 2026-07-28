using UnityEngine;

public class Circle : MonoBehaviour
{
    public float minX = -5;
    public float maxX = 5;
    public float minY = -3;
    public float maxY = 3;

    private float movementFactorX;
    private float movementFactorY;

    private float startX;
    private float startY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float waveWidth = maxX - minX;
        float waveHeight = maxY - minY;

        movementFactorX = (transform.position.x - minX) / waveWidth;
        movementFactorY = (transform.position.y - minY) / waveHeight;

        startX = transform.position.x;
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 position = transform.position;

        position.x = startX + Mathf.Cos(movementFactorY + movementFactorX * maxX - Time.time) * movementFactorY;
        position.y = startY + Mathf.Sin(movementFactorY + movementFactorX * maxX - Time.time) * movementFactorY;

        transform.position = position;
    }
}
