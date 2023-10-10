using HybridCLR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;

public class LoadDll : MonoBehaviour
{
    public static List<string> AOTMetaAssemblyNames { get; } = new List<string>()
    {
        "mscorlib.dll",
        "System.dll",
        "System.Core.dll",
    };

    void Start()
    {
        this.StartGame();
    }

    void StartGame()
    {
        LoadMetadataForAOTAssemblies();

#if !UNITY_EDITOR
        TextAsset dllBytes = LoadTextAsset("Assets/Addressable/Dlls/Assembly-CSharp.dll.bytes");
        var gameAss = System.Reflection.Assembly.Load(dllBytes.bytes);
#else
        var gameAss = AppDomain.CurrentDomain.GetAssemblies().First(assembly => assembly.GetName().Name == "Assembly-CSharp");
#endif

        var hotUpdatePrefab = LoadGameObjectAsset("Assets/Addressable/Prefabs/HotUpdatePrefab.prefab");
        var parent = gameObject.transform.parent;
        var go = Instantiate(hotUpdatePrefab, parent);
        DontDestroyOnLoad(parent);
    }
    
    private static void LoadMetadataForAOTAssemblies()
    {
        HomologousImageMode mode = HomologousImageMode.SuperSet;
        foreach (var aotDllName in AOTMetaAssemblyNames)
        {
            byte[] dllBytes = LoadTextAsset($"Assets/Addressable/Dlls/{aotDllName}.bytes").bytes;
            LoadImageErrorCode err = RuntimeApi.LoadMetadataForAOTAssembly(dllBytes, mode);
            Debug.Log($"LoadMetadataForAOTAssembly:{aotDllName}. mode:{mode} ret:{err}");
        }
    }

    private static TextAsset LoadTextAsset(string assetName)
    {
        var handle = Addressables.LoadAssetAsync<TextAsset>(assetName);
        return handle.WaitForCompletion();
    }
    
    private static GameObject LoadGameObjectAsset(string assetName)
    {
        var handle = Addressables.LoadAssetAsync<GameObject>(assetName);
        return handle.WaitForCompletion();
    }
}
