using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "ConversationSOGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "",
	    order = 120)]
	public sealed class ConversationSOGameEvent : GameEventBase<ConversationSO>
	{
	}
}