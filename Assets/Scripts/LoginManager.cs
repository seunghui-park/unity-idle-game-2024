using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LoginManager : MonoBehaviour
{
    public InputField idField;
    public InputField passwordField;
    public NetworkManager networkManager;

    public void OnClickLoginBtn()
    {
        string userId = idField.text;
        string userPwd = passwordField.text;

        List<CommonDefine.serverPacket> packetList = new List<CommonDefine.serverPacket>();

        CommonDefine.serverPacket packet1;
        packet1.packetType = "userid";
        packet1.packetValue = userId;
        packetList.Add(packet1);

        CommonDefine.serverPacket packet2;
        packet2.packetType = "userpwd";
        packet2.packetValue = userPwd;
        packetList.Add(packet2);

        StartCoroutine(networkManager.ServerCall("login", packetList));
    }
}
