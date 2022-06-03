using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Create Sciprable Object(Actor)", menuName = "Create Sciprable Object(Actor)")]

public class SOActorTemplate : ScriptableObject
{
    public string actorName;
    public string description;
    public int health;
    public float speed;
    public int score;

    public GameObject actorSprite;
    public GameObject bulletSprite;

}
