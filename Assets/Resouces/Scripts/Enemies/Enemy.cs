using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health;
    private float speed;
    private float bulletRate = 0.5f;
    private int score;
    private GameObject actorPrefab;
    private GameObject bulletPrefab;

    private GameObject enemyParentObject;

    public void Stats(SOActorTemplate actorModel)
    {
        health = actorModel.health;
        speed = actorModel.speed;
        actorPrefab = actorModel.actorSprite;
        bulletPrefab = actorModel.bulletSprite;
        score = actorModel.score;
    }
    
    public float Speed
    {
        get
        {
            return speed;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //enemyParentObject = GameObject.Find("Enemy Bullet");
        enemyParentObject = GameObject.Find("Enemy Object Pool");
        StartCoroutine(Fire(bulletRate));
    }

    private void Bullet()
    {
        //GameObject bullet = GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        GameObject bullet = ObjectPool.ObjectInstance.GetPooledObject(); //using Object Pool
        if (bullet != null)
        {
            bullet.transform.SetParent(enemyParentObject.transform);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
        }
    }

    private IEnumerator Fire(float spawnR)
    {
        while (this.gameObject != null)
        {
            Bullet();
            yield return new WaitForSeconds(spawnR);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            if (health > 1)
            {
                health--;
            }
            else
            {
                Die();
                GameManager.Instance.GetComponent<ScoreManager>().SetScore(score);
            }
        }
    }
    public void Die()
    {
        Destroy(this.gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
