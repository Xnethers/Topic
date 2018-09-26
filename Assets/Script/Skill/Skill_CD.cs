using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//技能UI顯示
public class Skill_CD : MonoBehaviour
{
    public Image[] _skill;
    public Image[] _cD;

    public SkillBasicData[] _skillData;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < _skill.Length; i++)
        {
            _skill[i].sprite = _skillData[i]._sprite;
            _cD[i].fillAmount = _skillData[i].NowCD;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int j = 0; j < _skill.Length; j++)
        {
            _cD[j].fillAmount = _skillData[j].GetCDFlaot();
        }
    }
}
