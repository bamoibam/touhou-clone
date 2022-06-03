using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private SOActorTemplate actorModel;
    private int health;
    private float speed;

    public void Stats(SOActorTemplate actorModel)
    {
        health = actorModel.health;
        speed = actorModel.speed;
    }

    private void Move()
    {
        transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
    }
    // Start is called before the first frame update
    void Awake()
    {
        Stats(actorModel);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void OnBecameInvisible()
    {
        Die();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (health > 1)
            {
                health--;
            }
            else
            {
                Die();
            }
        }
    }
    public void Die()
    {
        this.gameObject.SetActive(false); //using object pool
    }

}
