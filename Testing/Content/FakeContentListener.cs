/// <author>Sahil J. Chaudhari</author>
/// <created>20/11/2021</created>
/// <modified>24/11/2021</modified>
/// <summary>
/// This file contains Fake listener which will mimic UX's defined functions of IContentListener for tesing purpose
/// </summary>

using System.Collections.Generic;
using System.Diagnostics;
using Networking;
using Content;
using System;

namespace Testing.Content
{
    public class FakeContentListener : IContentListener
    {
        private ReceiveMessageData _rcvMsgData;
        private List<ChatContext> _chatContextList;

        public FakeContentListener()
        {
            _rcvMsgData = new ReceiveMessageData();
            _chatContextList = new List<ChatContext>();
        }

        /// <summary>
        ///     Handler for messages received by the Content module.
        /// </summary>
        /// <param name="messageData">Received message</param>
        public void OnMessage(ReceiveMessageData messageData)
        {
            _rcvMsgData = messageData;
        }

        public ReceiveMessageData GetOnMessageData()
        {
            return _rcvMsgData;
        }

        /// <summary>
        ///     Handler for the event of all messages sent to/from client being received at once
        ///     The Dashboard module may simply throw an excpetion in the body of
        ///     this function because it doesn't expect to receive list of all messages
        ///     as it is running on the server, not on the clients.
        /// </summary>
        /// <param name="allMessages">list of Thread objects containing all messages</param>
        public void OnAllMessages(List<ChatContext> allMessages)
        {
            _chatContextList = allMessages;
        }

        public List<ChatContext> GetOnAllMessagesData()
        {
            return _chatContextList;
        }
    }
}