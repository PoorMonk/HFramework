using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace HFramework
{
    public class MessageDispatch 
    {      
        private static Dictionary<string, Action<object>> _msgs = new Dictionary<string, Action<object>>();

        public static void RegisterMsg(string msgName, Action<object> onReceived)
        {
            if (!_msgs.ContainsKey(msgName))
            {
                _msgs.Add(msgName, onReceived);
            }
            else
            {
                _msgs[msgName] += onReceived;
            }
        }

        public static void RemoveAllMsgFuncs(string msgName)
        {
            if (_msgs.ContainsKey(msgName))
            {
                _msgs.Remove(msgName);
            }
        }

        public static void RemoveSingleMsgFunc(string msgName, Action<object> onReceived)
        {
            if (_msgs.ContainsKey(msgName))
            {
                _msgs[msgName] -= onReceived;
                if (_msgs[msgName] == null)
                {
                    _msgs.Remove(msgName);
                }
            }
        }

        public static void SendMsg(string msgName, object msgText)
        {
            if (_msgs.ContainsKey(msgName))
            {
                _msgs[msgName](msgText);
            }
            else
            {
                Debug.Log("sendMsg failed! this msg is not existed: " + msgName);
            }
        }
    }

}
