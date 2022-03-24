using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class FactoryTestHomeWork : MonoBehaviour
{
    public class MobDescription
    {
        public float MaxHealth;
        public float Damage;
    }
    [CreateAssetMenu(fileName = "MobDescriptions", menuName = "MobDescriptions", order = 51)]
    public class MobDescriptions : ScriptableObject
    {
        [SerializeField] private List<MobDescription> _listmag;
        [SerializeField] private List<MobDescription> _listinfantary;

        public List<MobDescription> Listmag => _listmag;
        public List<MobDescription> Listinfantary => _listinfantary;
    }
    public class MobModel
    {
        private MobDescription _description;
        private float _currentHealth;

        public MobDescription Description => _description;

        public MobModel(MobDescription description)
        {
            _description = description;
            _currentHealth = _description.MaxHealth;
        }

    }
    public class Factory
    {
        private Dictionary<string, Func<int, MobModel>> mobFactory;

        public void Init(MobDescriptions descriptions)
        {
            mobFactory = new Dictionary<string, Func<int, MobModel>>()
        {
            {"mag", (level) => new MobModel(descriptions.Listmag[level])},
            {"infantary", (level) => new MobModel(descriptions.Listinfantary[level])}
        };

        }

        public MobModel CreateMobModel(string nameMob, int level)
        {
            return mobFactory[nameMob](level);
        }
    }
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private MobDescriptions _mobDescriptions;

        private Factory _factory;

        private void Start()
        {
            _factory = new Factory();
            _factory.Init(_mobDescriptions);

            _factory.CreateMobModel("mag", 2);
            _factory.CreateMobModel("infantary", 2);
        }
    }
}
