using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("#BGM")]
    public AudioClip[] bgmClips;
    public float bgmVolume;
    AudioSource bgmPlayer;

    public enum Bgm { STORY, CUSTOM, GAME, BOSS };

    [Header("#SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayers;
    int channellIndex;

    public enum Sfx { CLICK, CLOSE, PURCHASE, ENFORCE, WEAR, ACQUIRE, HIT, TRUCK, ACCIDENT };

    [Header("#Skill")]
    public AudioClip[] skillClips;
    public float skillVolume;
    public int skillChannels;
    AudioSource[] skillPlayers;
    int skillChannellIndex;

    public enum Skill { HORIZONTAL, IMPACT, POWERSHOT, SWING, COMET, FINISH, SHOCK, STAR, JUDGEMENT, METEOR };

    void Awake()
    {
        instance = this;
        Init();
    }

    void Init()
    {
        // 배경음 플레이어 초기화
        GameObject bgmObject = new GameObject("bgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;

        // 효과음 플레이어 초기화
        GameObject sfxObject = new GameObject("sfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];
        for (int i = 0; i < sfxPlayers.Length; i++)
        {
            sfxPlayers[i] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[i].playOnAwake = false;
            sfxPlayers[i].volume = sfxVolume;
        }

        // 스킬 효과음 플레이어 초기화
        GameObject skillObject = new GameObject("skillPlayer");
        skillObject.transform.parent = transform;
        skillPlayers = new AudioSource[channels];
        for (int i = 0; i < skillPlayers.Length; i++)
        {
            skillPlayers[i] = sfxObject.AddComponent<AudioSource>();
            skillPlayers[i].playOnAwake = false;
            skillPlayers[i].volume = skillVolume;
        }
    }

    public void PlayBgm(Bgm bgm)
    {
        if (bgmPlayer.isPlaying)
            StartCoroutine("ChangeBgm");

        bgmPlayer.clip = bgmClips[(int)bgm];
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.Play();
    }

    IEnumerator ChangeBgm()
    {
        float time = 0f;
        float fadeTime = 1f;
        while (bgmPlayer.volume <= 0f)
        {
            time += Time.deltaTime;
            float volume = Mathf.Lerp(0f, bgmVolume, time / fadeTime);
            bgmPlayer.volume = volume;
            yield return null;
        }
    }

    public void PlayerSfx(Sfx sfx)
    {
        for (int i = 0; i < sfxPlayers.Length; i++)
        {
            int loopIndex = (i + channellIndex) % sfxPlayers.Length;

            if (sfxPlayers[loopIndex].isPlaying)
                continue;

            channellIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx];
            sfxPlayers[loopIndex].Play();
            break;
        }
    }

    public void PlayerSKill(Skill skill, float pitch = 1f)
    {
        StartCoroutine(PlaySkillSound(skill, pitch));
    }

    public void RepeatPlayerSkill(Skill skill, int count, float delayTime, float pitch = 1f)
    {
        StartCoroutine(RepeatSound(skill, count, delayTime, pitch));
    }

    IEnumerator RepeatSound(Skill skill, int count, float delayTime, float pitch = 1f)
    {
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(delayTime);

            StartCoroutine(PlaySkillSound(skill, pitch));
        }
    }

    IEnumerator PlaySkillSound(Skill skill, float pitch = 1f)
    {
        yield return new WaitForSeconds(0.3f);

        for (int i = 0; i < skillPlayers.Length; i++)
        {
            int loopIndex = (i + skillChannellIndex) % skillPlayers.Length;

            if (skillPlayers[loopIndex].isPlaying)
                continue;

            skillChannellIndex = loopIndex;
            skillPlayers[loopIndex].clip = skillClips[(int)skill];
            skillPlayers[loopIndex].pitch = pitch;
            skillPlayers[loopIndex].Play();
            break;
        }
    }

    public void StopAllSfxSound()
    {
        for (int i = 0; i < sfxPlayers.Length; i++)
        {
            int loopIndex = (i + channellIndex) % sfxPlayers.Length;

            if (sfxPlayers[loopIndex].isPlaying)
            {
                sfxPlayers[loopIndex].Stop();
                continue;
            }
        }
    }

    public void FindBgm()
    {
        Scene curScene = SceneManager.GetActiveScene();
        StartCoroutine(StartBgm(curScene.name));
    }

    IEnumerator StartBgm(string sceneName)
    {
        yield return new WaitForSeconds(1f);
        //Debug.Log(sceneName);
        switch (sceneName)
        {
            case "0CustomLevel":
                PlayBgm(Bgm.CUSTOM);
                break;
            case "1SampleScene":
                PlayBgm(Bgm.GAME);
                break;
            case "2OrcBossLevel":
                PlayBgm(Bgm.BOSS);
                break;
        }
    }

    public void SetBgmVolume(float volume)
    {
        bgmPlayer.volume = volume;
    }

    public void SetSfxVolume(float volume)
    {
        for (int i = 0; i < sfxPlayers.Length; i++)
        {
            sfxPlayers[i].volume = volume;
        }
    }

    public void SetSkillVolume(float volume)
    {
        for (int i = 0; i < skillPlayers.Length; i++)
        {
            skillPlayers[i].volume = volume;
        }
    }

}
