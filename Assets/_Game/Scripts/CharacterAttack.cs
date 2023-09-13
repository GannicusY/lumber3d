using System;
using Assets.HeroEditor.Common.Scripts.CharacterScripts;
using Assets.HeroEditor.Common.Scripts.CharacterScripts.Firearms.Enums;
using HeroEditor.Common.Enums;
using UnityEngine;

namespace _Game.Scripts
{
    public class CharacterAttack : MonoBehaviour
    {
        private Character _character;

        private void Awake()
        {
            _character = GetComponent<Character>();
        }

        public void Start()
        {
            if ((_character.WeaponType == WeaponType.Firearm1H || _character.WeaponType == WeaponType.Firearm2H) && 
                _character.Firearm.Params.Type == FirearmType.Unknown)
            {
                throw new Exception("Firearm params not set.");
            }
        }
        
        public void Attack()
        {
            switch (_character.WeaponType)
            {
                case WeaponType.Melee1H:
                case WeaponType.Melee2H:
                case WeaponType.MeleePaired:
                    _character.Slash();
                    break;
                case WeaponType.Bow:
                    break;
                case WeaponType.Firearm1H:
                case WeaponType.Firearm2H:
                    _character.Firearm.Fire.FireButtonDown = true;
                    _character.Firearm.Fire.FireButtonPressed = true;
                    _character.Firearm.Fire.FireButtonUp = true;
                    _character.Firearm.Reload.ReloadButtonDown = false;
                    break;
	            case WeaponType.Supplies:
                    _character.Animator.Play(Time.frameCount % 2 == 0 ? "UseSupply" : "ThrowSupply", 0); // Play animation randomly.
                    break;
			}
        }
    }
}