using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private float speed;
    private int ToRight = -1;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(7.37f, 1.02f, 0);
        transform.localScale = new Vector3(1, 1, 1) * 1.2423f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition += ToRight * new Vector3(1, 0, 0) * Time.deltaTime * speed;
        newPosition.x = Mathf.Clamp(newPosition.x, -8, 8);
        transform.position = newPosition;
        if (transform.position.x < -7.5f)
        {
            ToRight = 1;
        }
        if (transform.position.x > 7.5f)
        {
            ToRight = -1;
        }
    }
}
