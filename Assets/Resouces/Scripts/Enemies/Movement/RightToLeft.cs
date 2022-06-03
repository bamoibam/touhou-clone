using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightToLeft : MonoBehaviour
{
    private float movement;
    private void Update()
    {
        Move();
    }

    public void Move()
    {
        movement = GetComponent<Enemy>().Speed;
        transform.localPosition += -transform.right * movement * Time.deltaTime;
    }
}
