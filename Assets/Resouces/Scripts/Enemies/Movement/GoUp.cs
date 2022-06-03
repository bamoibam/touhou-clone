using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUp : MonoBehaviour
{
    private float movement;
    private void Update()
    {
        Move();
    }

    public void Move()
    {
        movement = GetComponent<Enemy>().Speed;
        transform.localPosition += transform.up * movement * Time.deltaTime;
    }
}
