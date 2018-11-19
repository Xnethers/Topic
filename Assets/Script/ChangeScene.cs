using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    static public string _number;

    public AudioSource _audiosource;

    bool _audio;

    [Header("換場黑幕")]
    private GameObject _loadingCanvas;
    [SerializeField] private Image _block;

    [Header("連接的場景")]
    public string _scene;
    private AsyncOperation next_scene;
    [SerializeField] private int loading_scene;
    [Space(10)]
    private float speed;



    void Start()
    {
        _block = GameObject.FindWithTag("Block").GetComponent<Image>();
        _loadingCanvas = GameObject.FindObjectOfType<loading>().gameObject;

        if (_scene != null)
        {
            next_scene = SceneManager.LoadSceneAsync(_scene);
            next_scene.allowSceneActivation = false;
        }

        loading_scene = SceneUtility.GetBuildIndexByScenePath("Assets/Scene/loading");
    }

    void Update()
    {
        //Debug.Log(next_scene.progress);
        if (_audio)
        {
            BGM_disappear();
            if (_block.color.a >= 1 && _audiosource.volume <= 0)
            {
                _audio = false;
            }
        }
    }

    public void Start_game()
    {
        //Scene nowscene = SceneManager.GetActiveScene();

        if (!_audio)
        {
            _audio = true;
            //SceneManager.UnloadSceneAsync(nowscene);
            next_scene.allowSceneActivation = true;
        }
    }

    public void Continue_game()
    {
        if (!_audio)
        {
            _audio = true;
            if (_number != null)
            { SceneManager.LoadSceneAsync(_number); }
        }
    }

    public void Change_scene(string scene)
    { SceneManager.LoadSceneAsync(scene); }

    public void Exit()
    { Application.Quit(); }


    void BGM_disappear()
    {
        _block.color += new Color(0, 0, 0, speed / 10 * Time.deltaTime);

        if (_block.color.a >= 1)
        {
            _loadingCanvas.SetActive(true);
            next_scene.allowSceneActivation = true;
        }
        else
        {
            if (_audiosource != null)
                _audiosource.volume -= Time.deltaTime * speed / 10;
        }
    }


}
