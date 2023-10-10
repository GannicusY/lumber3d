using System;
using Assets.HeroEditor.Common.Scripts.Common;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.UI
{
    public class CommonPopupPanel : MonoBehaviour
    {
        public GameObject titleObj;
        public Text txtTitle;
        public Text txtMsg;
        public Button btnOutSideClose;
        public Button btnClose;
        public Button btnCancel;
        public Button btnConfirm;
        public Animation anim;

        public class PopupParam
        {
            public bool WithTitle;
            public bool WithCloseBtn;
            public bool WithCancelBtn;
            public bool WithConfirmBtn;
            public bool CloseOnOutsideClick;
            public string Title;
            public string Msg;
        }


        private PopupParam _param;
        public Action<CommonPopupPanel> OnCancel;
        public Action<CommonPopupPanel> OnConfirm;
        public Action<CommonPopupPanel> OnClose;
        public Action<CommonPopupPanel> DestroyEvent;
        private void Start()
        {
            btnOutSideClose.onClick.AddListener(OnFullScreenCloseClick);
            btnClose.onClick.AddListener(OnCloseClick);
            btnCancel.onClick.AddListener(OnCancelClick);
            btnConfirm.onClick.AddListener(OnConfirmClick);
        }

        private void OnCloseClick()
        {
            Close();
        }

        private void OnFullScreenCloseClick()
        {
            if(!_param.CloseOnOutsideClick) return;
            
            Close();
        }

        private void Close()
        {
            OnClose?.Invoke(this);
            Destroy(gameObject);
        }

        private void OnCancelClick()
        {
            OnCancel?.Invoke(this);
        }

        private void OnConfirmClick()
        {
            OnConfirm?.Invoke(this);
        }

        public void ShowPopup(PopupParam param)
        {
            _param = param;
            titleObj.SetActive(param.WithTitle);
            if (param.WithTitle)
                txtTitle.text = param.Title;
            btnClose.SetActive(param.WithCloseBtn);
            btnCancel.SetActive(param.WithCancelBtn);
            btnConfirm.SetActive(param.WithConfirmBtn);
            txtMsg.text = param.Msg;
        }

        private void OnEnable()
        {
            if (null != anim)
                anim.Play("popup");
        }
        
        private void OnDisable()
        {
            if (null != anim)
                anim.Play("fadeout");
            
            DestroyEvent?.Invoke(this);
        }
    }
}