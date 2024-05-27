using CodingStrategy.UI.Shop;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using CodingStrategy.Entities;

namespace CodingStrategy.UI.InGame
{
	public class RobotStatusUI : MonoBehaviour
	{
		public ShopUi shopUi;
		public ScrollRect scrollRect;
		public RenderTexture[] renderTexture;
		public RawImage image;
		public Transform CommandList;
		public TMP_Text Name;
		public TMP_Text State;
		public TMP_Text Description;

		public void DestroyChildren(Transform transform)
		{
			foreach (Transform child in transform)
			{
				Destroy(child.gameObject);
			}
		}

		public void SetName(string name)
		{
			Name.text = name;
		}

		public void SetState(string state)
		{
			State.text = "로봇 상태: " + state;
		}

		public void SetDescription(int hp, int attack, int defence, int energy)
		{
			Description.text = "체력: " + hp + ", " + "공격력: " + attack + ", " + "방어력: " + defence + ", " + "에너지: " + energy + ", ";
		}

		public void SetCommandList(ICommand[] commandList)
		{
			scrollRect.horizontalNormalizedPosition = 0.0f;
			foreach (ICommand command in commandList)
			{
				DestroyChildren(CommandList);
				GameObject _object = Instantiate(shopUi.iconList[int.Parse(command.Id)], CommandList);
				Destroy(_object.GetComponent<Drag>());
				Destroy(_object.GetComponent<Drop>());
			}
		}

		public void SetCameraTexture(int index)
		{
			image.texture = renderTexture[index];
		}

		// Start is called before the first frame update
		void Start() {}

		// Update is called once per frame
		void Update() {}
	}
}
