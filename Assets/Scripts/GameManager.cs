using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;


public class GameManager : NetworkManager {
    // Start is called before the first frame update

    private int roomSize = 10; //FIXME load from room settings
    private int impostors = 1; //FIXME load from room settings
    void Start() {
    }
    
    public virtual void OnServerAddPlayer(NetworkConnection conn, short playerControllerId) {
        var player = (GameObject)GameObject.Instantiate(playerPrefab);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
