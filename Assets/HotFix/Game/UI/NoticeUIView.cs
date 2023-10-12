using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Main.Base;
using Main.UI;
using UnityEngine;
using UnityEngine.UI;
using Wanderer.GameFramework;

namespace HotFix.Game.UI
{
    public class NoticeUIView : UGUIView
    {
        public static string AssetPath = "Assets/Addressable/Prefabs/UI/NoticeUIView.prefab";
        public Button btnClose;
        public override void OnInit(IUIContext uiContext)
        {
            base.OnInit(uiContext);

            btnClose.onClick.AddListener(() =>
            {
                GameMode.UI.Close(GameMode.UI.UIContextMgr[AssetPath]);
            });
        }

        public override void OnFree(IUIContext uiContext)
        {
            base.OnFree(uiContext);
        }

        public override void OnEnter(IUIContext uiConext, Action<string> callBack = null, params object[] parameters)
        {
            base.OnEnter(uiConext, callBack, parameters);
            transform.Find("Panel").localScale = Vector3.zero;
            transform.Find("Panel").DOScale(new Vector3(1, 1, 1), .5f);
        }
    }
}
