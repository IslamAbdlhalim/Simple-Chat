using System;
using TMPro;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System.Text;

public class ClientSide : MonoBehaviour
{
   [SerializeField]
   TMP_InputField _ipAddress;
   [SerializeField]
   TMP_InputField _portNumber;
   [SerializeField]
   TMP_InputField _messageToSend;
   bool _isConnected = false;
   int portClient = 1888;
   UdpClient _client = new UdpClient();

   public void Send()
   {
      
      byte[] message = EncodeMessage();
      IPAddress ipServer = IPAddress.Parse(_ipAddress.text);
      int portServer = int.Parse(_portNumber.text);
      IPEndPoint endPoint = new IPEndPoint(ipServer, portServer);
      if (_client is null || !_isConnected)
      {
         try
         {
            _client.Connect(endPoint);
            _isConnected = true;
         }
         catch (Exception e)
         {
            Debug.Log(e);
         }
      }
         
      

      try
      {
         _client.SendAsync(message, message.Length);
      }
      catch (Exception e)
      {
         Debug.Log(e);
      }


   }

   public byte[] EncodeMessage()
   {
      string message = _messageToSend.text;
      byte[] encodedMsg = ASCIIEncoding.ASCII.GetBytes(message);
      return encodedMsg;
   }
}
