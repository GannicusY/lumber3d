using _Game.Scripts.Data;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.UI
{
    public class UserProfile : MonoBehaviour
    {
        public Text txtName;
        public Image imgFrame;
        public Image imgAvatar;

        private UserInfo _userInfo;
        public void ResetData(UserInfo userInfo)
        {
            _userInfo = userInfo;
            ReloadUI();
        }

        private void ReloadUI()
        {
            txtName.text = _userInfo.userName;
            //__ TODO get sprite from remote __//
            //imgFrame.sprite = frame;
            //imgAvatar.sprite = avatar;
        }
    }
}