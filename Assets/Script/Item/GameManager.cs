//游戏管理
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//枚举游戏状态，运行和暂停
public enum GameState
{
    Running,
    Pause
}
public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public GameState gamestate = GameState.Running;//游戏状态，包括运行暂停
    public Inventory inventory;
    public Item[] itemToAdd;

    void Awake()
    {
        _instance = this;
    }
    //测试添加删除物品
    private void Update()
    {
        //F1:添加物品
        if (Input.GetKeyDown(KeyCode.F1))
        {
            foreach (Item j in itemToAdd)
                inventory.AddItem(j);
        }
        //F2到下一關

        //F3無敵
       
        //按ESC暂停游戏
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _instance.TransformGameState();
        }
    }
    //改变游戏的运行状态，运行与暂停
    public void TransformGameState()
    {
        if (gamestate == GameState.Running)
        {
            Time.timeScale = 0;
            gamestate = GameState.Pause;
        }
        else if (gamestate == GameState.Pause)
        {
            Time.timeScale = 1;
            gamestate = GameState.Running;
        }
    }
}