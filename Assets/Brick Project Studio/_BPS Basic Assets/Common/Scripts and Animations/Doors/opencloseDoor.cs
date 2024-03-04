using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace SojaExiles

{
	public class opencloseDoor : ObjectController
	{

		public Animator openandclose;
		public bool open;
		public Transform Player;

		private float gazeTimer = 0;
		public float GazeTime = 2;
		private bool gazeStatus;


        public void Update()
        {
            if (gazeStatus)
			{
				gazeTimer += Time.deltaTime;
            }

			if(gazeTimer >= GazeTime)
			{
                float dist = Vector3.Distance(Player.position, transform.position);
				if(dist < 15)
				{
					if(open == false)
					{
						StartCoroutine(opening());
					}
					else if(open == true)
					{
						StartCoroutine(closing());
					}
				}
            }
        }

        public new void OnPointerEnter()
		{
			gazeStatus = true;
		}

		public new void OnPointerExit()
		{
			gazeStatus = false;
			gazeTimer = 0;
		}

        void OnMouseOver()
		{
			{
				if (Player)
				{
					float dist = Vector3.Distance(Player.position, transform.position);
					if (dist < 15)
					{
						if (open == false)
						{
							if (Input.GetMouseButtonDown(0))
							{
								StartCoroutine(opening());
							}
						}
						else
						{
							if (open == true)
							{
								if (Input.GetMouseButtonDown(0))
								{
									StartCoroutine(closing());
								}
							}

						}

					}
				}

			}

		}

		IEnumerator opening()
		{
			print("you are opening the door");
			openandclose.Play("Opening");
			open = true;
			gazeTimer = 0;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			openandclose.Play("Closing");
			open = false;
			gazeTimer = 0;
			yield return new WaitForSeconds(.5f);
		}


	}
}