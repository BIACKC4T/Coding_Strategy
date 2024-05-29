using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSoundManager : MonoBehaviour
{
    private SoundManager soundManager;

    // PlayerInfo �Ǵ� PlayerColor�� Ŭ������ �� �Ҹ�(RobotStatus ���� �� �Ҹ�)
    // RobotStatus �ݱ� �Ҹ��� �������� ����.
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

    // BadSector �� �� �Ҹ�
    public IEnumerator BadSectorSound(float delay)
    {
        yield return new WaitForSeconds(delay);

        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();

        // ȿ������ �ҷ����� ����մϴ�.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameScene_BadSctor_Sound");
        soundManager.Play(effectClip, Sound.Effect, 1.0f);
        Debug.Log("Badsector sound is comming out!");
    }

    // ���� ���� �� �Ҹ�
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

    // ���ݴ��� �� �Ҹ� GameScene_GetAttacked_Sound
    public IEnumerator GotAttackedSound(float dealy)
    {
        yield return new WaitForSeconds(dealy);

        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();

        // ȿ������ �ҷ����� ����մϴ�.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameScene_GotAttacked_Sound");
        soundManager.Play(effectClip, Sound.Effect, 1.0f, 0.2f);
        Debug.Log("GetAttacked sound is comming out!");
    }

    // �ڵ�Ÿ�� ī��Ʈ �ٿ� �Ҹ�
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

    // �ڵ�Ÿ�� Bgm
    //public IEnumerator CodingTimeBgm(float delay)
    //{
    //    yield return new WaitForSeconds(delay);

    //    soundManager = FindObjectOfType<SoundManager>();
    //    soundManager.Init();

    //    // ȿ������ �ҷ����� ����մϴ�.
    //    AudioClip BgmClip = Resources.Load<AudioClip>("Sound/GameScene_CodingTimeCountdown_Sound");
    //    soundManager.Play(BgmClip, Sound.Bgm, 1.0f, 0.5f, 0.2f);
    //    Debug.Log("CodingTime Bgm is comming out!");
    //}


    // ĳ���� ���� �� ����
    // �� ���ڱ� �� ������ �����ϴ� �Ҹ���.
    public IEnumerator CharacterWalkSound(float delay)
    {
        yield return new WaitForSeconds(delay);

        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();

        // ȿ������ �ҷ����� ����մϴ�.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameScene_CharacterWalk_Sound");
        soundManager.Play(effectClip, Sound.Effect, 1.0f);
        Debug.Log("Character walk sound is comming out!");
    }

    // �ڵ�Ÿ�� ��ɾ� ��ġ ����
    // 


}
