using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] float xSpeed = 5;
    //[SerializeField] float ySpeed = 5;
    [SerializeField] GameManager manager;
    [SerializeField] GameObject enemyLaser;
    [SerializeField] float fireRate = 1f; // Set fire rate to 1 second
    private float nextFireTime = 0f; // Timer to track when to fire next

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, xSpeed, 0) * Time.deltaTime;

        if (Time.time >= nextFireTime)
        {
            Instantiate(enemyLaser, transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate; // Reset the fire timer
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
        
        if (collision.gameObject.tag == "Laser")
        {
            GameManager.instance.IncreaseScore(10);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
