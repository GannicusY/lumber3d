using HybridCLR;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace HotFix
{
    public class HotUpdateMain : MonoBehaviour
    {

        public string text;

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("这个热更新脚本挂载在prefab上，打包成ab。通过从ab中实例化prefab成功还原");
            Debug.LogFormat("hello, {0}.", text);

            gameObject.AddComponent<CreateByCode>();

            Debug.Log("=======看到此条日志代表你成功运行了示例项目的热更新代码=======111");

            //开始游戏
            Debug.Log("PlayStateContext Begin");

            var loadOperation = Addressables.LoadSceneAsync("Lumber");
            var loader = FindObjectOfType<SceneLoader>();
            if (loader)
            {
                StartCoroutine(UpdateProgressBar(loader, loadOperation));
            }
        }
        
        private System.Collections.IEnumerator UpdateProgressBar(SceneLoader loader, AsyncOperationHandle operation)
        {
            while (!operation.IsDone)
            {
                loader.loadingText.text = "场景加载中...";
                float progress = Mathf.Clamp01(operation.PercentComplete); // 获取加载进度（范围：0-1）
                loader.sliderBar.value = progress; // 更新进度条的值
                yield return null;
            }
        }
    }
}
    

