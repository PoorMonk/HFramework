using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace HFramework
{
    public class CommonUtilExample 
    {
        [MenuItem("HFramework/Example/CopyText", false, 1)]
        private static void CopyTextMenu()
        {
            CommonUtil.CopyText("Copy Text");
        }
    }
}
