using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    
    static public string _number;

    public AudioSource _audiosource;

    bool isloading;

    [Header("轉場黑幕")]
    [SerializeField] private Image _block;
    [SerializeField] private GameObject _loadingPanel;

    [Header("下一場景")]
    public string _scene;
    private AsyncOperation next_scene;
    private int loading_scene;
    [Space(10), SerializeField, Range(1, 20)]
    private int speed;
    int i = 0;
    Scene nowscene;



    void Start()
    {
        nowscene = SceneManager.GetActiveScene();
        _block = transform.FindChild("Canvas").FindChild("Block").GetComponent<Image>();
        _loadingPanel = GameObject.FindGameObjectWithTag("loadingPanel");
        _loadingPanel.SetActive(false);
    }

    void Update()
    {
        Shady();
        if (Input.GetKeyDown(KeyCode.F2))
        { StartFade(); }
        Debug.Log(nowscene.name);
        if (Input.GetKeyDown(KeyCode.F3))
            SceneManager.UnloadSceneAsync(nowscene);
    }

    public void StartFade()
    { i++; }

    public void Start_game()
    {
        if (!isloading)
        {
            isloading = true;
            //SceneManager.UnloadSceneAsync(nowscene);
            next_scene.allowSceneActivation = true;
        }

    }

    public void Continue_game()
    {
        if (!isloading)
        {
            isloading = true;
            if (_number != null)
            { SceneManager.LoadSceneAsync(_number); }
        }
    }

    public void Change_scene(string s)
    {
        next_scene = SceneManager.LoadSceneAsync(s);
        next_scene.allowSceneActivation = false;
        StartCoroutine(LoadScene());
    }



    public void Exit()
    { Application.Quit(); }

    void Shady()
    {
        switch (i)
        {
            case 1:
                {
                    _block.color += new Color(0, 0, 0, speed / 10 * Time.deltaTime);
                    if (_block.color.a >= 1)
                    { _loadingPanel.SetActive(true); Change_scene(_scene); i++; }
                }
                break;
            case 2:
                { }
                break;
            case 3:
                {
                    _block.color -= new Color(0, 0, 0, speed / 10 * Time.deltaTime);
                    if (_block.color.a <= 0)
                    {  i = 0; }
                    break;
                }
            default:
                { i = 0; break; }
        }
    }


    IEnumerator LoadScene()
    {
        while (true)
        {
            if (i == 2)
            {
                if (next_scene.progress >= 0.9f)
                {
                    yield return new WaitForSeconds(3);
                    next_scene.allowSceneActivation = true; 
                    _loadingPanel.SetActive(false);
                    i++;
                    yield return null;
                }
            }
            else
            { yield return null; }
        }

    }
}