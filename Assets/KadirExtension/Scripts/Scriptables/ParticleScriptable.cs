using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "KadirExtension/ScriptableObjects/ParticleScriptable", order = 2)]
public class ParticleScriptable : ScriptableObject
{
	public List<ParticleSystem> particlesList = new List<ParticleSystem>();
}