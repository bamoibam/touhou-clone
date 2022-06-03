using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesSpawn : MonoBehaviour
{
    [SerializeField] private List<SpawnInfo> List = new List<SpawnInfo>();

    [Serializable]
    public class SpawnInfo
    {
        public GameObject gameObj;
        public float afterDelay;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < List.Count; i++)
        {
            List[i].gameObj.SetActive(true);
            yield return new WaitForSeconds(List[i].afterDelay);
        }
    }
}
