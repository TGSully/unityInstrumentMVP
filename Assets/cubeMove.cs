using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Threading;


public class cubeMove : MonoBehaviour
{

    private static Thread clientRecieveThread;
    static Vector3 position;

    // Use this for initialization
    void Start()
    {
        StartClient();
        GetComponent<Rigidbody>().isKinematic = true;
    }

    static void StartClient() 
    {
        //try{
            clientRecieveThread =  new Thread(new ThreadStart(GetMessages));
            clientRecieveThread.IsBackground = true;
            clientRecieveThread.Start();

        //}
        //catch (Exception e)
        //{
        //    print(e);
        //}
    }


    // Update is called once per frame
    void Update()
    {
        //GetMessages();
        //transform.Translate(1f * Time.deltaTime , 0f , 0f);
        //float m = 5;
        //float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical");
        //transform.Translate(x * Time.deltaTime * m, 0f * m, y * Time.deltaTime * m);
        print(position);
        transform.position = position;
    }

    static void GetMessages ()
    {
        TcpClient client;
        NetworkStream stream;

        try
        {
            client = new TcpClient("127.0.0.1", 8000);

            stream = client.GetStream();

            while (true)
            {
                // if (stream == null) continue;

                byte[] data = new byte[256];
                int bytes = stream.Read(data, 0, data.Length);
                const float scale = 50;
                int x = (int)(sbyte)data[0];
                int y = (int)(sbyte)data[1];
                int z = (int)(sbyte)data[2];
                print(x + " " +  y + " " + z);
                position = new Vector3(x/scale, y /scale,z /scale);
                print(position);

            }
        }
        catch (SocketException e)
        {
            print(e);
        }

 
    }

    //private void OnDestroy()
    //{
    //    if (stream != null)
    //    {
    //        stream.Close();
    //    }
    //    if (client != null)
    //    {
    //        client.Close();
    //    }
    //}

}
