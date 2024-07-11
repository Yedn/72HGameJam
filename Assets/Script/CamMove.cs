using Unity.VisualScripting;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public float edgeSize;	//������ƶ�Ч���ı�Ե���
    public float moveAmount;    //�ƶ��ٶ�
    public Vector2 MinPos;
    public Vector2 MaxPos;
    public Camera myCamera;	//���ƶ��������

    private Vector3 camFollowPos;	//���ڸ��������ֵ

    private bool edgeScrolling = true;	//�ƶ�����
    // Start is called before the first frame update
    void Start()
    {
        camFollowPos = myCamera.transform.position;	//�����������ʼλ�ã��ƶ����ڳ�ʼλ�õĻ����ϼ���
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))	//�ƶ�����
        {
            edgeScrolling = !edgeScrolling;
        }
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            camFollowPos.x = camFollowPos.y = 0;
        }
        else if (edgeScrolling)	//�����
        {
            //��Ļ���½�Ϊ����(0, 0)
            if (Input.mousePosition.x > Screen.width - edgeSize)//������λ�����Ҳ�
            {
                camFollowPos.x += moveAmount * Time.deltaTime;//�������ƶ�
            }
            if (Input.mousePosition.x < edgeSize)
            {
                camFollowPos.x -= moveAmount * Time.deltaTime;
            }
            if (Input.mousePosition.y > Screen.height - edgeSize)
            {
                camFollowPos.y += moveAmount * Time.deltaTime;
            }
            if (Input.mousePosition.y < edgeSize)
            {
                camFollowPos.y -= moveAmount * Time.deltaTime;
            }

            camFollowPos.x = Mathf.Min(camFollowPos.x, MaxPos.x);
            camFollowPos.x = Mathf.Max(camFollowPos.x, MinPos.x);
            camFollowPos.y = Mathf.Min(camFollowPos.y, MaxPos.y);
            camFollowPos.y = Mathf.Max(camFollowPos.y, MinPos.y);
            myCamera.transform.position = camFollowPos;//ˢ�������λ��
        }
    }

    public void ResetPos()
    {
        Debug.Log("CamReset");
        //StartCoroutine(holdon());
        edgeScrolling = false;
        camFollowPos.x = camFollowPos.y = 0;
        Invoke("holdon", 1000f * Time.deltaTime);
        edgeScrolling = true;

    }
    void holdon()
    {

    }

}
