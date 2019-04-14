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
        //StartClient();
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

    void onPosition(string serverMessage)
    {
        float x, y, z;
        print(serverMessage);
        if (OnNewPosition == null) { return; }
        string[] coords = serverMessage.Split(' ');
        x = float.Parse(coords[0]);
        y = float.Parse(coords[1]);
        z = float.Parse(coords[2]);
        if (z < 0.01f) { return; }
        var position = new Vector3(x, y, z);

        OnNewPosition(position);

    }

    static void GetMessages()
    {
        TcpClient client;
        NetworkStream stream;
        float x, y, z;
        //const float SCALE = 2;


        try
        {
            client = new TcpClient("10.0.0.48", 8000);
            //client = new TcpClient("10.0.0.48", 8000);
            stream = client.GetStream();
            while (true)
            {

                byte[] data = new byte[1024];
                int bytes = stream.Read(data, 0, data.Length);
                stream.Flush();
                string serverMessage = Encoding.ASCII.GetString(data);
                print(serverMessage);
                if (bytes == 0) { continue; }
                if (OnNewPosition == null) { continue; }
                string[] coords = serverMessage.Split(' ');
                //try
                //{
                    x = float.Parse(coords[0]);
                    y = float.Parse(coords[1]);
                    z = float.Parse(coords[2]);
                    if (z < 0.01f) continue;
                    var position = new Vector3(x, y, z);
                    //position *= SCALE;
                    OnNewPosition(position);
                //}
                //catch (Ec)
                //{
                //    print("Error parsing float");
                //}
            }
        }
        catch (SocketException e)
        {
            print(e);
        }


    }


}
