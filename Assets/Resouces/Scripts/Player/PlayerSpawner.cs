using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private SOActorTemplate actorModel;

    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        Create();
    }
    public void Create()
    {
        player = GameObject.Instantiate(actorModel.actorSprite) as GameObject;
        player.GetComponent<Player>().Stats(actorModel);
        player.name = "The Player";
        player.transform.SetParent(transform);
        player.transform.position = transform.position;
    }
}
