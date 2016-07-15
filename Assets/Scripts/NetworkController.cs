namespace UnityEngine.Networking
{
    public class NetworkController : MonoBehaviour
    {
        public NetworkManager manager;

        void Awake()
		{
			manager = NetworkManager.singleton;
		}

        public void startMatchMaker ()
        {
            manager.StartMatchMaker();
        }

        public void CreateMatch (string matchName)
        {
            manager.matchName = matchName;
            manager.matchMaker.CreateMatch(manager.matchName, manager.matchSize, true, "", manager.OnMatchCreate);
        }
    }
}
