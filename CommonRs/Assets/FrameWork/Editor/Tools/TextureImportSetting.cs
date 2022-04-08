using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// AssetPostprocessor: 贴图、模型、声音等资源导入时调用，可自动设置相应参数
/// 导入图片时自动设置图片的参数 
/// </summary>
public class TextureImportSetting : AssetPostprocessor
{
   private readonly string ImageRootPath = "Assets/Image/";

   private void OnPostprocessTexture(Texture2D texture)
   {
      
   }

   private void HandleUIImage()
   {
      FileInfo fileInfo = new FileInfo(assetPath);
      string atlasName = AtlasName(assetPath, fileInfo.Name);
      bool isPng = fileInfo.Extension.Equals(".png");
      
      TextureImporter tImporter = assetImporter as TextureImporter;
      if (isPng)
      {
         tImporter.spritePackingTag = atlasName;
      }
      
      TextureImporterSettings textureImporterSettings = new TextureImporterSettings();
      tImporter.ReadTextureSettings(textureImporterSettings);
      textureImporterSettings.spriteMeshType = SpriteMeshType.Tight;
      textureImporterSettings.spriteExtrude = 1;
      textureImporterSettings.spriteGenerateFallbackPhysicsShape = false;
      
   }
}
