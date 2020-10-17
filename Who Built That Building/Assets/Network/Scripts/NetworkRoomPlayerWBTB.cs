using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class NetworkRoomPlayerWBTB : NetworkRoomPlayer // 플레이어의 행동을 서버와 동기화하는 스크립트.
{
    [SerializeField] GameObject playernameP, readystateP; // 플레이어 이름과 레디 상태 UI.
    [SerializeField] GameObject banP; // 밴 버튼 UI.
    [SerializeField] Text playername, readystate; // 플레이어 이름 텍스트와 레디 상태 텍스트.
    RectTransform p1; // 첫번째 플레이어 UI의 위치.

    private void Awake() // Lobby Scene으로 들어왔을때 제일 처음 실행.
    {
        p1 = GameObject.Find("Player1Position").GetComponent<RectTransform>(); // 첫번째 플레이어 UI의 위치를 가져옴.
    }

    private void Update() // 상시 실행.
    {
        // Lobby에서 연결이 끊기면 위의 Component들이 null상태로 돌아감.
        // 이 때 아래와 같이 변수를 할당하거나 참조하려고 하면 오류가 발생.
        // 따라서 이를 막기 위한 조건문.
        if (p1 != null &&
            playernameP != null &&
            readystateP != null &&
            banP != null &&
            playername != null &&
            readystate != null &&
            p1 != null)
        {
            playername.text = "p" + index; // 플레이어 이름을 설정: p0, p1, p2 ...

            // 플레이어 이름, 레디 상태, 밴 버튼 UI들의 위치를 첫번째 플레이어 UI의 위치를 이용하여 배치.
            playernameP.GetComponent<RectTransform>().anchoredPosition = new Vector2(p1.anchoredPosition.x, p1.anchoredPosition.y - (index * 40));
            readystateP.GetComponent<RectTransform>().anchoredPosition = new Vector2(p1.anchoredPosition.x + 100, p1.anchoredPosition.y - (index * 40));
            banP.GetComponent<RectTransform>().anchoredPosition = new Vector2(p1.anchoredPosition.x + 180, p1.anchoredPosition.y - (index * 40));
        }

        if (readyToBegin) // 레디가 됐다면,
            readystate.text = "Ready"; // 레디 상태 UI의 텍스트를 Ready로 변경.
        else // 레디가 안됐다면,
            readystate.text = "Not Ready"; // 레디 상태 UI의 텍스트를 Not Ready로 변경.

        if (NetworkManager.IsSceneActive("Lobby")) // 현재 Scene이 Lobby라면,
        {
            // 플레이어 이름, 레디 상태 UI를 활성화.
            playernameP.SetActive(true);
            readystateP.SetActive(true);
            if(isServer) // 호스트 플레이어라면,
                banP.SetActive(true); // 밴 버튼 UI도 활성화.
        }
        else // 현재 Scene이 Lobby가 아니라면,
        {
            // 플레이어 이름, 레디 상태 UI를 비활성화.
            playernameP.SetActive(false);
            readystateP.SetActive(false);
            if(isServer) // 호스트 플레이어라면,
                banP.SetActive(false); // 밴 버튼 UI도 비활성화.
        }
    }
    
    public void ReadyButton() // 레디 상태 UI를 클릭하면,
    {
        if (NetworkClient.active && isLocalPlayer) // Client가 서버에 잘 연결돼있고, 그리고 레디 버튼을 누른게 해당 플레이어 본인일 경우,
        {

            if (readyToBegin) // 레디 상태였다면,
            {
                    CmdChangeReadyState(false); // Not Ready 상태로 바꾸길 서버에 요청.
            }
            else // 레디 상태가 아니었다면,
            {
                    CmdChangeReadyState(true); // Ready 상태로 바꾸길 서버에 요청.
            }

        }
    }

    public void BanButton() // 밴 버튼 UI를 클릭할 경우,
    {
        if ((isServer && index > 0) || isServerOnly) // 호스트 플레이어라면,
        {
            GetComponent<NetworkIdentity>().connectionToClient.Disconnect(); // 해당 Client의 연결을 끊음.
        }
    }
}
