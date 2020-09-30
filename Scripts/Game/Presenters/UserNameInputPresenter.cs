using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace App.Game.Presenters
{
	public class UserNameInputPresenter : MonoBehaviour
	{
		[SerializeField] private InputField inputField;
		[SerializeField] private Button sendButton;
		private Subject<string> _sendUserNameSubject = new Subject<string>();
		public IObservable<string> SendUserNameObservable => _sendUserNameSubject.AsObservable();
		

		private void Start()
		{
			sendButton.OnClickAsObservable()
				.Where(_ => inputField.text != "")
				.Subscribe(_ =>
				{
					Debug.Log(inputField.text);
					_sendUserNameSubject.OnNext(inputField.text);
					_sendUserNameSubject.OnCompleted();
				}).AddTo(this);
		}
	}
}