/*  
*	TickLuck team
*	All rights reserved
*/

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
/// <summary>
/// Save the instance of PlayerScoreRecorder 
/// into binary file
/// </summary>
	public static void SavePlayer(PlayerProgress player)
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/player.tickLuck";

		FileStream stream = new FileStream(path, FileMode.Create);
		//PlayerScoreRecorder playerProgress = new PlayerScoreRecorder(player);

		player.s_score = PlayerScoreRecorder.s_recorder_instance.m_score;
		player.s_enemyKilled = PlayerScoreRecorder.s_recorder_instance.m_enemyKilled;
		player.s_timeOfPlay = PlayerScoreRecorder.s_recorder_instance.timeOfPlay;
		player.s_moneyAmount = PlayerScoreRecorder.s_recorder_instance.moneyAmount;

		binaryFormatter.Serialize(stream, player);

		stream.Close();

		Debug.Log("Saved");
	}

	public static PlayerProgress LoadPlayer()
	{
		string path = Application.persistentDataPath + "/player.tickLuck";

		if (File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			PlayerProgress data = formatter.Deserialize(stream) as PlayerProgress;
			stream.Close();

			return data;
		}
		else
		{
			Debug.Log("Saved file is not found in " + path);
			return null;
		}
	}
}
