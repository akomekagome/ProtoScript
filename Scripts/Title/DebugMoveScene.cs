using System;
using App.Scripts.Utils;
using UniRx.Triggers;
using UnityEngine;
using UniRx;

namespace App.Scripts.Title
{
	public class DebugMoveScene : MonoBehaviour
	{
		private void Start()
		{
			this.UpdateAsObservable()
				.Where(_ => Input.GetKeyDown(KeyCode.Space))
				.FirstOrDefault()
				.Subscribe(_ =>
				{
					SceneLoader.LoadScene("Base", container => { });
				});
		}
	}
}