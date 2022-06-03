using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public static int playerLives = 3;
    private PlayerSpawner playerSpawnObject;

    public static int currentScene = 0;
    public static int gameLevelScene = 3;

    private void Awake()
    {
        CheckIfGameManagerIsInTheScene();
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        LightAndCamera(currentScene);

    }

    private void CheckIfGameManagerIsInTheScene()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);
    }

    private void LightAndCamera(int sceneNo)
    {
        switch(sceneNo)
        {
            case 2: 
            case 3:
            case 4:
                {
                    Light();
                    Camera();
                    break;
                }
        }    
    }
    private void Light()
    {
        GameObject dirLight = GameObject.Find("Directional Light");
        dirLight.transform.eulerAngles = new Vector3(50, -30, 0);
        dirLight.GetComponent<Light>().type = LightType.Point;
        dirLight.GetComponent<Light>().range = 20;
        dirLight.GetComponent<Light>().intensity = 10;
    }
    private void Camera()
    {
        GetComponent<CameraManager>().Camera();
    }

    public void LostLive()
    {
        if (playerLives >= 0)
        {
            playerLives--;
            playerSpawnObject = GameObject.FindObjectOfType(typeof(PlayerSpawner)) as PlayerSpawner;
            playerSpawnObject.Create();
        }
        if (playerLives < 0)
        {
            GetComponent<ScenesManager>().GameOver();
            playerLives = 3;
        }
    }
}
