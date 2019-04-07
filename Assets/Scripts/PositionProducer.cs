using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Net.Sockets;
using System.Text;

public class PositionProducer : MonoBehaviour
{
    public delegate void PositionAction(Vector3 position);
    public static event PositionAction OnNewPosition;
    private static Thread clientRecieveThread;

    void Start()
    {
        StartClient();
    }

    void Update()
    {
        
    }

    static void StartClient()
    {

        clientRecieveThread = new Thread(new ThreadStart(GetMessages));
        clientRecieveThread.IsBackground = true;
        clientRecieveThread.Start();
    }

    static void GetMessages()
    {
        TcpClient client;
        NetworkStream stream;

        try
        {
            //client = new TcpClient("192.168.43.221", 8000);
            client = new TcpClient("10.0.0.48", 8000);
            stream = client.GetStream();
            while (true)
            {

                byte[] data = new byte[1024];
                int bytes = stream.Read(data, 0, data.Length);
                string serverMessage = Encoding.ASCII.GetString(data);
                const float SCALE = 2;
                if (bytes == 0) { continue; }
                if (OnNewPosition == null) { continue; }
                string[] coords = serverMessage.Split(' ');
                float x = float.Parse(coords[0]) - 0.5f;
                float y = float.Parse(coords[1]);
                float z = float.Parse(coords[2]) - 0.5f;
                var position = new Vector3(x, z, y);
                position *= SCALE;
                OnNewPosition(position);
            }
        }
        catch (SocketException e)
        {
            print(e);
        }


    }


}
