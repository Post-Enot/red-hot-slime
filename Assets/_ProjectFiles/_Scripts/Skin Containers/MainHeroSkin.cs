using System;
using UnityEngine;

[Serializable]
public class MainHeroSkin : Skin
{
	[Space]

	[SerializeField] private string _jumpTriggerName = "jump";
	[SerializeField] private string _dieTriggerName = "die";
	[SerializeField] private string _reviveTriggerName = "revive";

	[Space]

	[SerializeField] private AudioClip _moveSound;
	[SerializeField] private AudioClip _damageSound;
	[SerializeField] private AudioClip _deathSound;

	public AudioClip MoveSound => _moveSound;
	public AudioClip DamageSound => _damageSound;
	public AudioClip DeathSound => _deathSound;

	public string JumpTriggerName => _jumpTriggerName;
	public string DieTriggerName => _dieTriggerName;
	public string ReviveTriggerName => _reviveTriggerName;
}
