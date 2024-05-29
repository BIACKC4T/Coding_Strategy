using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLobbyEnterBtnSound : MonoBehaviour
{
    private void Start()
    {
        // SoundManager �ʱ�ȭ�� Manager.Instance�� ó���մϴ�.
        // ���⼭�� ������ �ʱ�ȭ�� �ʿ䰡 �����ϴ�.
        if (Manager.Sound == null)
        {
            Debug.LogError("SoundManager�� �ʱ�ȭ���� �ʾҽ��ϴ�.");
        }
    }

    public void GameLobbyEnterBtnClicked()
    {
        // ȿ������ �ҷ����� ����մϴ�.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameRoom_GameStartSound");
        if (effectClip != null)
        {
            Manager.Sound.Play(effectClip, Sound.Effect, 1.0f, 0.5f);
            Debug.Log("�� ���� ��ư ȿ������ ����˴ϴ�!");
        }
        else
        {
            Debug.LogWarning("ȿ������ ã�� �� �����ϴ�: Sound/GameRoom_GameStartSound");
        }
    }
}
