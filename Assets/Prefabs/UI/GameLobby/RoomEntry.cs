using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class RoomEntry : MonoBehaviour
{
    public TextMeshProUGUI roomNameText; // �� �̸��� ǥ���� TextMeshProUGUI ������Ʈ
    public TextMeshProUGUI roomDescriptionText; // �� ������ ǥ���� TextMeshProUGUI ������Ʈ
    public RawImage standardImage; // "Standard" �̹���
    private Photon.Realtime.RoomInfo roomInfo;

    // �� ���� ����
    public void SetRoomInfo(Photon.Realtime.RoomInfo room)
    {
        roomInfo = room;
        roomNameText.text = room.Name;
        standardImage.gameObject.SetActive(false); // �ʱ⿡�� "Standard" �̹����� ��Ȱ��ȭ

        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => {
            // ���� Ŭ���ϸ� "Standard" �̹��� Ȱ��ȭ
            standardImage.gameObject.SetActive(true);
            // ������ ���� ������ ǥ��
            roomDescriptionText.text = GetRoomDescription(room);
        });
    }

    // �� ������ �������� �Լ�
    private string GetRoomDescription(Photon.Realtime.RoomInfo room)
    {
        // ���⿡�� �� ������ �����ϰ� ��ȯ�մϴ�.
        return $"Room Name: {room.Name}\nMax Players: {room.MaxPlayers}\nCurrent Players: {room.PlayerCount}";
    }

    public void CheckDestroyRoom()
    {
        if (roomInfo.PlayerCount == 0)
        {
            Destroy(gameObject);
        }
    }
}
