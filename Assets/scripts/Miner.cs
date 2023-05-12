using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour
{

    //Miner��Prefab������
    public GameObject miner;

    //MazeGenerator����������󂯎����s
    public void DoMining(int verNum, int horNum)
    {
        //�R���[�`���Ɉ����𑗂��Ď��s������
        //MazeGnerator������s�����邱�Ƃ��ł��邪�d���Ȃ�
        StartCoroutine(Mining(verNum, horNum));
    }

    //DoMining�֐����������2�󂯎��
    IEnumerator Mining(int ver, int hor)
    {
        //��x�ɑS�Ă�Miner�𓮂����ƃG���[�o��̂Ń����_���Ŏ��ԍ�����
        float random1 = Random.Range(0.1f, 3f);
        yield return new WaitForSeconds(random1);

        //�O�ɏ�����2��̃I�u�W�F�N�g���~��������2�𑫂�
        int verUp = ver + 2;

        //2��̂�����
        GameObject upObj = GameObject.Find(verUp + "-" + hor);
        //1��̂�����
        GameObject upObj2 = GameObject.Find(verUp - 1 + "-" + hor);

        //2��̃I�u�W�F�N�g�����邩�ǂ�������
        if (upObj != null)
        {
            //2��̂�1��̂�����
            Destroy(upObj);
            Destroy(upObj2);

            //�V����Miner�𐶐�
            GameObject minerObj = Instantiate(miner, Vector3.zero, Quaternion.identity);
            //�V����Miner�̃X�N���v�g���擾
            Miner minerScr = minerObj.GetComponent<Miner>();
            //2��̃I�u�W�F�N�g�̏c���Ɖ����̔ԍ��𑗂�
            minerScr.DoMining(verUp, hor);
        }

        float random2 = Random.Range(0.1f, 3f);
        yield return new WaitForSeconds(random2);

        //�������牺�̃I�u�W�F�N�g�̔���Ə���
        int verDown = ver - 2;

        GameObject downObj = GameObject.Find(verDown + "-" + hor);
        GameObject downObj2 = GameObject.Find(verDown + 1 + "-" + hor);

        if (downObj != null)
        {
            Destroy(downObj);
            Destroy(downObj2);

            GameObject minerObj = Instantiate(miner, Vector3.zero, Quaternion.identity);
            Miner minerScr = minerObj.GetComponent<Miner>();
            minerScr.DoMining(verDown, hor);
        }

        float random3 = Random.Range(0.1f, 3f);
        yield return new WaitForSeconds(random3);

        //��������E�̃I�u�W�F�N�g�̔���Ə���
        int horRight = hor + 2;

        GameObject rightObj = GameObject.Find(ver + "-" + horRight);
        GameObject rightObj2 = GameObject.Find(ver + "-" + (horRight - 1));

        if (rightObj != null)
        {
            Destroy(rightObj);
            Destroy(rightObj2);

            GameObject minerObj = Instantiate(miner, Vector3.zero, Quaternion.identity);
            Miner minerScr = minerObj.GetComponent<Miner>();
            minerScr.DoMining(ver, horRight);
        }

        float random4 = Random.Range(0.1f, 3f);
        yield return new WaitForSeconds(random4);

        //�������獶�̃I�u�W�F�N�g�̔���Ə���
        int horLeft = hor - 2;

        GameObject leftObj = GameObject.Find(ver + "-" + horLeft);
        GameObject leftObj2 = GameObject.Find(ver + "-" + (horLeft + 1));

        if (leftObj != null)
        {
            Destroy(leftObj);
            Destroy(leftObj2);

            GameObject minerObj = Instantiate(miner, Vector3.zero, Quaternion.identity);
            Miner minerScr = minerObj.GetComponent<Miner>();
            minerScr.DoMining(ver, horLeft);
        }
        //���̃I�u�W�F�N�g������
        Destroy(gameObject);
    }
}