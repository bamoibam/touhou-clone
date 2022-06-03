using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int health;
    private float speed;

    private bool invincible = true;

    private GameObject actorPrefab;
    private GameObject bulletPrefab;

    private float width;
    private float height;

    [SerializeField]private Animator animator;

    private GameObject playerParentObject;
    public void Stats(SOActorTemplate actorModel)
    {
        health = actorModel.health;
        speed = actorModel.speed;
        actorPrefab = actorModel.actorSprite;
        bulletPrefab = actorModel.bulletSprite;
    }

    // Start is called before the first frame update
    void Start()
    {
        height = 1 / (Camera.main.WorldToViewportPoint(new Vector2(1, 1)).y - 0.5f);
        width = 1 / (Camera.main.WorldToViewportPoint(new Vector2(1, 1)).x - 0.5f);
        playerParentObject = GameObject.Find("Player Object Pool");

        Collider2D collider2D = GetComponent<Collider2D>();
        collider2D.enabled = false;
        Invoke("NoMoreInvincible", 1.5f);
        StartCoroutine(BlinkGameObject(5, 0.1f));
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        float xMax = transform.position.x;
        float yMax = transform.position.y;

        if(horizontal == 0)
        {
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
        }

        if (horizontal > 0)
        {
            if (xMax < width /2.05f) //Stay within the width screen to avoid leaving the screen
            {
                transform.localPosition += speed * Time.deltaTime * new Vector3(horizontal, 0, 0);
            }
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
        }
        if (horizontal < 0)
        {
            if (xMax > -width /2.05f) //Stay within the width screen to avoid leaving the screen
            {
                transform.localPosition += speed * Time.deltaTime * new Vector3(horizontal, 0, 0);
            }
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
        }
        if (vertical > 0)
        {
            if (yMax < height / 2.2f) //Stay within the height screen to avoid leaving the screen
            {
                transform.localPosition += speed * Time.deltaTime * new Vector3(0, vertical, 0);

            }
        }
        if (vertical < 0)
        {
            if (yMax > -height / 2.2f) //Stay within the height screen to avoid leaving the screen
            {
                transform.localPosition += speed * Time.deltaTime * new Vector3(0, vertical, 0);
            }
        }
    }

    private void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //GameObject bullet = GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
            GameObject bullet = PlayerObjectPool.PlayerObjectInstance.GetPooledObject(); //using Object Pool
            if (bullet != null)
            {
                bullet.transform.SetParent(playerParentObject.transform);
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            if(health > 1)
            {
                health--;
                Debug.Log("Health: " + health);
            }
            if (health <= 1)
            {
                if (invincible == false)
                {
                    Die();
                }
            }
        }
        if (collision.CompareTag("EnemyBullet"))
        {
            if (health > 1)
            {
                health--;
                Debug.Log("Health: " + health);
            }
            if (health <= 1)
            {
                if (invincible == false)
                {
                    Die();
                }
            }
        }
    }
    private void Die()
    {
        GameManager.Instance.LostLive();
        Destroy(gameObject);
    }
    private void NoMoreInvincible()
    {
        invincible = false;
        GetComponent<Collider2D>().enabled = true;
    }
    public IEnumerator BlinkGameObject(int numBlinks, float seconds)
    {
        // In this method it is assumed that your game object has a SpriteRenderer component attached to it
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        // disable animation if any animation is attached to the game object
        //      Animator animator = gameObject.GetComponent<Animator>();
        //      animator.enabled = false; // stop animation for a while
        for (int i = 0; i < numBlinks * 2; i++)
        {
            //toggle renderer
            renderer.enabled = !renderer.enabled;
            //wait for a bit
            yield return new WaitForSeconds(seconds);
        }
        //make sure renderer is enabled when we exit
        renderer.enabled = true;
        //    animator.enabled = true; // enable animation again, if it was disabled before
    }
}
