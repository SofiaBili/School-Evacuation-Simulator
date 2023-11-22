using UnityEngine;

public class IsPlayerInPos : MonoBehaviour{
	public bool isEarthquake=true;
	private void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("Player")){
			FireDrillHuman.startEvacFlag=true;
			if(isEarthquake) EarthquakeClassScript.LeaveRoomInfo();
			else FireClassScript.LeaveRoomInfo();
			Destroy(gameObject);
		}
    }
}