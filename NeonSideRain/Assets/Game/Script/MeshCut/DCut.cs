using UnityEngine;
using System.Collections;

public class DCut : MonoBehaviour {

    //Meshcut을 사용하여 잘린 단면에 적용할 Material
	public Material capMaterial;
    //슬래시 이펙트
	public GameObject Slash;

    //Raycast가 인식할 거리값
	public float maxDistance;

	void Update(){

			RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.D)) //D키를 입력 시
        {
            //Raycast를 사용하여 해당 위치에서 정면으로 해당 거리만큼(maxDistance) 인식
			if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
			{
                //Raycast를 통해 인식한 게임오브젝트의 콜라이더를 대입
				GameObject victim = hit.collider.gameObject;
            //받아온 Meshcut 스크립트를 사용하여 해당 오브젝트를 인식한 부분을 잘라 2개로 만들고 잘린 단면에 capMaterial를 적용
				GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

                //만약 잘려서 생성된 오브젝트에 Rigidbody가 없으면 Rigidbody 생성
				if (!pieces[1].GetComponent<Rigidbody>())
					pieces[1].AddComponent<Rigidbody>();
                //생성된 오브젝트에 Rigidbody 불러오기
				Rigidbody RigR = pieces[1].GetComponent<Rigidbody>();
                //중력값을 끄고 해당 위치만큼 이동
				RigR.useGravity = false;
				RigR.AddForce(Vector3.right * 50.0f);
				RigR.AddForce(Vector3.down * 100.0f);
                //일정시간 뒤에 오브젝트 제거
				Destroy(pieces[1], 1);
                //슬래시 이펙트 생성
				GameObject S = Instantiate(Slash);
				S.transform.position = transform.position;
				S.transform.rotation = transform.rotation;
			}
}

	}

	void OnDrawGizmosSelected() {

		Gizmos.color = Color.green;

		Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5.0f);
		Gizmos.DrawLine(transform.position + transform.up * 0.5f, transform.position + transform.up * 0.5f + transform.forward * 5.0f);
		Gizmos.DrawLine(transform.position + -transform.up * 0.5f, transform.position + -transform.up * 0.5f + transform.forward * 5.0f);

		Gizmos.DrawLine(transform.position, transform.position + transform.up * 0.5f);
		Gizmos.DrawLine(transform.position,  transform.position + -transform.up * 0.5f);

	}

}
