using UnityEngine;
using System.Net.Sockets;
using System.Text;

public class PTPIConnection : MonoBehaviour
{

    private TcpClient _client;

    private NetworkStream _stream;

    [Header( "Настройки подключения" )]
    public string ServerAddress = "127.0.0.1";

    public int Port = 8080;


    private void Start()
    {
        ConnectToServer();
    }

    private void ConnectToServer()
    {
        try
        {
            _client = new TcpClient( ServerAddress, Port );
            _stream = _client.GetStream();

            byte[] message = Encoding.UTF8.GetBytes( "CONNECT" );
            _stream.Write( message, 0, message.Length );

            Debug.Log( $"[PTP] Подключение установлено с {ServerAddress}:{Port}" );
        }
        catch ( System.Exception e )
        {
            Debug.LogError( $"[PTP] Ошибка подключения: {e.Message}" );
        }
    }

    public void SendData( string data )
    {
        if ( _client != null && _client.Connected )
        {
            try
            {
                byte[] message = Encoding.UTF8.GetBytes( data );
                _stream.Write( message, 0, message.Length );
                Debug.Log( $"[PTP] Данные отправлены: {data}" );
            }
            catch ( System.Exception e )
            {
                Debug.LogError( $"[PTP] Ошибка отправки: {e.Message}" );
            }
        }
    }

    private void OnApplicationQuit()
    {
        if ( _client != null )
            _client.Close();
    }

    private void OnDestroy()
    {
        if ( _stream != null )
            _stream.Close();
    }

}
