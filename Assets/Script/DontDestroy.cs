using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy _instance;
    public GameObject player;
    public GameObject _camera;

    public GameObject camera_t;
    public Transform[] spawnPoint; //玩家出現位置

    List<GameObject> objs;
    List<GameObject> FindGameObjectsInLayer(int layer)
    {
        var goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        var goList = new System.Collections.Generic.List<GameObject>();
        for (int i = 0; i < goArray.Length; i++)
        {
            if (goArray[i].layer == layer)
            {
                goList.Add(goArray[i]);
            }
        }
        if (goList.Count == 0)
        {
            return null;
        }
        return goList;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "01")
        { player.transform.position = spawnPoint[0].position; }
        else if (scene.name == "02")
        {
            player.transform.position = spawnPoint[1].position;
            _camera.transform.position = spawnPoint[1].position;
            camera_t.transform.position = spawnPoint[1].position;
        }
        else if (scene.name == "03")
        {
            player.transform.position = spawnPoint[2].position;
            _camera.transform.position = spawnPoint[2].position;
            camera_t.transform.position = spawnPoint[2].position;
        }
    }


    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (_instance == null)
        { _instance = this; DontDestroyOnLoad(this.gameObject); }
        else if (this != _instance)
        { Destroy(gameObject); }

    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
