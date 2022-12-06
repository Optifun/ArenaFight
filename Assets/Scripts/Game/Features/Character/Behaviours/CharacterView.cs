using Game.Services;
using UnityEngine;

namespace Game.Features.Character.Behaviours
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        [SerializeField] private EntityReference _entity;
    }
}