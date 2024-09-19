using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float horizontalSpeed = 2;
    [SerializeField] float directionChangeInterval = 1f;
    private float direction = -1;
    private float directionChangeTimer;

    [SerializeField] GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        directionChangeTimer = directionChangeInterval;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;

        transform.position += new Vector3(direction * horizontalSpeed, 0, 0) * Time.deltaTime;
        directionChangeTimer -= Time.deltaTime;
        if (directionChangeTimer <= 0)
        {
            direction *= -1;
            directionChangeTimer = directionChangeInterval;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.OnServerInitialized();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Laser")
        {
            GameManager.instance.IncreaseScore(10);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
