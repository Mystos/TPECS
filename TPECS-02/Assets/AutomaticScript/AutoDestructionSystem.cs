using UnityEngine;
using FYFY;

public class AutoDestructionSystem : FSystem {
	private Family absorption = FamilyManager.getFamily(new AllOfComponents(typeof(Absorption)));
	private Family infected = FamilyManager.getFamily(new AllOfComponents(typeof(Health), typeof(Infection), typeof(Factory)));


	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
        foreach (GameObject gameObject in absorption)
        {
			if (gameObject.GetComponent<Absorption>().nbrAbsorption >= gameObject.GetComponent<Absorption>().nbrAbsorptionMax)
			{
				GameObjectManager.unbind(gameObject);
				Object.Destroy(gameObject);
			}
        }

		foreach (GameObject gameObject in infected)
		{
			Health health = gameObject.GetComponent<Health>();
			if (health.actualHealth <= 0)
			{
				Factory factory = gameObject.GetComponent<Factory>();
				DechetGenerator dG = gameObject.GetComponent<DechetGenerator>();

				for (int i = 0; i < health.nbrHealth / 3; i++)
                {
					GameObject virus = Object.Instantiate<GameObject>(factory.prefab);
					GameObjectManager.bind(virus);
					virus.transform.position = gameObject.transform.position;
				}

				if(gameObject.GetComponent<DechetGenerator>() != null)
                {
					for (int i = 0; i < (health.nbrHealth / 3) + (health.nbrHealth / 3); i++)
					{
						GameObject dg = Object.Instantiate<GameObject>(dG.prefab);
						GameObjectManager.bind(dg);
						dg.transform.position = gameObject.transform.position;
					}
				}
				GameObjectManager.unbind(gameObject);

				Object.Destroy(gameObject);
			}
		}


	}
}