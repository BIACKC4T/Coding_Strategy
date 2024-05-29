using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSoundManager : MonoBehaviour
{
    private SoundManager soundManager;

    // PlayerInfo �Ǵ� PlayerColor�� Ŭ������ �� �Ҹ�(RobotStatus ���� �� �Ҹ�)
    // RobotStatus �ݱ� �Ҹ��� �������� ����.
    public void RobotStatus()
    {
        StartCoroutine(RobotStatusSound(0));
    }
    public IEnumerator RobotStatusSound(float delay)
    {
        yield return new WaitForSeconds(delay);

        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();

        // ȿ������ �ҷ����� ����մϴ�.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameScene_RobotStatus_Sound");
        soundManager.Play(effectClip, Sound.Effect, 1.0f);
        Debug.Log("PlayerInfo or PlayerColor is clicked!");
    }

    // ���� ���� �� �Ҹ�. ���� �ؾ���.
    public IEnumerator GetCoinSound(float delay)
    {
        yield return new WaitForSeconds(delay);

        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();

        // ȿ������ �ҷ����� ����մϴ�.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameScene_GetCoin_Sound");
        soundManager.Play(effectClip, Sound.Effect, 1.0f);
        Debug.Log("Coin get sound is comming out!");
    }

    // ���� ������ �� �Ҹ�. �����ϸ� ���� �� ����.
    public void CoinSpawn()
    {
        StartCoroutine(CoinSpawnSound(0));
    }
    public IEnumerator CoinSpawnSound(float delay)
    {
        yield return new WaitForSeconds(delay);

        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();

        // ȿ������ �ҷ����� ����մϴ�.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameScene_CoinSpawn_Sound");
        soundManager.Play(effectClip, Sound.Effect, 1.0f);
        Debug.Log("Coin spawn sound is comming out!");
    }

    // �ڵ�Ÿ�� ī��Ʈ �ٿ� �Ҹ�. ���� �ؾ���
    public void CodingTimeCountdown()
    {
        StartCoroutine(CodingTimeCountdownSound(0));
    }
    public IEnumerator CodingTimeCountdownSound(float dealy)
    {
        yield return new WaitForSeconds(dealy);

        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();

        // ȿ������ �ҷ����� ����մϴ�.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameScene_CodingTimeCountdown_Sound");
        soundManager.Play(effectClip, Sound.Effect, 1.0f, 0.5f);
        Debug.Log("CodingTime countdown sound is comming out!");
    }

    /*
    // �� �ٲ� �� ����. ���°� ���� �� ����.
    public IEnumerator GameTurnSound(float delay)
    {
        yield return new WaitForSeconds(delay);

        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();

        // ȿ������ �ҷ����� ����մϴ�.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameScene_GameTurnChanged_Sound");
        soundManager.Play(effectClip, Sound.Effect, 1.0f);
        Debug.Log("Gameturn sound is comming out!");

    }*/



    // �ڵ�Ÿ�� ��ɾ� ��ġ ����??
    // 


}
