// using UnityEditor;
// using UnityEngine;
//
// namespace Wanderer.GameFramework
// {
//     public class StandardAssetPostprocessor : AssetPostprocessor
//     {
//         /// <summary>
//         /// �����������������Դ����󣨵���Դ����������ĩβʱ�����ô˺�����
//         /// </summary>
//         /// <param name="importedAssets"></param>
//         /// <param name="deletedAssets"></param>
//         /// <param name="movedAssets"></param>
//         /// <param name="movedFromAssetPaths"></param>
//         static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
//         {
//             
//         }
//
//         /// <summary>
//         /// ���˺�����ӵ�һ�������У����ڵ���������Դ֮ǰ��ȡ֪ͨ��
//         /// </summary>
//         void OnPreprocessAsset()
//         {
//             //string fileName = assetImporter.GetType().Name;
//             //fileName = $"ProjectSettings/{fileName}.AssetImporter";
//             //if (!File.Exists(fileName))
//             //{
//             //    byte[] buffer = SerializationUtility.SerializeValue(assetImporter, DataFormat.Binary);
//             //    File.WriteAllBytes(fileName, buffer);
//             //}
//         }
//
//         /// <summary>
//         /// ���˺�����ӵ�һ�������У�����������������֮ǰ��ȡ֪ͨ��
//         /// </summary>
//         void OnPreprocessTexture()
//         {
//             if (!CheckFlag("TextureFlag"))
//             {
//                 TextureImporter textureImporter = (TextureImporter)assetImporter;
//                 textureImporter.wrapMode = TextureWrapMode.Clamp;
//                 textureImporter.filterMode = FilterMode.Bilinear;
//                 textureImporter.mipmapEnabled = false;
//                 textureImporter.sRGBTexture = false;
//                 textureImporter.isReadable = false;
//                 if (assetPath.StartsWith("Assets/Game/Texture/UI"))
//                 {
//                     textureImporter.textureType = TextureImporterType.Sprite;
//                 }
//                 else
//                 {
//                     //Android����
//                     TextureImporterPlatformSettings androidSettings = new TextureImporterPlatformSettings();
//                     androidSettings.overridden = true;
//                     androidSettings.name = "Android";
//                     androidSettings.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
//                     androidSettings.format = TextureImporterFormat.ETC2_RGBA8;
//                     textureImporter.SetPlatformTextureSettings(androidSettings);
//
//                     //iOS����
//                     TextureImporterPlatformSettings iOSSettings = new TextureImporterPlatformSettings();
//                     iOSSettings.overridden = true;
//                     iOSSettings.name = "iOS";
//                     iOSSettings.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
//                     iOSSettings.format = TextureImporterFormat.PVRTC_RGBA4;
//                     textureImporter.SetPlatformTextureSettings(iOSSettings);
//                 }
//                 EditorUtility.SetDirty(assetImporter);
//                 textureImporter.SaveAndReimport();
//                 AssetDatabase.Refresh();
//             }
//         }
//
//         /// <summary>
//         /// ���˺�����ӵ�һ�������У����ڵ���ģ�ͣ�.fbx��.mb �ļ��ȣ�֮ǰ��ȡ֪ͨ��
//         /// </summary>
//         void OnPreprocessModel()
//         {
//             if (!CheckFlag("ModelFlag"))
//             {
//                 ModelImporter modelImporter = (ModelImporter)assetImporter;
//                 modelImporter.useFileUnits = false;
//
//                 EditorUtility.SetDirty(assetImporter);
//                 modelImporter.SaveAndReimport();
//                 AssetDatabase.Refresh();
//             }
//         }
//
//         /// <summary>
//         /// ���˺�����ӵ�һ�������У����ڵ�����Ƶ����֮ǰ��ȡ֪ͨ��
//         /// </summary>
//         void OnPreprocessAudio()
//         {
//             if (!CheckFlag("AudioFlag"))
//             {
//                 AudioImporter audioImporter = (AudioImporter)assetImporter;
//                 audioImporter.forceToMono = true;
//                 //Android����
//                 AudioImporterSampleSettings androidSettings = new AudioImporterSampleSettings();
//                 androidSettings.loadType = AudioClipLoadType.Streaming;
//                 androidSettings.compressionFormat = AudioCompressionFormat.AAC;
//                 androidSettings.quality = 100;
//                 androidSettings.sampleRateSetting = AudioSampleRateSetting.OverrideSampleRate;
//                 androidSettings.sampleRateOverride = 22050;
//                 audioImporter.SetOverrideSampleSettings("Android", androidSettings);
//                 //iOS����
//                 AudioImporterSampleSettings iOSSettings = new AudioImporterSampleSettings();
//                 iOSSettings.loadType = AudioClipLoadType.DecompressOnLoad;
//                 iOSSettings.compressionFormat = AudioCompressionFormat.AAC;
//                 iOSSettings.quality = 100;
//                 iOSSettings.sampleRateSetting = AudioSampleRateSetting.OverrideSampleRate;
//                 iOSSettings.sampleRateOverride = 22050;
//                 audioImporter.SetOverrideSampleSettings("iOS", iOSSettings);
//
//                 EditorUtility.SetDirty(assetImporter);
//                 audioImporter.SaveAndReimport();
//                 AssetDatabase.Refresh();
//             }
//         }
//
//         private bool CheckFlag(string key)
//         {
//             if (assetImporter.userData.Equals(key))
//                 return true;
//             assetImporter.userData = key;
//             return false;
//         }
//     }
//
// }