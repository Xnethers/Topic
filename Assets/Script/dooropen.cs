using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
/*附加腳本時自動生成AudioSource元件*/
[RequireComponent(typeof(AudioSource))]
public class dooropen : MonoBehaviour
{
    [Header("聲音")]
    public AudioClip open_sound;
    public AudioClip closs_sound;
    private AudioSource _audioSource;
    public bool islock;
    [Header("Check Box")]
    public Vector3 Scale = new Vector3(2, 3, 2);
    public Vector3 Center = new Vector3(-0.8f, 2.0f, 0);

    private Animator _animator;
    public bool can_open;

    Inventory _bag;
    int i;

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        _bag = GameObject.FindObjectOfType<Inventory>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //_animator.SetBool("open", true);
            _audioSource.PlayOneShot(open_sound);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {_animator.SetBool("open", true);}
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _animator.SetBool("open", false);
            _audioSource.PlayOneShot(closs_sound);
        }
    }
}

