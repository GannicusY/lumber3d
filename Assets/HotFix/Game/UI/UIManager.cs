using System.Collections.Generic;
using System.Linq;
using _Game.Scripts.Base;
using NUnit.Framework;
using UnityEngine;

namespace _Game.Scripts.UI
{
    public class UIManager : BaseMonoSingleton<UIManager>
    {
        public Transform popupContainer;
        public Transform tipsContainer;

        public GameObject popupPrefab;
        public GameObject tipsPrefab;
            
        private List<CommonPopupPanel> _popupPanels = new();

        public void PushPopupPanel(string title, string msg)
        {
            var popupPanel = Instantiate(popupPrefab, popupContainer).GetComponent<CommonPopupPanel>();
            var panelComp = new CommonPopupPanel.PopupParam
            {
                Title = title,
                Msg = msg,
                WithTitle = true,
                WithCloseBtn = true,
                CloseOnOutsideClick = true
            };
            popupPanel.DestroyEvent = CleanPopupPanelOnTop;
            popupPanel.ShowPopup(panelComp);
            _popupPanels.Add(popupPanel);
        }

        private void CleanPopupPanelOnTop(CommonPopupPanel panel)
        {
            if(_popupPanels.Count <= 0) return;
            _popupPanels.Remove(panel);
        }

        public void ForceCleanTopPanel()
        {
            if(_popupPanels.Count <= 0) return;

            var topIndex = _popupPanels.Count - 1;
            Destroy(_popupPanels[topIndex]);
        }

        public void TintTips(string msg, Vector2 posOffset = new())
        {
            var tipsObj = Instantiate(tipsPrefab, tipsContainer).GetComponent<CommonTips>();
            if (posOffset.magnitude > 0.01f)
            {
                tipsObj.GetComponent<Transform>().position = new Vector3(posOffset.x, posOffset.y, 0);
            }
            var tipsComp = tipsObj.GetComponent<CommonTips>();
            tipsComp.ShowTips(msg);
        }
    }
}