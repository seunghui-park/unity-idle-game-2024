using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviour
{
    public IEnumerator ServerCall(string api, List<CommonDefine.serverPacket> packetList)
    {
        string serviceName = CommonDefine.serverURL + api + "?";

        for (int i = 0; i < packetList.Count; i++)
        {
            var packet = packetList[i];
            if (i > 0) serviceName += "&";
            serviceName += packet.packetType + "=" + packet.packetValue;
        }

        UnityWebRequest www = UnityWebRequest.Get(serviceName);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            string response = www.downloadHandler.text;

            if (response == "success")
            {
                SceneManager.LoadScene("SignInScene");
            }
            else
            {
                Debug.LogWarning("로그인 실패: " + response);
            }
        }
        else
        {
            Debug.LogError("네트워크 오류: " + www.error);
        }
    }
}
