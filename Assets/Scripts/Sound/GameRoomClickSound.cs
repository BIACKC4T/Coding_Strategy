using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoomClickSound : MonoBehaviour
{
    private SoundManager soundManager;

    // 게임룸씬에서 명령어 리스트 버튼 클릭 및 명령어 클릭 시 나오는 사운드
    public void CommmandClicked()
    {
        StartCoroutine(CommandClickedSound(0));
    }

    public IEnumerator CommandClickedSound(float delay)
    {
        yield return new WaitForSeconds(delay);

        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();

        // 효과음을 불러오고 재생합니다.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameRoom_CommnadClicked_Sound");
        soundManager.Play(effectClip, Sound.Effect, 1.0f);
        Debug.Log("Command sound is comming out!");
    }

    // 게임룸씬에서 준비 버튼을 누를 시 나오는 사운드
    public void ReadyBtnClicked()
    {
        StartCoroutine(ReadyBtnClickedSound(0));
    }

    public IEnumerator ReadyBtnClickedSound(float delay)
    {
        yield return new WaitForSeconds(delay);

        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();

        // 효과음을 불러오고 재생합니다.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameRoom_Ready");
        soundManager.Play(effectClip, Sound.Effect, 1.0f);
        Debug.Log("Ready button sound is comming out!");
    }

    // 게임룸씬에서 게임 시작 버튼을 누를 시 나오는 사운드
    public void GamestartBtnClicked()
    {
        StartCoroutine(GamestartBtnClickedSound(0));
    }

    public IEnumerator GamestartBtnClickedSound(float delay)
    {
        yield return new WaitForSeconds(delay);

        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();

        // 효과음을 불러오고 재생합니다.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameRoom_GameStartSound");
        soundManager.Play(effectClip, Sound.Effect, 1.0f);
        Debug.Log("GameStart button sound is comming out!");
    }

    // 게임룸씬에서 나가기 버튼 눌렀을 때 나오는 사운드
    public void QuitBtnClicked()
    {
        StartCoroutine(QuitBtnClickedSound(0));
    }

    public IEnumerator QuitBtnClickedSound(float delay)
    {
        yield return new WaitForSeconds(delay);

        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();

        // 효과음을 불러오고 재생합니다.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameRoom_QuitBtn_Sound");
        soundManager.Play(effectClip, Sound.Effect, 1.0f);
        Debug.Log("Game quit button sound is comming out!");
    }
}
