using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] GameManager manager;
    [SerializeField] float health = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
        if (health <= 0)
        {
            Destroy(gameObject); 
            GameManager.instance.IncreaseScore(10);
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
            Destroy(collision.gameObject);
            health -= 1;
        }
    }
}
