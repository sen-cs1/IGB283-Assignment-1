using System.Reflection;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    [Header("Wave Bounds")]
    [SerializeField] private float minX = -5;
    [SerializeField] private float maxX = 5;

    [SerializeField] private float minY = -3;
    [SerializeField] private float maxY = 3;

    [Header("Circle Settings")]
    [Min(1)][SerializeField] private int xCount = 15;
    [Min(1)][SerializeField] private int yCount = 15;

    [SerializeField] private Circle CirclePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float xDistance = (maxX - minX) / xCount;
        float yDistance = (maxY - minY) / yCount;

        for (int row =  0; row < yCount; ++row)
        {
            Vector3 position = Vector3.zero;
            position.y = minY + row * yDistance;
            for (int col = 0;  col < xCount; ++col)
            {
                position.x = minX + col * xDistance;

                Circle circleInstance = Instantiate(CirclePrefab, position, Quaternion.identity);
                circleInstance.minX = minX;
                circleInstance.maxX = maxX;
                circleInstance.minY = minY;
                circleInstance.maxY = maxY;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
