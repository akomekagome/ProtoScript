using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using ProjectConnect.Network.ResponseDto;

namespace App.Scripts.Game.Views
{
	public class ScoreBoard : MonoBehaviour
	{
		[SerializeField] private Text rankList;
		[SerializeField] private Text nameList;
		[SerializeField] private Text scoreList;

		public void ShowRanking(RankingInfo[] rankingInfos)
		{
			rankList.text = string.Join("\n", rankingInfos.Select(x => x.rank));
			nameList.text = string.Join("\n", rankingInfos.Select(x => x.userName));
			scoreList.text = string.Join("\n", rankingInfos.Select(x => x.score.ToString("f2")));
		}
	}
}