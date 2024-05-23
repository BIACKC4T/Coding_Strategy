using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class RoomManager : MonoBehaviourPunCallbacks
{
    // �濡 �ִ� �÷��̾� ���
    public List<Photon.Realtime.Player> playersInRoom = new List<Photon.Realtime.Player>();

    // ����
    private Photon.Realtime.Player roomMaster;

    // �� �÷��̾��� �г����� ǥ���� TextMeshProUGUI �迭
    public TextMeshProUGUI[] playerNicknames;

    // �� �÷��̾��� �غ� ���¸� ǥ���� TextMeshProUGUI �迭
    public TextMeshProUGUI[] playerReadyChecks;

    public GameObject[] roomManagerText;

    // ���� ��ư
    public Button startButton;
    public Button readyButton;

    public void Start()
    {
        // ���� ��ư�� �ʱ� ���·� �����մϴ� (��Ȱ��ȭ)
        startButton.gameObject.SetActive(false);
        Debug.Log(PhotonNetwork.LocalPlayer.NickName);
        Debug.Log(playersInRoom.Count);
        OnPlayerEnteredRoom(PhotonNetwork.LocalPlayer);
    }

    public void Update()
    {
        Debug.Log(playersInRoom.Count);
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.Log("Player entered room");

        // ���� ���� �÷��̾ ����Ʈ�� �߰��մϴ�
        playersInRoom.Add(newPlayer);

        Debug.Log(playersInRoom.Count);

        // �÷��̾� ����� �����մϴ�.
        UpdatePlayerList();

        // ������ �����մϴ�.
        if (roomMaster == null)
        {
            roomMaster = newPlayer;
            // ������ ��� �ڵ����� ���� ���¸� "�غ�"�� �����մϴ�.
            playerReadyChecks[playersInRoom.IndexOf(roomMaster)].text = "�غ�";
            // ���常 ���� ��ư�� Ȱ��ȭ�մϴ�.
            if (PhotonNetwork.LocalPlayer == roomMaster)
            {
                // ���忡�� �Ҵ�� readyState TextMeshPro�� ��Ȱ��ȭ�մϴ�.
                playerReadyChecks[playersInRoom.IndexOf(roomMaster)].gameObject.SetActive(false);

                // RoomManagerText TextMeshPro�� Ȱ��ȭ�մϴ�.
                // �� �κп����� RoomManagerText�� �ν��Ͻ��� �ʿ��մϴ�.
                roomManagerText[playersInRoom.IndexOf(roomMaster)].gameObject.SetActive(true);
            }
        }
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        // ���� ���� �÷��̾ ����Ʈ���� �����մϴ�
        playersInRoom.Remove(otherPlayer);

        // ������ ���� ���� ��� ���� �÷��̾ �������� �����մϴ�
        if (roomMaster == otherPlayer && playersInRoom.Count > 0)
        {
            // �׷� �������� ���� ���� ����� ������ �˴ϴ�.
            roomMaster = playersInRoom[0];

            playerReadyChecks[playersInRoom.IndexOf(roomMaster)].text = "�غ�";

            if (PhotonNetwork.LocalPlayer == roomMaster)
            {
                // ���忡�� �Ҵ�� readyState TextMeshPro�� ��Ȱ��ȭ�մϴ�.
                playerReadyChecks[playersInRoom.IndexOf(roomMaster)].gameObject.SetActive(false);

                // RoomManagerText TextMeshPro�� Ȱ��ȭ�մϴ�.
                // �� �κп����� RoomManagerText�� �ν��Ͻ��� �ʿ��մϴ�.
                roomManagerText[playersInRoom.IndexOf(roomMaster)].gameObject.SetActive(true);
            }
        }

        // �÷��̾� ����� �����մϴ�.
        UpdatePlayerList();
    }

    public void UpdatePlayerList()
    {
        // ��� �÷��̾��� ������ �ʱ�ȭ�մϴ�
        for (int i = 0; i < playerNicknames.Length; i++)
        {
            playerNicknames[i].text = "����";
            playerReadyChecks[i].text = "--";
        }

        // ���� �濡 �ִ� �÷��̾��� ������ ǥ���մϴ�
        for (int i = 0; i < playersInRoom.Count; i++)
        {
            playerNicknames[i].text = playersInRoom[i].NickName;
            playerReadyChecks[i].text = "���";
        }

        // ���忡�Դ� 'start button'��, �� ���� �����ڵ鿡�Դ� 'ready button'�� �����ݴϴ�.
        if (PhotonNetwork.LocalPlayer == roomMaster)
        {
            startButton.gameObject.SetActive(true);
            readyButton.gameObject.SetActive(false); // ready button �������� ��Ȱ��ȭ�մϴ�.
        }
        else
        {
            startButton.gameObject.SetActive(false);
            readyButton.gameObject.SetActive(true); // ready button �������� Ȱ��ȭ�մϴ�.
        }
    }

    public void OnReadyButtonClicked()
    {
        // �ڽ��� ������ �����ɴϴ�.
        Photon.Realtime.Player localPlayer = PhotonNetwork.LocalPlayer;

        // ���� ���� ���¸� �����ɴϴ�.
        bool currentReadyStatus = (bool)localPlayer.CustomProperties["isReady"];

        // ���� ���¸� ������ŵ�ϴ�.
        bool newReadyStatus = !currentReadyStatus;

        // ���ο� ���� ���¸� CustomProperties�� �����մϴ�.
        localPlayer.SetCustomProperties(new ExitGames.Client.Photon.Hashtable { { "isReady", newReadyStatus } });

        // UI�� ������Ʈ�մϴ�.
        string statusText = newReadyStatus ? "�غ�" : "���";
        playerReadyChecks[playersInRoom.IndexOf(localPlayer)].text = statusText;
    }

    public void OnStartButtonClicked()
    {
        // ��� �÷��̾ �غ� �������� Ȯ���մϴ�.
        foreach (TextMeshProUGUI readyCheck in playerReadyChecks)
        {
            if (readyCheck.text != "�غ�")
            {
                Debug.Log("��� �÷��̾ �غ� ���°� �ƴմϴ�.");
                return;
            }
        }
        OnGameStart();
    }

    private IEnumerator KickMasterAfterCountdown()
    {
        yield return new WaitForSeconds(20);

        // ������ ������ �������� �ʾҴٸ� ������ �����մϴ�.
        if (roomMaster == PhotonNetwork.LocalPlayer)
        {
            Debug.Log("������ �������� �ʾ� ������ ������Ͽ����ϴ�.");
            PhotonNetwork.LeaveRoom();
        }
    }

    public void KickMasterAllOnReadyButtonClicked()
    {
        // ��� �÷��̾ �غ� �������� Ȯ���մϴ�.
        foreach (TextMeshProUGUI readyCheck in playerReadyChecks)
        {
            if (readyCheck.text != "�غ�")
            {
                Debug.Log("��� �÷��̾ �غ� ���°� �ƴմϴ�.");
                return;
            }
        }

        // ��� �÷��̾ �غ� ���¶�� 20���� ī��Ʈ�ٿ��� �����մϴ�.
        StartCoroutine(KickMasterAfterCountdown());
    }

    public void OnGameStart()
    {
        // ī��Ʈ�ٿ��� �ߴ��մϴ�.
        StopCoroutine(KickMasterAfterCountdown());

        // ������ �����մϴ�.
        Debug.Log("������ �����մϴ�.");
        // ������ �����ϴ� ������ �̰��� �����ϼ���.
    }
}
