using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Lingshi : MonoBehaviour
{
    public Text _count;
    public Sprite sprite_lingshi;

    private Image _image;

    // Use this for initialization
    void Start()
    {
        _image = GetComponent<Image>();
        _image.sprite = sprite_lingshi;
        _count = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _count.text = Bag.Lingshi.ToString("0");
    }
}
