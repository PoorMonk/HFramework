using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEditor;


namespace HFramework
{
    public class AutoExporter
    {
        public static string GeneratePackageName()
        {
            return "HFramework_" + DateTime.Now.ToString("yyyyMMdd_HH") + ".unitypackage";
        }

        public static void OpenFolder(string path)
        {
            Application.OpenURL("file:///" + path);
        }

        [MenuItem("HFramework/Framework/ExportPackage %e", false, 1)]
        private static void ExportPackage()
        {
            AssetDatabase.ExportPackage("Assets/HFramework", GeneratePackageName(), ExportPackageOptions.Recurse);
            OpenFolder(Path.Combine(Application.dataPath, "../"));
        }
    }
}
