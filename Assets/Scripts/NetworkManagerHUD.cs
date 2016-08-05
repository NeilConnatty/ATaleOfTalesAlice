#if ENABLE_UNET

using UnityEngine.UI;
using System.Collections.Generic;

namespace UnityEngine.Networking
{
	[AddComponentMenu("Network/NetworkManagerHUD")]
	[RequireComponent(typeof(NetworkManager))]
	[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
	public class NetworkManagerHUD : MonoBehaviour
	{
		public NetworkManager manager;
		[SerializeField] public bool showGUI = true;
		[SerializeField] public int offsetX;
		[SerializeField] public int offsetY;

		public Dropdown joinGameDropdown;

		// Runtime variable
		bool showServer = false;

		void Awake()
		{
			manager = GetComponent<NetworkManager>();
		}

		public void startMatchMaker ()
 		{
 			manager.StartMatchMaker();
 		}

		public void disableMatchMaker ()
		{
			manager.StopMatchMaker();
		}

 		public void CreateMatch (string matchName)
 		{
 			manager.matchName = matchName;
 			manager.matchMaker.CreateMatch(manager.matchName, manager.matchSize, true, "", manager.OnMatchCreate);
 		}

		public void JoinMatch ()
		{
			int index = joinGameDropdown.value;
			manager.matchName = joinGameDropdown.options[index].text;
			manager.matchSize = (uint)manager.matches[index].currentSize;
			manager.matchMaker.JoinMatch(manager.matches[index].networkId, "", manager.OnMatchJoined);
		}

		public void listMatches ()
		{
			List<string> list = new List<string> ();
			manager.matchMaker.ListMatches(0,40, "", manager.OnMatchList);

			foreach (var match in manager.matches)
			{
				list.Add (match.name);
			}

			joinGameDropdown.ClearOptions ();
			joinGameDropdown.AddOptions (list);

			list = null;
		}

		void Update()
		{
			if (!showGUI)
				return;

			if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
			{
				if (Input.GetKeyDown(KeyCode.S))
				{
					manager.StartServer();
				}
				if (Input.GetKeyDown(KeyCode.H))
				{
					manager.StartHost();
				}
				if (Input.GetKeyDown(KeyCode.C))
				{
					manager.StartClient();
				}
			}
			/*
			if (NetworkServer.active && NetworkClient.active)
			{
				if (Input.GetKeyDown(KeyCode.X))
				{
					manager.StopHost();
				}
			}
			*/
		}

		void OnGUI()
		{
			if (!showGUI)
				return;

			int xpos = 10 + offsetX;
			int ypos = 40 + offsetY;
			int spacing = 48;

			if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
			{
				if (GUI.Button(new Rect(xpos, ypos, 400, 40), "LAN Host(H)"))
				{
					manager.StartHost();
				}
				ypos += spacing;

				if (GUI.Button(new Rect(xpos, ypos, 210, 40), "LAN Client(C)"))
				{
					manager.StartClient();
				}
				manager.networkAddress = GUI.TextField(new Rect(xpos + 200, ypos, 190, 40), manager.networkAddress);
				ypos += spacing;

				if (GUI.Button(new Rect(xpos, ypos, 400, 40), "LAN Server Only(S)"))
				{
					manager.StartServer();
				}
				ypos += spacing;
			}
			/*
			else
			{
				if (NetworkServer.active)
				{
					GUI.Label(new Rect(xpos, ypos, 300, 20), "Server: port=" + manager.networkPort);
					ypos += spacing;
				}
				if (NetworkClient.active)
				{
					GUI.Label(new Rect(xpos, ypos, 300, 20), "Client: address=" + manager.networkAddress + " port=" + manager.networkPort);
					ypos += spacing;
				}
			}
			*/

			if (NetworkClient.active && !ClientScene.ready)
			{
				if (GUI.Button(new Rect(xpos, ypos, 400, 40), "Client Ready"))
				{
					ClientScene.Ready(manager.client.connection);

					if (ClientScene.localPlayers.Count == 0)
					{
						ClientScene.AddPlayer(0);
					}
				}
				ypos += spacing;
			}
			/*
			if (NetworkServer.active || NetworkClient.active)
			{
				if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Stop (X)"))
				{
					manager.StopHost();
				}
				ypos += spacing;
			}
			*/
			if (!NetworkServer.active && !NetworkClient.active)
			{
				ypos += 20;

				if (manager.matchMaker == null)
				{
					if (GUI.Button(new Rect(xpos, ypos, 400, 40), "Enable Match Maker (M)"))
					{
						manager.StartMatchMaker();
					}
					ypos += spacing;
				}
				else
				{
					if (manager.matchInfo == null)
					{
						if (manager.matches == null)
						{
							if (GUI.Button(new Rect(xpos, ypos, 400, 40), "Create Internet Match"))
							{
								manager.matchMaker.CreateMatch(manager.matchName, manager.matchSize, true, "", manager.OnMatchCreate);
							}
							ypos += spacing;

							GUI.Label(new Rect(xpos, ypos, 200, 40), "Room Name:");
							manager.matchName = GUI.TextField(new Rect(xpos+200, ypos, 200, 40), manager.matchName);
							ypos += spacing;

							ypos += 20;

							if (GUI.Button(new Rect(xpos, ypos, 400, 40), "Find Internet Match"))
							{
								manager.matchMaker.ListMatches(0,40, "", manager.OnMatchList);
							}
							ypos += spacing;
						}
						else
						{
							foreach (var match in manager.matches)
							{
								if (GUI.Button(new Rect(xpos, ypos, 400, 40), "Join Match:" + match.name))
								{
									manager.matchName = match.name;
									manager.matchSize = (uint)match.currentSize;
									manager.matchMaker.JoinMatch(match.networkId, "", manager.OnMatchJoined);
								}
								ypos += spacing;
							}
						}
					}

					if (GUI.Button(new Rect(xpos, ypos, 400, 40), "Change MM server"))
					{
						showServer = !showServer;
					}
					if (showServer)
					{
						ypos += spacing;
						if (GUI.Button(new Rect(xpos, ypos, 200, 40), "Local"))
						{
							manager.SetMatchHost("localhost", 1337, false);
							showServer = false;
						}
						ypos += spacing;
						if (GUI.Button(new Rect(xpos, ypos, 200, 40), "Internet"))
						{
							manager.SetMatchHost("mm.unet.unity3d.com", 443, true);
							showServer = false;
						}
						ypos += spacing;
						if (GUI.Button(new Rect(xpos, ypos, 200, 40), "Staging"))
						{
							manager.SetMatchHost("staging-mm.unet.unity3d.com", 443, true);
							showServer = false;
						}
					}

					ypos += spacing;

					GUI.Label(new Rect(xpos, ypos, 300, 20), "MM Uri: " + manager.matchMaker.baseUri);
					ypos += spacing;

					if (GUI.Button(new Rect(xpos, ypos, 400, 40), "Disable Match Maker"))
					{
						manager.StopMatchMaker();
					}
					ypos += spacing;
				}
			}
		}
	}
};
#endif //ENABLE_UNET
