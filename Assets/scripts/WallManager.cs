using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{

    //�ォ�猩�ďc�AZ���̃I�u�W�F�N�g�̗�
    public int vertical = 15;
    //�ォ�猩�ĉ��AX���̃I�u�W�F�N�g�̗�
    public int horizontal = 15;

    //Prefab�����闓�����
    public GameObject cube;

    public static Vector3 playerstart;
    //for���ŃI�u�W�F�N�g���c���ɕ��ׂ邽�߂̕ϐ�
    int vi;
    int hi;

    //Miner��Prefab�����邽�߂̕ϐ�
    public GameObject miner;

    //start�̍��W

    void Start()
    {
        //Cube����ׂ邽�߂̊�ɂȂ�ʒu
        Vector3 pos = new Vector3(0, 0, 0);

        //Z����vertical�̐��������ׂ�
        for (vi = 0; vi < vertical; vi++)
        {
            //X����horizontal�̐��������ׂ�
            for (hi = 0; hi < horizontal; hi++)
            {
                //Prefab��Cube�𐶐�����
                GameObject copy = Instantiate(cube,
                    //�����������̂�z�u����ʒu
                    new Vector3(
                        //X��
                        pos.x + hi,
                        //Y��
                        pos.y,
                        //Z��
                        pos.z + vi
                    //Quaternion.identity�͖���]���w�肷��
                    ), Quaternion.identity);

                //���������I�u�W�F�N�g�ɔԍ��̖��O������
                copy.name = vi + "-" + hi.ToString();
            }
        }

        //�����_���Ȑ������c������2�o��
        //0���炾���A���ԃI�u�W�F�N�g�̓�������I�т����̂�1����ɂ���
        int ver1 = Random.Range(1, vertical - 1);
        int hor1 = Random.Range(1, horizontal - 1);

        //�����_���Ȑ�������I�u�W�F�N�g����������Destroy�ŏ���
        GameObject start = GameObject.Find(ver1 + "-" + hor1);
        playerstart  =start.transform.position;
        Destroy(start);
        


        //���̈ʒu���R���\�[���ɕ\��
        Debug.Log(start);

        //Miner�𐶐�
        GameObject minerObj = Instantiate(miner, Vector3.zero, Quaternion.identity);
        //Miner�I�u�W�F�N�g��Miner�X�N���v�g���擾
        Miner minerScr = minerObj.GetComponent<Miner>();
        //Miner�X�N���v�g��Mining�֐��Ɉ����𑗂��Ď��s������
        minerScr.DoMining(ver1, hor1);
    }
    public static Vector3 startpositon()
    {
        return playerstart;
    }
}