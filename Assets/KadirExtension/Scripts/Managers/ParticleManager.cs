using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
namespace KadirExtension.Managers
{
    [CreateAssetMenu(menuName = "KadirExtension/Managers/ParticleManager")]

    public class ParticleManager : ScriptableManager
    {
        public List <ParticleSystem> particlesList = new List<ParticleSystem>();

        public ParticleSystem GetParticleWithIndex(int index)
        {
            return particlesList[index];
        }
        public ParticleSystem GetParticleWithName(string particleName)
        {
            return particlesList.Find(manager => manager.name.Contains(particleName));
        }
        //private string levelInfo;

        //private void Awake()
        //{
        //    levelInfo = Path.Combine(KadirStatics.LEVELS, KadirStatics.LEVELSTABIL + PlayerPrefs.GetInt(KadirStatics.ACTIVE_LEVEL, 1));
        //    LevelScriptable levelScriptable = Resources.Load<LevelScriptable>(levelInfo);
        //    Debug.Log(levelScriptable);
        //    Initialize();
        //}


    }
}