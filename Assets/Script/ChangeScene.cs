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

    public Image _block;

    [Header("連接到某場景")]
    public string _scene;

    public float speed;
    bool have_audio = true;

    public static bool change_scene = false;


    void Start()
    {
        //_block = GameObject.Find("Block").GetComponent<Image>();

    }

    void Update()
    {

        if (_audio)
        {
            BGM_disappear();
            if (_block.color.a >= 1 && _audiosource.volume <= 0)
            {
                SceneManager.LoadSceneAsync(_scene);
                change_scene = true;
                _audio = false;
            }
        }
    }

    public void Start_game()
    {
        if (!_audio)
        {
            _audio = true;
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

    public void Exit()
    {
        Application.Quit();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !_audio)
        {
            _audio = true;
        }
    }

    void BGM_disappear()
    {
        _block.color += new Color(0, 0, 0, speed / 10 * Time.deltaTime);
        if (_audiosource != null)
            _audiosource.volume -= Time.deltaTime * speed / 10;
    }


}
