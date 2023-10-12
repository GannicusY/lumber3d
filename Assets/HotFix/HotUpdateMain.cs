using HybridCLR;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts;
using Main.Base;
using Main.Loading;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace HotFix
{
    public class HotUpdateMain : MonoBehaviour
    {

        public string text;
        private LoadingEventArgs _loadingEventArgs;

        // Start is called before the first frame update
        void Start()
        {
            _loadingEventArgs = new LoadingEventArgs();
            Debug.Log("这个热更新脚本挂载在prefab上，打包成ab。通过从ab中实例化prefab成功还原");
            Debug.LogFormat("hello, {0}.", text);

            gameObject.AddComponent<CreateByCode>();

            Debug.Log("=======看到此条日志代表你成功运行了示例项目的热更新代码=======111");

            //开始游戏
            Debug.Log("PlayStateContext Begin");

            var loadOperation = Addressables.LoadSceneAsync("Lumber");
            StartCoroutine(UpdateProgressBar(loadOperation));
        }
        
        private System.Collections.IEnumerator UpdateProgressBar(AsyncOperationHandle operation)
        {
            while (!operation.IsDone)
            {
                _loadingEventArgs.Tips = "场景加载中...";
                _loadingEventArgs.Progress = Mathf.Clamp01(operation.PercentComplete);
                GameMode.Event.Trigger(this, _loadingEventArgs);
                yield return null;
            }
        }
    }
}
    

