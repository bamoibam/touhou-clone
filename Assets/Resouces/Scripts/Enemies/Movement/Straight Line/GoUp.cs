using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUp : MonoBehaviour
{
    private float speed;
    private float acceleration;
    private void Update()
    {
        Move();
    }

    public void Move()
    {
        speed = GetComponent<Enemy>().Speed;
        acceleration = GetComponent<Enemy>().Acceleration;
        transform.localPosition += transform.up * speed * acceleration * Time.deltaTime;
    }
}
