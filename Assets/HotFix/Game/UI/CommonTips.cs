using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.UI
{
    public class CommonTips : MonoBehaviour
    {
        public Text txtContent;
        public Animation anim;

        public void ShowTips(string msg)
        {
            txtContent.text = msg;
            if(null != anim)
                anim.Play("TintOut");
        }
    }
}