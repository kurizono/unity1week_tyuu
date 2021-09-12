using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleHumanMove : MonoBehaviour
{
    MusicBox musicboxcs;

    AudioSource audioSource;

    float[] movespeed = new float[2];
    float[] movespeedRange = new float[2] { 1.0f, 2.0f };


    //�f�ނ�ς���
    SpriteRenderer MainSpriteRenderer;
    public Sprite Health, Sick, boy;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        MainSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        GameObject musicbox = GameObject.FindGameObjectWithTag("MusicBox");
        musicboxcs = musicbox.GetComponent<MusicBox>();
    }

    //�N���b�N�����ΐF���ς��(����)
    public void Change()
    {
        if (this.gameObject.GetComponent<SpriteRenderer>().sprite != Sick)
        {
            MainSpriteRenderer.sprite = Sick;
            audioSource.volume = musicboxcs.SE.volume;
            audioSource.Play();
        }
    }
}
