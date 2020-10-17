using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class NetworkManagerHUDWBTB : NetworkBehaviour // 서버의 Connect&Disconnect를 관리하는 스크립트.
{
    NetworkManager manager; // NetworkRoomManager의 NetworkManager 기능을 이용할 예정이므로 이 변수를 정의.

    private void Awake() // Title Scene으로 들어왔을때 제일 처음 실행.
    {
        manager = GetComponent<NetworkManager>(); // NetworkRoomManager의 NetworkManager 기능을 가져옴.
    }

    public void MakeRoom() // 방만들기 버튼 UI를 누를 경우
    {
        // Client로서 서버에 잘 연결돼있거나(앞의 두 조건: 2중 체크), 이미 본인이 서버를 호스팅하고 있으면,
        if (NetworkClient.active || NetworkClient.isConnected || NetworkServer.active) return; // 아무것도 안함.
        
        manager.StartHost(); // 위와 같은 상황이 아니면, 서버를 호스팅.
                             // 호스팅: 본인의 IP로 서버를 만들고, Client로서 이 서버에 참여하게 됨.

        if (NetworkClient.isConnected && !ClientScene.ready) // Client로서 서버에 연결은 됐는데, Client에 게임을 로드할 준비까지는 안됐었다면,
        {
            ClientScene.Ready(NetworkClient.connection); // 해당 준비를 마치고,
            if(ClientScene.localPlayer == null) // 플레이어로 서버에 등록이 안됐다면,
            {
                ClientScene.AddPlayer(NetworkClient.connection); // 서버에 플레이어로 등록한다.
            }
        }
    }

    public void SearchingRoom() // 방참여 버튼 UI를 눌러 IP 입력 후 Enter를 누르면,
    {
        // 위와 같음.
        if (NetworkClient.active || NetworkClient.isConnected || NetworkServer.active) return;

        manager.StartClient(); // 위와 같은 상황이 아니면, 입력한 IP 서버에 Client로 참여.
        
    }
    
    public void StopButtons() // Lobby에서 뒤로가기 버튼 UI를 누를 경우,
    {
        // 호스트중이라면(본인의 IP로 서버를 만들고 있고, Client로서 이 서버에 참여하고 있으면),
        if (NetworkServer.active && NetworkClient.isConnected)
        {
            manager.StopHost(); // 호스팅을 멈추고 Title Scene으로 넘어감.
        }
        
        else if (NetworkClient.isConnected) // Client로서 서버에 연결중이라면,
        {
            manager.StopClient(); // Client로서 서버 연결을 끊고, Title Scene으로 넘어감.
        }
    }

    


}
