using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wanderer.GameFramework;

namespace Main.UI
{
	public class UIComponent : MonoBehaviour
	{
		private void Awake()
		{
			GameFrameworkMode.GetModule<UIManager>().SetUIViewParent(transform);
		}
	}
}