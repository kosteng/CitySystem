using System;
using Characters;
using Units.Views;
using UnityEngine;

public class CharacterAnimationSwitcher : ICharacterAnimationSwitcher
{
    private static readonly int _moving = Animator.StringToHash("Moving");
    private static readonly int _extract = Animator.StringToHash("Extracting");
    
    public void UpdateAnimation(CharacterView character)
    {
        character.Animator.SetBool(_moving, character.IsMoving);
        character.Animator.SetBool(_extract, character.CharacterCommand == ECharacterCommand.Interact);
        switch (character.CharacterCurrentState)
        {
            case ECharacterState.None:
                break;

            case ECharacterState.Move:
                break;

            case ECharacterState.Idle:
                break;

            case ECharacterState.Interact:
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(character.CharacterCurrentState), character.CharacterCurrentState, null);
        }
    }


}
