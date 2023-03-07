using System.Collections.Generic;
using UnityEngine;

namespace BNB
{
	public class EffectManager : MonoBehaviour
	{
		public static EffectManager instance;

		[SerializeField]
		private Effect _emptyEffect;
		private Effect _currentEffect;

		public List<Effect> Effects;
		public Effect defaultEffect;

		private float timer = 0;
		private bool spawned = false;

		private void Awake()
		{
			if (instance == null) {
				instance = this;
			}
			_currentEffect = _emptyEffect;
		}

		private void Update() {
			timer += Time.deltaTime;
			if (timer > 0.1f && !spawned) {
				EffectManager.instance.SpawnEffect(defaultEffect);
				spawned = true;
			}
		}

		public void SpawnEffect(Effect effect) {

			if (_emptyEffect != null) {
				Destroy(_emptyEffect.gameObject);
			}
			if (_currentEffect != null) {
				DestroyImmediate(_currentEffect.gameObject);
			}
			Effect newEffect = Instantiate(effect, transform);
			newEffect.gameObject.SetActive(true);
			_currentEffect = newEffect;

			GameObject.Find("ResultCamera").SetActive(false);
		}
	}
}
