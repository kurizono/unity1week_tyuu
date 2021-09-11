using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
	private static MusicBox instance;

    public AudioSource BGM;
    public AudioClip MissingScrewing01, MissingScrewing02, Shot;
    AudioClip[] musics;

    public float nowmusicvolume;
    int musicnum;

    void Awake()
    {
        BGM = GetComponent<AudioSource>();

        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        musics = new AudioClip[3] { MissingScrewing01, MissingScrewing02, Shot };
        musicnum = 2;
    }

    private void Start()
    {
        nowmusicvolume = SettingController.BGMsoundvolume.value;
    }


    public void BGMVolumeChange()
    {
        BGM.volume = (float)SettingController.BGMsoundvolume.value / 100;
    }
    public string BGMMusicChange()
    {
        musicnum = (musicnum + 1) % musics.Length;
        BGM.clip = musics[musicnum];
        BGM.Play();

        return musics[musicnum].name;
    }
    public string BGMMusicChake()
    {
        return musics[musicnum].name;
    }


}
