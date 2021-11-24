using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut : FoxState
{
    private float cutTime;
    public Cut(StateController stateController) : base(stateController) { }
    public override void enter()
    {
        base.enter();
        //��ʼ��״̬����ʱ��
        cutTime = m_fox.cutTime;
        //���Ĵ�����һ
        m_fox.cutCount--;
        if(m_fox.cutCount==1)
        {
            Debug.Log("���ŵ�һ������");
        }
        if(m_fox.cutCount==0)
        {
            Debug.Log("���ŵڶ�������");
        }
        //����������Χ
        m_stateController.GetComponentInChildren<CircleCollider2D>().enabled = true;
    }
    public override void update()
    {
        cutTime -= Time.fixedDeltaTime;
        if(m_fox.cutPressed&&m_fox.cutCount>0)
        {
            m_fox.cutPressed = false;
            //�������״̬
            m_stateController.ChangeState("Cut");
        }
        //���������
        if(cutTime<0)
        {
            //����ǵڶ���ն����
            if (m_fox.cutCount == 0)
            {
                //����Ӳֱ
                m_stateController.ChangeState("Stiff");
            }
            //����idle״̬
            else
              m_stateController.ChangeState("Idle");
        }
    }
    public override void exit()
    {
        m_stateController.GetComponentInChildren<CircleCollider2D>().enabled = false;
    }
    public override void onTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Enemies")
        {
            Debug.Log("��");
            collision.GetComponent<Oppssum>().Red -= 1;
            //��������
            //collision.GetComponent<Rigidbody2D>().velocity = new Vector2(m_transform.localScale.x * 5, 5);
        }
    }
}