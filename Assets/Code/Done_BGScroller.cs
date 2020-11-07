using UnityEngine;
using System.Collections;

public class Done_BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
        Debug.Log(Mathf.Repeat(-10, 30)); // 20
        Debug.Log(Mathf.Repeat(0, 30));   // 0
        Debug.Log(Mathf.Repeat(10, 30));  // 10
        Debug.Log(Mathf.Repeat(30, 30));  // 0
        Debug.Log(Mathf.Repeat(50, 30));  // 20
        Debug.Log(Mathf.Repeat(140, 30)); // 20
    }
}