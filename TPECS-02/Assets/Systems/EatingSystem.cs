﻿using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;

public class EatingSystem : FSystem {
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	private Family tiggeredGO = FamilyManager.getFamily(new AllOfComponents(typeof(Triggered2D), typeof(Absorption)));

	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		foreach (GameObject go in tiggeredGO)
        {
			Triggered2D t2d = go.GetComponent<Triggered2D>();

			Absorption abs = go.GetComponent<Absorption>();
			foreach(GameObject target in t2d.Targets)
            {
				if(target.GetComponent<CanInfect>() == null)
                {
					abs.nbrAbsorption++;

					GameObjectManager.unbind(target);

					Object.Destroy(target);
				}

            }
        }


	}
}