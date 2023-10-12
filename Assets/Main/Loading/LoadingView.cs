using UnityEngine;
using UnityEngine.UI;
using Wanderer.GameFramework;

namespace Main.Loading
{
    public class LoadingView : MonoBehaviour
    {
        public Slider sliderLoading;
        public Text txtTips;
        // Start is called before the first frame update
        void Start()
        {
            GameFrameworkMode.GetModule<EventManager>().AddListener<LoadingEventArgs>(OnLoading);

        }

        void OnLoading(object sender, IEventArgs e)
        {
            var args = (LoadingEventArgs)e;
            sliderLoading.value = args.Progress;
            txtTips.text = args.Tips;
        }
    }
}