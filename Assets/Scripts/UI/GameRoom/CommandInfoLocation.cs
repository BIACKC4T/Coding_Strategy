using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace CodingStrategy.UI.GameRoom
{
    public class CommandInfoLocation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public Transform command;
        public GameObject commandInfo;

        private SoundManager soundManager;

        /*public void OnButtonClick()
        {
            Vector3 commandPos = command.position;
            commandInfo.SetActive(true);
            commandInfo.transform.position = new Vector3(commandPos.x + 200f, commandPos.y - 100f, commandPos.z);
        }*/

        public void OnPointerDown(PointerEventData eventData)
        {
            soundManager = FindObjectOfType<SoundManager>();
            soundManager.Init();
            // Effect sound를 불러오고 재생합니다.
            AudioClip effectClip = Resources.Load<AudioClip>("Sound/InfoCreateSound");
            soundManager.Play(effectClip, Sound.Effect, 1.0f);
            Debug.Log("Command Click Sound is comming out!");

            Vector3 commandPos = command.position;
            commandInfo.SetActive(true);
            commandInfo.transform.position = new Vector3(commandPos.x + 200f, commandPos.y - 100f, commandPos.z);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            commandInfo.SetActive(false);
        }

        // Start is called before the first frame update
        void Start() {}

        // Update is called once per frame
        void Update() {}
    }
}
