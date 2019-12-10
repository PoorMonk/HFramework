using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace HFramework
{
    public partial class CommonUtil
    {
        public static void CopyText(string text)
        {
            GUIUtility.systemCopyBuffer = text;
        }
    }
}
