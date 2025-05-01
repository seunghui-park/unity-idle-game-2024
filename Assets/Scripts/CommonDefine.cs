using System;

public static class CommonDefine
{
    public const string serverURL = "http://127.0.0.1:80/";

    public struct serverPacket
    {
        public string packetType;
        public string packetValue;
    }
}
