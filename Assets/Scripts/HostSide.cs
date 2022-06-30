using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using Menu;
using TMPro;

public class HostSide : MonoBehaviour
{
    [SerializeField]
    public TMP_InputField _textField;
    static int _port = MenuManager.Port;
    static byte[] _messageReceived;
    static IPEndPoint _endPoint = new IPEndPoint(IPAddress.Any, _port);
    static UdpClient _hostClient = new UdpClient(_endPoint);
    
    public void ReceiveMessage()
    {
        try
        {
            byte[] byteReceived = _hostClient.Receive(ref _endPoint);
            string messageReceived = Encoding.ASCII.GetString(byteReceived);
            _textField.text = messageReceived;
        }
        catch (Exception e)
        {}
    }
}
