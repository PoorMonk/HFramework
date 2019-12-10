using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace HFramework
{
    public class MessageDispatchExample
    {
        [MenuItem("HFramework/Example/DispatchMsg", false, 2)]
        private static void DispatchMsg()
        {
            MessageDispatch.RemoveAllMsgFuncs("test");
            MessageDispatch.RegisterMsg("test", MsgFunc);
            MessageDispatch.RegisterMsg("test", MsgFunc);
            MessageDispatch.SendMsg("test", "hello");
            MessageDispatch.RemoveSingleMsgFunc("test", MsgFunc);
            MessageDispatch.SendMsg("test", "Harkey");
        }

        private static void MsgFunc(object msgText)
        {
            Debug.Log(msgText);
        }
    }
}
