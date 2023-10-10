using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Game.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        public Slider sliderBar;
        public Text loadingText;
        public Transform hotUpdateHolder;
        public string nextSceneAddress;
    
        private AsyncOperationHandle _handle;
        private bool _sceneDependencyDownload;
        private bool _sceneLoading;

        private bool _updateFlag;

        private AddressableHelper _addressableHelper;
        // Start is called before the first frame update
        void Start()
        {
            _updateFlag = false;
            _addressableHelper = new AddressableHelper();
            _addressableHelper.CheckUpdate(needUpdate =>
            {
                if (needUpdate)
                {
                    _addressableHelper.UpdateResource(OnResourceUpdateCallback, OnDownloadComplete, OnDownloadError, "Hall");
                }
                _updateFlag = !needUpdate;
            });
        }
        
        private void OnResourceUpdateCallback(float progress, double size, double speed, float remainingTime)
        {
            Debug.Log($"progress: {progress}");
            if (size <= 0.01)
            {
                sliderBar.value = progress;
                loadingText.text = "数据加载中...";
            }
            else
            {
                var curSizeMb = Mathf.Round(progress * (float)size / 1024 * 100) / 100f;
                var totalSizeMb = Mathf.Round((float)size / 1024 * 100) / 100f;
                loadingText.text = $"资源下载中({curSizeMb}/{totalSizeMb}mb)...";
                sliderBar.value = curSizeMb / totalSizeMb;
            }
        }
        
        private void OnDownloadComplete()
        {
            Debug.Log("OnDownloadComplete");
            _updateFlag = true;
        }
        
        private void OnDownloadError(string localPath,string error)
        {
            Debug.LogError($"资源下载失败,网络错误!! {localPath} {error}");
        }

        private void DoLoadScene()
        {
            // 启动Hybirdclr
            GameObject go = new GameObject("LoadDll", typeof(LoadDll));
            go.transform.SetParent(hotUpdateHolder);
            
            // loadingText.text = "场景加载中...";
            // sliderBar.value = 0f;
            // var loadOperation = Addressables.LoadSceneAsync(nextSceneAddress);
            // StartCoroutine(UpdateProgressBar(loadOperation));
        }

        private System.Collections.IEnumerator UpdateProgressBar(AsyncOperationHandle operation)
        {
            while (!operation.IsDone)
            {
                var total = operation.GetDownloadStatus().TotalBytes;
                var cur = operation.GetDownloadStatus().DownloadedBytes;
                Debug.Log($"UpdateProgressBar {operation.PercentComplete}, downloadSize({cur}/{total})"); 
                
                float progress = Mathf.Clamp01(operation.PercentComplete); // 获取加载进度（范围：0-1）
                sliderBar.value = progress; // 更新进度条的值
                yield return null;
            }
        }

        private void Update()
        {
            if (_updateFlag)
            {
                _updateFlag = false;
                DoLoadScene();
            }
        }

        // private void Update()
        // {
        //     if (_sceneDependencyDownload)
        //     {
        //         if (!_sceneLoading)
        //         {
        //             _sceneLoading = true;
        //             DoLoadScene();  
        //         }
        //         return;
        //     }
        //     if (_handle.IsValid())
        //     {
        //         var status = _handle.GetDownloadStatus();
        //         var totalSize = status.TotalBytes;
        //         var curSize = status.DownloadedBytes;
        //         if (totalSize == 0)
        //         {
        //             float progress = _handle.PercentComplete;
        //             sliderBar.value = progress;
        //             loadingText.text = "数据加载中...";
        //         }
        //         else
        //         {
        //             var curSizeMb = Mathf.Round(curSize / 10000.0f) / 100f;
        //             var totalSizeMb = Mathf.Round(status.TotalBytes / 10000.0f) / 100f;
        //             loadingText.text = $"资源下载中({curSizeMb}/{totalSizeMb}mb)...";
        //             sliderBar.value = curSizeMb / totalSizeMb;
        //         }
        //         
        //         Debug.Log($"LoadSceneAsync progress: {sliderBar.value * 100}%, ({_handle.GetDownloadStatus().DownloadedBytes}/{_handle.GetDownloadStatus().TotalBytes})");
        //         if (_handle.IsDone)
        //         {
        //             // The operation has completed, you can now use the result
        //             if (_handle.Status == AsyncOperationStatus.Succeeded)
        //             {
        //                 _sceneDependencyDownload = true;
        //             }
        //             else
        //             {
        //                 Debug.LogError($"Failed to load resource locations: {_handle.OperationException}");
        //             }
        //
        //             // Remember to release the handle
        //             // 如果不加下面release的动作，在android上取不到场景，不知道为什么，加了的话在unity editor默认的UI材质有问题
        //             // 暂时先满足安卓端的需求
        //             if(!Application.isEditor)
        //                 Addressables.Release(_handle);
        //         }
        //     }
        // }
    }
}