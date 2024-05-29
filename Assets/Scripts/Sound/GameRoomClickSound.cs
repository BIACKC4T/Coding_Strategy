using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoomClickSound : MonoBehaviour
{
    private SoundManager soundManager;

    // ���ӷ������ ��ɾ� ����Ʈ ��ư Ŭ�� �� ��ɾ� Ŭ�� �� ������ ����
    public void CommmandClicked()
    {
        StartCoroutine(CommandClickedSound(0));
    }
    public IEnumerator CommandClickedSound(float delay)
    {
        yield return new WaitForSeconds(delay);

        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();

        // ȿ������ �ҷ����� ����մϴ�.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameRoom_CommnadClicked_Sound");
        soundManager.Play(effectClip, Sound.Effect, 1.0f);
        Debug.Log("Command sound is comming out!");
    }

    // ���ӷ������ �غ� ��ư�� ���� �� ������ ����
    public void ReadyBtnClicked()
    {
        StartCoroutine(ReadyBtnClickedSound(0));
    }

    public IEnumerator ReadyBtnClickedSound(float delay)
    {
        yield return new WaitForSeconds(delay);

        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();

        // ȿ������ �ҷ����� ����մϴ�.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameRoom_Ready");
        soundManager.Play(effectClip, Sound.Effect, 1.0f);
        Debug.Log("Ready button sound is comming out!");
    }

    // ���ӷ������ ���� ���� ��ư�� ���� �� ������ ����
    public void GamestartBtnClicked()
    {
        StartCoroutine(GamestartBtnClickedSound(0));
    }

    public IEnumerator GamestartBtnClickedSound(float delay)
    {
        yield return new WaitForSeconds(delay);

        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();

        // ȿ������ �ҷ����� ����մϴ�.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameRoom_GameStartSound");
        soundManager.Play(effectClip, Sound.Effect, 1.0f, 0.5f);
        Debug.Log("GameStart button sound is comming out!");
    }

    // ���ӷ������ ������ ��ư ������ �� ������ ����
    public void QuitBtnClicked()
    {
        StartCoroutine(QuitBtnClickedSound(0));
    }

    public IEnumerator QuitBtnClickedSound(float delay)
    {
        yield return new WaitForSeconds(delay);

        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();

        // ȿ������ �ҷ����� ����մϴ�.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameRoom_QuitBtn_Sound");
        soundManager.Play(effectClip, Sound.Effect, 1.0f);
        Debug.Log("Game quit button sound is comming out!");
    }



}
