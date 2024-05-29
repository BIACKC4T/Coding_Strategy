using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatSoundManager : MonoBehaviour
{
    private SoundManager soundManager;
    public InputField ChatInputField;

    //public void ChatSound()
    //{
    //    soundManager = FindObjectOfType<SoundManager>();
    //    soundManager.Init();
    //    // ȿ������ �ҷ����� ����մϴ�.
    //    AudioClip effectClip = Resources.Load<AudioClip>("Sound/Keyboard_Click_Sound");
    //    soundManager.Play(effectClip, Sound.Effect, 1.0f);
    //    Debug.Log("Chatting sound is comming out!");
    //}

    //public void SendMsgBtnClickSound()
    //{
    //    soundManager = FindObjectOfType<SoundManager>();
    //    soundManager.Init();
    //    // ȿ������ �ҷ����� ����մϴ�.
    //    AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameLobby_UI_ClickSound");
    //    soundManager.Play(effectClip, Sound.Effect, 1.0f);
    //    Debug.Log("Send button sound is comming out!");
    //}

    //public void ChatSound()
    //{
    //    // Manager�� ���� SoundManager�� ����
    //    SoundManager soundManager = Manager.Sound;

    //    // SoundManager�� �ʱ�ȭ���� �ʾ��� ��츦 ����� ���� ó��
    //    if (soundManager == null)
    //    {
    //        Debug.LogError("SoundManager�� �ʱ�ȭ���� �ʾҽ��ϴ�.");
    //        return;
    //    }

    //    // ȿ������ �ҷ����� ����մϴ�.
    //    AudioClip effectClip = Resources.Load<AudioClip>("Sound/Keyboard_Click_Sound");

    //    if (effectClip != null)
    //    {
    //        soundManager.Play(effectClip, Sound.Effect, 1.0f);
    //        Debug.Log("Chatting sound is coming out!");
    //    }
    //    else
    //    {
    //        Debug.LogWarning("ȿ������ ã�� �� �����ϴ�: Sound/Keyboard_Click_Sound");
    //    }
    //}


    public void Start()
    {
        // �г��� �Է� �ʵ��� �̺�Ʈ�� ������ �߰�
        ChatInputField.onValueChanged.AddListener(OnChatChanged);
    }

    public void OnChatChanged(string Chat)
    {
        // ä���� �Էµ� ������ ȿ���� ���
        AudioClip typingSoundClip = Resources.Load<AudioClip>("Sound/Keyboard_Click_Sound");
        soundManager.Play(typingSoundClip, Sound.Effect, 3.0f, 0.6f);
    }


}
