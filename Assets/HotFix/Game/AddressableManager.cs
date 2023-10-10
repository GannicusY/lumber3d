using System;
using System.Collections.Generic;
using _Game.Scripts.Base;
using HotFix.Game;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace _Game.Scripts
{
    public class AddressableManager : BaseMonoSingleton<AddressableManager>
    {
        public AssetLabelReference preloadLabel;
        public AssetReferenceSprite bgRefSprite;
        public SpriteRenderer bgRender;
        public AssetReferenceGameObject treeRef;
        public Transform treeTransform;
        public Transform rewardHolder;
        
        public override void DoAwake()
        {
            base.DoAwake();
            Addressables.InitializeAsync();
        }

        private void Start()
        {
            DownloadPreloadRes();
        }

        private void DownloadPreloadRes()
        {
            Debug.Log($"start load asset by label:{preloadLabel.labelString}");
            Addressables.DownloadDependenciesAsync(preloadLabel.labelString).Completed += OnPreloadDone;
        }

        private void OnPreloadDone(AsyncOperationHandle handle)
        {
            Debug.Log($"done load asset by label:{preloadLabel.labelString} status:{handle.Status}");
            if (handle.Status == AsyncOperationStatus.Failed)
            {
                Debug.Log("failed download preload resources, will try 1 second later!");
                Invoke(nameof(DownloadPreloadRes), 1);
                return;
            }

            AssignBg();
            InstantiateTree();
        }


        private void AssignBg()
        {
            bgRefSprite.LoadAssetAsync<Sprite>().Completed += op =>
            {
                if (op.Status == AsyncOperationStatus.Succeeded)
                {
                    Debug.Log("set bg done by ref");
                    bgRender.sprite = op.Result;
                }
            };
        }
        
        private void InstantiateTree()
        {
            treeRef.InstantiateAsync(treeTransform).Completed += op =>
            {
                op.Result.GetComponent<GiftTree>().RewardHolder = rewardHolder;
            };
        }
    }
}