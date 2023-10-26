using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool OnSurface = true;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-7.37f, -4.45f, 0);
        transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        if (Input.GetKey(KeyCode.W) && OnSurface)
        {
            newPosition += new Vector3(0, 1, 0) * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            newPosition = transform.position + new Vector3(3, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            newPosition = transform.position - new Vector3(3, 0, 0) * Time.deltaTime;
        }
        newPosition.x = Mathf.Clamp(newPosition.x, -8, 8);
        newPosition.y = Mathf.Clamp(newPosition.y, -5, 5);
        transform.position = newPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Surface")
        {
            OnSurface = true;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("You are dead!");
            SceneManager.LoadScene(1);
        }
        if (collision.gameObject.tag == "Coin")
        {
            Debug.Log("Victory!");
            SceneManager.LoadScene(2);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Surface")
        {
            OnSurface = false;
        }
    }
}
