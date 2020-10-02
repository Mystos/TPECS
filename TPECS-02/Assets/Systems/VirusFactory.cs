﻿using UnityEngine;
using FYFY;

public class VirusFactory : FSystem {
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	private Family factoryF = FamilyManager.getFamily(new AllOfComponents(typeof(Factory)));

	private Factory factory;

    public VirusFactory()
    {
		factory = factoryF.First().GetComponent<Factory>();
    }

	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		factory.reloadProgress += Time.deltaTime;
		if(factory.reloadProgress >= factory.reloadTime)
        {
			GameObject go = Object.Instantiate<GameObject>(factory.prefab);
			GameObjectManager.bind(go);
			go.transform.position = new Vector3((Random.value - 0.5f) * 7,
				(Random.value - 0.5f) * 5.2f);
			factory.reloadProgress = 0;
        }
	}

	public void popVirus(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
			GameObject go = Object.Instantiate<GameObject>(factory.prefab);
			GameObjectManager.bind(go);
			go.transform.position = new Vector3((Random.value - 0.5f) * 7,
				(Random.value - 0.5f) * 5.2f);
		}
    }

}