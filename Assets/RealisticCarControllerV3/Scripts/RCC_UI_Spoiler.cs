﻿//----------------------------------------------
//			Realistic Car Controller
//
// Copyright © 2023 BoneCracker Games
// http://www.bonecrackergames.com
//
//----------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI spoiler button.
/// </summary>
[AddComponentMenu("BoneCracker Games/Realistic Car Controller/UI/Modification/RCC UI Spoiler Button")]
public class RCC_UI_Spoiler : MonoBehaviour {

    public int index = 0;

    public void Upgrade() {

        RCC_CustomizationManager handler = RCC_CustomizationManager.Instance;
        handler.Spoiler(index);

    }

}
