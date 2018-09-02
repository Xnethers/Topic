using UnityEngine;
using System.Collections.Generic;

public class DrawTool : MonoBehaviour
{
    void Start()
    { GetShader(); }
    void Update() { }

    private static LineRenderer GetLineRenderer(Transform t)
    {
        LineRenderer lr = t.GetComponent<LineRenderer>();
        if (lr == null)
        {
            lr = t.gameObject.AddComponent<LineRenderer>();
        }
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.material = _material;
        return lr;
    }

    public static void DrawLine(Transform t, Vector3 start, Vector3 end)
    {
        LineRenderer lr = GetLineRenderer(t);
        lr.positionCount = 2;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }

    //绘制空心扇形    
    public static void DrawSector(Transform t, Vector3 center, float angle, float radius)
    {
        LineRenderer lr = GetLineRenderer(t);
        int pointAmount = 100;//点的数目，值越大曲线越平滑    
        float eachAngle = angle / pointAmount;
        Vector3 forward = t.forward;
        lr.enabled = true;
        lr.positionCount = pointAmount;
        lr.SetPosition(0, center);
        lr.SetPosition(pointAmount - 1, center);

        for (int i = 1; i < pointAmount - 1; i++)
        {
            Vector3 pos = Quaternion.Euler(0f, -angle / 2 + eachAngle * (i - 1), 0f) * forward * radius + center;
            lr.SetPosition(i, pos);
        }
    }

    //绘制空心圆    
    public static void DrawCircle(Transform t, Vector3 center, float radius)
    {
        LineRenderer lr = GetLineRenderer(t);
        lr.enabled = true;
        int pointAmount = 100;//点的数目，值越大曲线越平滑    
        float eachAngle = 360f / pointAmount;
        Vector3 forward = t.forward;
        lr.transform.SetParent(t);
        lr.positionCount = pointAmount + 1;

        for (int i = 0; i <= pointAmount; i++)
        {
            Vector3 pos = Quaternion.Euler(0f, eachAngle * i, 0f) * forward * radius + center;
            lr.SetPosition(i, pos);
        }
    }

    //绘制空心长方形  
    //以长方形的底边中点为攻击方位置(从俯视角度来看)  
    public static void DrawRectangle(Transform t, Vector3 bottomMiddle, float length, float width)
    {
        LineRenderer lr = GetLineRenderer(t);
        lr.enabled = true;
        lr.positionCount = 4;
        lr.SetPosition(0, bottomMiddle - new Vector3((width / 2), 0, 0));
        lr.SetPosition(1, bottomMiddle + new Vector3(-(width / 2), 0, length));
        lr.SetPosition(2, bottomMiddle + new Vector3((width / 2), 0, length));
        lr.SetPosition(3, bottomMiddle + new Vector3((width / 2), 0, 0));
    }

    public static GameObject go;
    public static MeshFilter mf;
    public static MeshRenderer mr;
    //public Shader shader;
    public Material material;
    public static Material _material;

    void GetShader()
    {
        _material = material;
    }

    private static GameObject CreateMesh(List<Vector3> vertices, Transform t)
    {
        int[] triangles;
        Mesh mesh = new Mesh();

        int triangleAmount = vertices.Count - 2;
        triangles = new int[3 * triangleAmount];

        //根据三角形的个数，来计算绘制三角形的顶点顺序（索引）      
        //顺序必须为顺时针或者逆时针      
        for (int i = 0; i < triangleAmount; i++)
        {
            triangles[3 * i] = 0;//固定第一个点      
            triangles[3 * i + 1] = i + 1;
            triangles[3 * i + 2] = i + 2;
        }

        if (go == null)
        {
            go = new GameObject("mesh");
            go.transform.SetParent(t);
            go.transform.localPosition = new Vector3(0, 0f, 0);//让绘制的图形上升一点，防止被地面遮挡  
            mf = go.AddComponent<MeshFilter>();
            mr = go.AddComponent<MeshRenderer>();
            //shader = Shader.Find("Particles/Additive");
        }

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles;

        mf.mesh = mesh;
        //mr.material.shader = _shader;
        mr.material = _material;
        mr.material.color = Color.red;

        return go;
    }

    //绘制实心扇形    
    public static void DrawSectorSolid(Transform t, Vector3 center, float angle, float radius)
    {
        int pointAmount = 100;//点的数目，值越大曲线越平滑    
        float eachAngle = angle / pointAmount;
        Vector3 forward = t.forward;

        List<Vector3> vertices = new List<Vector3>();
        vertices.Add(center);

        for (int i = 1; i < pointAmount - 1; i++)
        {
            Vector3 pos = Quaternion.Euler(0f, -angle / 2 + eachAngle * (i - 1), 0f) * forward * radius + center;
            vertices.Add(pos);
        }

        CreateMesh(vertices, t);
    }

    //绘制实心圆    
    public static void DrawCircleSolid(Transform t, Vector3 center, float radius)
    {
        int pointAmount = 100;//点的数目，值越大曲线越平滑    
        float eachAngle = 360f / pointAmount;
        Vector3 forward = t.forward;

        List<Vector3> vertices = new List<Vector3>();

        for (int i = 0; i <= pointAmount; i++)
        {
            Vector3 pos = Quaternion.Euler(0f, eachAngle * i, 0f) * forward * radius + center;
            vertices.Add(pos);
        }

        CreateMesh(vertices, t);
    }

    //绘制实心长方形  
    //以长方形的底边中点为攻击方位置(从俯视角度来看)  
    public static void DrawRectangleSolid(Transform t, Vector3 bottomMiddle, float length, float width)
    {
        List<Vector3> vertices = new List<Vector3>();
        vertices.Add(-new Vector3((width / 2), 0, 0));
        vertices.Add(new Vector3(-(width / 2), 0, length));
        vertices.Add(new Vector3((width / 2), 0, length));
        vertices.Add(new Vector3((width / 2), 0, 0));
        CreateMesh(vertices, t);

        go.SetActive(false);
    }
    public static void EndDraw(Transform t, bool ismesh)
    {
        LineRenderer lr = t.GetComponent<LineRenderer>();
        if (!ismesh)
            lr.enabled = false;

        if (ismesh)
            go.SetActive(false);
    }

    public static void Draw(Transform t, bool ismesh)
    {
        LineRenderer lr = t.GetComponent<LineRenderer>();
        if (!ismesh)
            lr.enabled = true;

        if (ismesh)
            go.SetActive(true);
    }
}