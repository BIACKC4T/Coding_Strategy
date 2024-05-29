using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

namespace CodingStrategy.UI.InGame
{
    public class GameResult : MonoBehaviour
    {
        public GameObject Gameresult;
        public GameObject EndCard;
        public TextMeshProUGUI Rank;
        public TextMeshProUGUI EndingMessage;
    
        public Button QuitRoomBtn;
    
        

        public void PlayerLeave()
        {
            SceneManager.LoadScene("GameLobby");
        }

        //ȭ�� ������ �Ʒ��� ���������� ������ ��� ����
        //�ϴ� Rank�� �ؽ�Ʈ ������ �Ŀ�
        //�ڷ�ƾ �����Ű�ø� �˴ϴ�.
        public IEnumerator ResultUIAnimation()
        {
            Gameresult.SetActive(true);

            QuitRoomBtn = GameObject.Find("Quit Room Button").GetComponent<Button>();
            QuitRoomBtn.onClick.AddListener(PlayerLeave);

            yield return new WaitForSeconds(0.2f);


            if (Rank.text == "1st")
            {
                EndingMessage.text = "���ϵ帳�ϴ�! 1���Դϴ�!";
            }

            else if (Rank.text == "2nd")
            {
                EndingMessage.text = "2�� ���ϵ帳�ϴ�!";
            }
            else
            {
                EndingMessage.text = "�������� ���� �� �����̴ϴ�.";
            }

            Sequence sequence = DOTween.Sequence();

            Vector3 endPosition = EndCard.transform.position;

            EndCard.transform.position = new Vector3(EndCard.transform.position.x, EndCard.transform.position.y + 1000, EndCard.transform.position.z);
            
            sequence.Insert(0, EndCard.transform.DOMove(endPosition, 3).SetEase(Ease.OutCubic));


            yield return sequence.WaitForCompletion();
        }
    }
}
