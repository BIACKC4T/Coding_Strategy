using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class LobbyManager : MonoBehaviour
{
    public Button joinRoomButton;
    public TextMeshProUGUI nicknameText;
    public RawImage randomImage;
    public GameObject roomEnterScroll; // �� ����� �����ִ� ��ũ�� ��
    public GameObject roomEntryPrefab; // �� �׸��� ǥ���ϴ� ������
    public Photon.Realtime.RoomInfo[] rooms;

    void Start()
    {
        // �г��� ����
        nicknameText.text = PhotonNetwork.NickName;

        // ��ư �̺�Ʈ ����
        joinRoomButton.onClick.AddListener(OnJoinRoomButtonClick);
        randomRoomButton.onClick.AddListener(OnRandomRoomButtonClick);

        randomImage.gameObject.SetActive(false); // �ʱ� ���´� ��Ȱ��ȭ
    }

    public void OnJoinRoomButtonClick()
    {
        // ���� Ȱ��ȭ�� �濡 ����
        foreach (RoomEntry entry in roomEnterScroll.GetComponentsInChildren<RoomEntry>())
        {
            // ���� "Standard" �̹����� Ȱ��ȭ�� ���� �ִٸ� �ش� �濡 �����մϴ�.
            if (entry.standardImage.isActiveAndEnabled)
            {
                PhotonNetwork.JoinRoom(entry.roomInfo.Name);
                break;
            }
        }
    }

    // �� ����� ������Ʈ�� �� ȣ��Ǵ� �ݹ� 
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        rooms = roomList.ToArray();

        // �� ��� UI�� ������Ʈ�մϴ�.
        foreach (Transform child in roomEnterScroll.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var room in rooms)
        {
            GameObject roomEntryObject = Instantiate(roomEntryPrefab, roomEnterScroll.transform);
            RoomEntry roomEntry = roomEntryObject.GetComponent<RoomEntry>();
            roomEntry.SetRoomInfo(room);
        }
    }

    // ���� �� ������ �������� �� ȣ��Ǵ� �ݹ�
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // ���ο� ���� �����մϴ�.
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4; // ���� �ִ� �����ڸ� 4������ ����
        PhotonNetwork.CreateRoom(null, roomOptions, TypedLobby.Default);
    }

    // �濡 �������� �� ȣ��Ǵ� �ݹ�
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        // GameRoomScene���� ��ȯ
        SceneManager.LoadScene("GameRoomScene");
    }

    // �ٸ� �÷��̾ ���� ������ �� ȣ��Ǵ� �ݹ�
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        // �ٸ� �÷��̾ ���� ������ �� �� ���� ��� �ִ��� Ȯ���ϰ�, ��� �ִٸ� �� ���� �ı��մϴ�.
        foreach (RoomEntry entry in roomEnterScroll.GetComponentsInChildren<RoomEntry>())
        {
            entry.CheckDestroyRoom();
        }
    }
}