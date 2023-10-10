using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace _Game.Scripts
{
    public class AddressableHelper
    {
        private bool _isCheckUpdate;
        private AsyncOperationHandle<List<string>> _checkHandle;
        
        public async void CheckUpdate(Action<bool> needUpdate)
        {
            string catalogPath = Application.persistentDataPath + "/com.unity.addressables";
            if (Directory.Exists(catalogPath))
            {
                try
                {
                    Directory.Delete(catalogPath, true);
                    Debug.Log($"delete catalog cache {catalogPath} done!");
                }
                catch (Exception e)
                {
                    Debug.LogError(e.ToString());
                }
            }

            //检查更新信息
            Debug.Log("AddressableVersion CheckUpdate");
            var initHandle = Addressables.InitializeAsync();
            await initHandle.Task;
            if (_isCheckUpdate)
            {
                Addressables.Release(_checkHandle);
                _isCheckUpdate = false;
            }
            Debug.Log("CheckForCatalogUpdates");
            _checkHandle = Addressables.CheckForCatalogUpdates(false);
            _isCheckUpdate = true;
            await _checkHandle.Task;
            Debug.Log($"Check Result Count:{_checkHandle.Result.Count}");
            
            foreach (var item in _checkHandle.Result)
            {
                Debug.Log($"Check Result :{item}");
            }
            
            needUpdate?.Invoke(_checkHandle.Result.Count > 0);
        }
        
        public async void UpdateResource(Action<float, double, double, float> callback, Action downloadComplete, Action<string, string> errorCallback, string label)
        {
            try
            {
                if (_isCheckUpdate)
                {
                    bool hasLabel = !string.IsNullOrEmpty(label);

                    if (_checkHandle.Result.Count > 0)
                    {
                        var updateHandle = Addressables.UpdateCatalogs(_checkHandle.Result, false);
                        await updateHandle.Task;
                        var locators = updateHandle.Result;
                        HashSet<object> downloadKeys = new HashSet<object>();
                        long totalDownloadSize = 0;
                        foreach (var locator in locators)
                        {
                            Debug.Log($"Update locator:{locator.LocatorId}");

                            var sizeHandle = Addressables.GetDownloadSizeAsync(locator.Keys);
                            await sizeHandle.Task;
                            long downloadSize = sizeHandle.Result;
                            if (downloadSize > 0)
                            {
                                if (hasLabel)
                                {
                                    foreach (var key in locator.Keys)
                                    {
                                        if (key.ToString().Equals(label))
                                        {
                                            totalDownloadSize += downloadSize;
                                            downloadKeys.Add(key);
                                            Debug.Log($"download key: {key}");
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    totalDownloadSize += downloadSize;
                                    foreach (var key in locator.Keys)
                                    {
                                        downloadKeys.Add(key);
                                        //Log.Info($"locator[{locator}] size:{downloadSize} key:{key}");
                                    }
                                }
                            }
                        }
                        if (totalDownloadSize > 0)
                        {
                            double downloadKBSize = totalDownloadSize / 1024.0f;
                            float downloadStartTime = Time.realtimeSinceStartup;
                            var downloadHandle = Addressables.DownloadDependenciesAsync(downloadKeys, Addressables.MergeMode.Union);
                            while (!downloadHandle.IsDone)
                            {
                                float percentage = downloadHandle.PercentComplete;
                                double useTime = Time.realtimeSinceStartup - downloadStartTime;
                                double downloadSpeed = ((double)percentage * downloadKBSize) / useTime;
                                float remainingTime = (float)((downloadKBSize / downloadSpeed) / downloadSpeed - useTime);
                                //回调
                                callback?.Invoke(percentage, downloadKBSize, downloadSpeed, remainingTime);
                                await Task.Delay(300);
                            }
                            Addressables.Release(downloadHandle);
                        }
                        downloadComplete?.Invoke();
                        Addressables.Release(updateHandle);
                    }
                    Addressables.Release(_checkHandle);
                    _isCheckUpdate = false;
                }
            }
            catch (Exception e)
            {
                errorCallback?.Invoke(e.Message, e.ToString());
            }
        }


    }
}