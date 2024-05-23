using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using CodingStrategy.PlayerStates;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI[] playerNicknames; // �÷��̾� �г��� �ؽ�Ʈ �迭
    public TextMeshProUGUI[] playerReady; // �÷��̾� �г��� �ؽ�Ʈ �迭
    public TextMeshProUGUI[] Master;

    public PlayerStates playerStates;

    public GameObject startButton; // ���� ��ư
    public GameObject readyButton; // ���� ��ư

    private void Awake()
    {
        GameObject playerInfo = GameObject.Find("PlayerInfo"); // �� Lobby���� destroy on load�� ���� �� �� ���������� "PlayerInfo"��� �̸��� ������Ʈ ã��
        playerStates = playerInfo.GetComponent<PlayerStates>(); // PlayerStates ������Ʈ ã��

        UpdatePlayerNicknames();
    }

    public void UpdatePlayerNicknames()
    {
        for (int i = 0; i < playerStates.playersinRoom.Count; i++)
        {
            playerNicknames[i].text = playerStates.playersinRoom[i].NickName;
            if (playerStates.playersinRoom[i].IsMasterClient)
            {
                playerReady[i].gameObject.SetActive(false); // playerReady[i] ��Ȱ��ȭ
                Master[i].gameObject.SetActive(true); // Master[i] Ȱ��ȭ
            }
            
            if(playerStates.ready[i].text == "true")
            {
                playerReady[i].text = "�غ� �Ϸ�!";
                playerReady[i].color = Color.green;
            }
        }
    }

    void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            startButton.SetActive(true);
            readyButton.SetActive(false);
        }
        else
        {
            startButton.SetActive(false);
            readyButton.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        //StartCoroutine(StartButtonCountdown());
    }

    //�������� ���� �� �����ؾ߰���?
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        UpdatePlayerNicknames();
    }

    //�������� ���� �� �����ؾ߰���?
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        UpdatePlayerNicknames();
    }

    private IEnumerator StartButtonCountdown()
    {
        // ��� �÷��̾ �غ� �������� Ȯ��
        foreach (TextMeshProUGUI playerStatus in playerReady)
        {
            if (playerStatus.text != "�غ� �Ϸ�!" && playerStatus.text != "����") 
            {
                yield break; // ��� �÷��̾ �غ� ���°� �ƴϸ� �ڷ�ƾ ����
            }
        }

        //20�� ��ٷȴٰ�...
        yield return new WaitForSeconds(20f);

        // ������ �����ϰ� �г����� "����"���� ����
        if (PhotonNetwork.IsMasterClient)
        {
            playerStates.playersinRoom.Remove(PhotonNetwork.LocalPlayer);
            UpdatePlayerNicknames();
        }
    }

    public void OnReadyButtonClick()
    {
        for (int i = 0; i < playerNicknames.Length; i++)
        {
            if (playerNicknames[i].text == PhotonNetwork.LocalPlayer.NickName)
            {
                playerReady[i].text = "�غ� �Ϸ�!";
                playerReady[i].color = Color.green;
                playerStates.ready[i].text = "true";
                break;
            }
        }
        UpdatePlayerNicknames();
    }

    public void OnStartButtonClicked()
    {
        // ��� �÷��̾ �غ� �������� Ȯ���մϴ�.
        foreach (TextMeshProUGUI readyCheck in playerReady)
        {
            if (readyCheck.text != "�غ� �Ϸ�!" && readyCheck.text !="����")
            {
                Debug.Log("��� �÷��̾ �غ� ���°� �ƴմϴ�.");
                return;
            }
        }
        OnGameStart();
    }

    public void OnGameStart()
    {
        // ī��Ʈ�ٿ��� �ߴ��մϴ�.
        StopCoroutine(StartButtonCountdown());

        // ������ �����մϴ�.
        Debug.Log("������ �����մϴ�.");
        // ������ �����ϴ� ������ �̰� �Ʒ��� �����ϼ���.
    }

}
