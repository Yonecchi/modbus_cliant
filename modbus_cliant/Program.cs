using System;
using System.Net.Sockets;
namespace modbus_cliant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (TcpClient client = new TcpClient())
            {
                client.Connect("127.0.0.1", 502); // サーバのIPアドレスとポート番号
                NetworkStream stream = client.GetStream();

                // リクエストデータの生成
                byte[] requestData = GenerateModbusRequest();

                // リクエストデータをサーバに送信
                stream.Write(requestData, 0, requestData.Length);

                // サーバからのレスポンスを受信
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);

                // レスポンスデータの処理
                ProcessModbusResponse(buffer, bytesRead);
            }

            static byte[] GenerateModbusRequest()
            {
                // ここでModbusのリクエストデータを生成するロジックを実装
                // requestDataに生成したリクエストデータを格納して返す
                byte[] requestData = new byte[] { 0x10, 0x10, 0x10, 0x10, 0x10 , 0x10 };
                // リクエストデータの生成ロジックを実装
                Console.WriteLine("senddata: " + BitConverter.ToString(requestData));
                return requestData;
            }

            static void ProcessModbusResponse(byte[] responseData, int length)
            {
                // ここで受信したレスポンスデータを解析し、処理するロジックを実装
                Console.WriteLine("retdata: " + BitConverter.ToString(responseData));

                Console.ReadKey();
            }
        }
    }
}