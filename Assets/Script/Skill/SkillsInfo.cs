using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ApplyType
{    //适用类型
    SingleTarget,
    MultiTarget
}

public enum ApplyProperty
{    //适用属性
    Attack,
    Aefense,
    AttackSpeed,
    HP,
    MP
}

public enum ReleaseType
{    //释放类型，对自身，敌人（需要鼠标指定）和某个位置（鼠标指定）
    Self,
    Enemy
}
public class SkillInfo : MonoBehaviour 
{    //技能信息表中对应的各条属性
    public int id;
    public string name;
    public string icon_name;
    public string des;
    public ApplyType applyType;
    public ApplyProperty applyProperty;
    public int applyValue;
    public int applyTime;
    public int mpCost;
    public int coldTime;
    public int level;
    public ReleaseType releaseType;
    public float releaseDistance;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}