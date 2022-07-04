using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
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
    [SerializeField]
    GameObject _myPrefab;
    public async void ReceiveMessage()
    {
        try
        {
            UdpReceiveResult byteReceived = await _hostClient.ReceiveAsync();

            _messageReceived = byteReceived.Buffer;
            string messageReceived = Encoding.ASCII.GetString(_messageReceived);
            _textField.text = messageReceived;
            Instantiate(_myPrefab, new Vector3(1f, 0f, 0f), Quaternion.identity);
        }
        catch (Exception e)
        {}
    }

   
}
