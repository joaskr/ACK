using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private float sfxMinimumDistance;

    [SerializeField] private AudioSource[] sfx;
    [SerializeField] private AudioSource[] bgm;

    public bool playBgm;
    private int bgmIndex;

    private bool canPlaySFX;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
        Invoke("AllowSfx", 1f);
    }

    private void Update()
    {
         if(!playBgm)
        {
            StopAllBgm();
        } else
        {
            if (!bgm[bgmIndex].isPlaying)
            {
                PlayBgm(bgmIndex);
            }
        }
    }
    public void PlaySfx(int _sfxIndex, Transform _source)
    {
        if (canPlaySFX == false)
        {
            return;
        }

        if(_source != null && Vector2.Distance(PlayerManager.instance.player.transform.position, _source.position) > sfxMinimumDistance)
        {
            return;
        }

        if (_sfxIndex < sfx.Length)
        {
            sfx[_sfxIndex].pitch = Random.Range(.85f, 1.1f);
            sfx[_sfxIndex].Play();
        }
    }

    public void StopSfx(int _index) => sfx[_index].Stop();

    public void PlayBgm(int _bgmIndex)
    {
        bgmIndex = _bgmIndex;
        StopAllBgm();
        bgm[bgmIndex].Play();
    }

    public void PlayRandomBgm()
    {
        bgmIndex = Random.Range(0, bgm.Length);
        PlayBgm(bgmIndex);
    }
    public void StopAllBgm()
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }
    }

    private void AllowSfx() => canPlaySFX = true;
}

