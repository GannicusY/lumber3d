using HybridCLR.Editor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Build;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;
using UnityEngine.AddressableAssets;

/// <summary>
/// ѡ���ļ��У����ļ���Ϊ��λ������
/// ����˵�
/// </summary>
public class AddressableUtil
{
    public static string FormatFilePath(string filePath)
    {
        var path = filePath.Replace('\\', '/');
        path = path.Replace("//", "/");
        return path;
    }

    #region �������
    public static string GetServerDataPath()
    {
        var path = Application.dataPath.Replace("Assets", "ServerData");
        path = FormatFilePath(path);
        return path;
    }

    //[MenuItem("AddressableMenu/Clean Content And Folder", priority = 2)] //�����ϴδ������Դ�����������ȸ�������
    public static void ClearAllAddressBuild()
    {
        var settings = AddressableAssetSettingsDefaultObject.Settings;
        AddressableAssetSettings.CleanPlayerContent(settings.ActivePlayerDataBuilder);
        var serverDataPath = AddressableAssetSettingsDefaultObject.Settings.RemoteCatalogBuildPath.GetValue(AddressableAssetSettingsDefaultObject.Settings);
        Debug.Log("clear serverdata " + serverDataPath);
        if (System.IO.Directory.Exists(serverDataPath))
        {
            System.IO.Directory.Delete(serverDataPath, true);
        }
    }

    /// <summary>
    /// ���¹���Address��Դ
    /// </summary>
    [MenuItem("AddressableMenu/Clean And Build Content", priority = 3)]
    public static void ReBuildAddress()
    {
        ClearAllAddressBuild();
        //2.��������Դ�������·�����ǩ(TODO)
        //LoopSetAllDirectorToAddress(GameSettings.GetABRootPath());
        BuildAssetsCommand.BuildSceneAssetBundleActiveBuildTarget();
        AddressableAssetSettings.BuildPlayerContent();
        
    }

    /// �Աȸ����б�
    //[MenuItem("AddressableMenu/GatherModifiedEntries And Creat Update Group", priority = 4)]
    public static void CheckForUpdateContent()
    {
        //���ϴδ������Դ�Ա� to get the path of the bin file automatically.
        string buildPath = ContentUpdateScript.GetContentStateDataPath(false);
        var m_Settings = AddressableAssetSettingsDefaultObject.Settings;
        List<AddressableAssetEntry> entrys = ContentUpdateScript.GatherModifiedEntries(m_Settings, buildPath);
        if (entrys.Count == 0)
        {
            Debug.Log("û����Դ����");
            return;
        }
        StringBuilder sbuider = new StringBuilder();
        sbuider.AppendLine("Need Update Assets:");
        foreach (var entry in entrys)
        {
            sbuider.AppendLine(entry.address);
        }
        Debug.Log(sbuider.ToString());
        //�����޸Ĺ�����Դ��������
        var groupName = string.Format("UpdateGroup_{0}", DateTime.Now.ToString("yyyyMMddHHmmss"));
        ContentUpdateScript.CreateContentUpdateGroup(m_Settings, entrys, groupName);
    }

    //�������
    [MenuItem("AddressableMenu/Build Update Content", priority = 5)]
    public static void BuildUpdate()
    {
        BuildAssetsCommand.BuildSceneAssetBundleActiveBuildTargetExcludeAOT();

        //�Աȸ����б�
        CheckForUpdateContent();

        var path = ContentUpdateScript.GetContentStateDataPath(false);
        var m_Settings = AddressableAssetSettingsDefaultObject.Settings;
        AddressablesPlayerBuildResult result = ContentUpdateScript.BuildContentUpdate(AddressableAssetSettingsDefaultObject.Settings, path);
        Debug.Log("BuildFinish path = " + m_Settings.RemoteCatalogBuildPath.GetValue(m_Settings));
       
    }

    //��ӡ����·��
    [MenuItem("AddressableMenu/Print Path", priority = 7)]
    public static void Test()
    {
        Debug.Log("BuildPath = " + Addressables.BuildPath);
        Debug.Log("PlayerBuildDataPath = " + Addressables.PlayerBuildDataPath);
        Debug.Log("RemoteCatalogBuildPath = " + AddressableAssetSettingsDefaultObject.Settings.RemoteCatalogBuildPath.GetValue(AddressableAssetSettingsDefaultObject.Settings));
    }
    
    #endregion
}
