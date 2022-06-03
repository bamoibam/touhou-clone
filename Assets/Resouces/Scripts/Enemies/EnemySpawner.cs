using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private SOActorTemplate actorModel;
    [SerializeField] private float spawnRate;
    [SerializeField] [Range(0, 100)] private int quantity;
    private GameObject enemy;

    [SerializeField] private bool GoDown = false;
    [SerializeField] private bool GoUp = false;
    [SerializeField] private bool GoRight = false;
    [SerializeField] private bool GoLeft = false;


    // Start is called before the first frame update
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    void OnEnable()
    {
        StartCoroutine(Spawner(quantity, spawnRate));
    }
    private IEnumerator Spawner(int quan, float spawnR)
    {
        for (int i = 0; i < quan; i++)
        {
            GameObject unit = Create();
            yield return new WaitForSeconds(spawnR);
        }
    }
    private GameObject Create()
    {
        enemy = GameObject.Instantiate(actorModel.actorSprite) as GameObject;
        enemy.GetComponent<Enemy>().Stats(actorModel);
        enemy.name = actorModel.actorName.ToString();
        enemy.gameObject.transform.SetParent(this.transform);
        enemy.transform.position = transform.position;

        if (GoDown)
        {
            //Add Up --> Down Movement
            enemy.AddComponent<UpDown>();
        }
        if (GoUp)
        {
            //Add Down --> Up Movement
            enemy.AddComponent<GoUp>();
        }
        if (GoRight)
        {
            //Add L --> R Movement
            enemy.AddComponent<LeftToRight>();
        }
        if (GoLeft)
        {
            //Add R --> L Movement
            enemy.AddComponent<RightToLeft>();
        }
        /*
         * Need to do Curve Move, Zig-zac, Circle, Stop & Resume, patrol move , change to other move 
         */
        return enemy;
    }
}
