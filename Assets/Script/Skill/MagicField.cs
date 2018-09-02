using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicField : SkillBasicData
{
    public Collider[] hitColliders;
    private Collider[] targetColliders;
    public Transform Rectangle_p;

    public ParticleSystem _particle;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //進入CD
        CDing();


        //獲取範圍內敵人
        hitColliders = Physics.OverlapSphere(transform.position, _distance, 1 << LayerMask.NameToLayer("Enemy"));


        if (CanUseSkill && Input.GetKey(KeyCode.Alpha3))
        { DrawTool.DrawCircle(Rectangle_p, Rectangle_p.localPosition, _distance); }//攻擊範圍標示

        if (Input.GetKeyUp(KeyCode.Alpha3))
        { UseSkill(); }

        if (CanUseSkill && isUse && isAnimation)
        {
            CostMP();
            _particle.Play(true);
            targetColliders = hitColliders;
            HitAnimatiom();
            settle();
            StartCD();
        }
        if (isAnimation)
        {
            DrawTool.EndDraw(Rectangle_p, false);
            isUse = false;
            isAnimation = false;
        }
    }

    void settle()//結算
    {
        int i;
        int _d = CalculateDamege();
        for (i = 0; i < hitColliders.Length; i++)
        { targetColliders[i].GetComponentInParent<Enemy_Health>()._health -= _d; show_damage(_d, targetColliders[i].transform.position); }
        isUse = false;
    }
    void HitAnimatiom()//打擊感
    {
        int j;
        for (j = 0; j < hitColliders.Length; j++)
        { targetColliders[j].GetComponentInParent<AI>().isHurt = true; }
    }

    /// <summary>  
    /// 不定点式圆形攻击  
    /// </summary>  
    /// <param name="attacked">被攻击方</param>  
    /// <param name="skillPosition">技能释放位置</param>  
    /// <param name="radius">半径</param>  
    /// <returns></returns>  
    public bool CircleAttack(Transform attacked, Transform skillPosition, float radius)
    {
        float distance = Vector3.Distance(attacked.position, skillPosition.position);
        if (distance < radius)
        {
            return true;
        }
        return false;
    }
}
