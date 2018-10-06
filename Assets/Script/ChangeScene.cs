using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    static public string _number;

    public AudioSource _audiosource;
    private AsyncOperation next_scene;

    bool _audio;

    public Image _block;

    [Header("連接到某場景")]
    public float speed;
    bool have_audio = true;

    public static bool change_scene = false;


    void Start()
    {
        //_block = GameObject.Find("Block").GetComponent<Image>();
        /* 
        if (_scene != null)
        {
            next_scene = SceneManager.LoadSceneAsync(_scene);
            next_scene.allowSceneActivation = false;
        }*/
    }

    void Update()
    {
        //Debug.Log(next_scene.progress);
        if (_audio)
        {
            BGM_disappear();
            if (_block.color.a >= 1 && _audiosource.volume <= 0)
            {
                change_scene = true;
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
            {
                change_scene = true;
                SceneManager.LoadSceneAsync(_number);
            }
        }
    }

    public void Change_scene(string scene)
    { SceneManager.LoadSceneAsync(scene); }

    public void Exit()
    { Application.Quit(); }


    void BGM_disappear()
    {
        _block.color += new Color(0, 0, 0, speed / 10 * Time.deltaTime);
        if (_audiosource != null)
            _audiosource.volume -= Time.deltaTime * speed / 10;
    }


}
