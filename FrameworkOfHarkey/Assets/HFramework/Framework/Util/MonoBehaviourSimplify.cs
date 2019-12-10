using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HFramework
{
    public abstract partial class MonoBehaviourSimplify : MonoBehaviour
    {
        #region MessageDispatch
        class MsgRecord
        {
            public string msgName;
            public Action<object> onReceived;
            private static Stack<MsgRecord> _msgRecordPool = new Stack<MsgRecord>();

            public static MsgRecord Allocate(string msgName, Action<object> onReceived)
            {
                MsgRecord msgRecord = _msgRecordPool.Count > 0 ? _msgRecordPool.Pop() : new MsgRecord();
                msgRecord.msgName = msgName;
                msgRecord.onReceived = onReceived;
                return msgRecord;
            }

            public void Recycle()
            {
                msgName = null;
                onReceived = null;
                _msgRecordPool.Push(this);
            }
        }

        List<MsgRecord> _msgRecorder = new List<MsgRecord>();

        protected void SendMsg(string msgName, object text)
        {
            MessageDispatch.SendMsg(msgName, text);
        }

        protected void RegisterMsg(string msgName, Action<object> onReceived)
        {
            MessageDispatch.RegisterMsg(msgName, onReceived);
            _msgRecorder.Add(MsgRecord.Allocate(msgName, onReceived));
        }

        protected void UnRegisterMsg(string msgName)
        {
            var selectedRecords = _msgRecorder.FindAll(record => record.msgName == msgName);
            selectedRecords.ForEach(record =>
            {
                MessageDispatch.RemoveAllMsgFuncs(msgName);
                _msgRecorder.Remove(record);

                record.Recycle();
            });
            selectedRecords.Clear();
        }

        protected void UnRegisterMsg(string msgName, Action<object> onReceived)
        {
            var selectedRecords = _msgRecorder.FindAll(record => record.msgName == msgName
                && record.onReceived == onReceived);
            selectedRecords.ForEach(record =>
            {
                MessageDispatch.RemoveSingleMsgFunc(msgName, onReceived);
                _msgRecorder.Remove(record);

                record.Recycle();
            });
            selectedRecords.Clear();
        }

        private void OnDestroy()
        {
            OnBeforeDestroy();
            foreach (var msgRecord in _msgRecorder)
            {
                MessageDispatch.RemoveSingleMsgFunc(msgRecord.msgName, msgRecord.onReceived);
                msgRecord.Recycle();
            }
            _msgRecorder.Clear();
        }

        protected abstract void OnBeforeDestroy();
        #endregion
    }
}
