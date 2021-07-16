using System;
using System.Data.Odbc;

public class Program {
    public static void Main(string[] args)
    {

        OdbcConnection myCon = CreateConnection();

        // MySQL �̏���

        // SQL
        string myQuery = "SELECT �Ј��}�X�^.*,DATE_FORMAT(���N����,'%Y-%m-%d') as �a���� from �Ј��}�X�^";

        // SQL���s�p�̃I�u�W�F�N�g���쐬
        OdbcCommand myCommand = new OdbcCommand();

        // ���s�p�I�u�W�F�N�g�ɕK�v�ȏ���^����
        myCommand.CommandText = myQuery;    // SQL
        myCommand.Connection = myCon;       // �ڑ�

        // ���ł���A�f�[�^�x�[�X�̒l�����炤�ׂ̃I�u�W�F�N�g�̕ϐ��̒�`
        OdbcDataReader myReader;

        // SELECT �����s�������ʂ��擾
        myReader = myCommand.ExecuteReader();

        // myReader ����f�[�^���ǂ݂������Ԃ����ƃ��[�v
        while (myReader.Read())
        {
            string text = myReader.GetValue(myReader.GetOrdinal("����")).ToString();
            Console.WriteLine(text);
            
            //Debug.WriteLine($"Debug:{text}");
        }

        myReader.Close();

        myCon.Close();
    }

    static OdbcConnection CreateConnection()
    {
        // �ڑ�������̍쐬
        OdbcConnectionStringBuilder builder = new OdbcConnectionStringBuilder();
        builder.Driver = "MySQL ODBC 8.0 Unicode Driver";
        // �ڑ��p�̃p�����[�^��ǉ�
        builder.Add("server", "localhost");
        builder.Add("database", "lightbox");
        builder.Add("uid", "root");
        builder.Add("pwd", "");

        string work = builder.ConnectionString;

        Console.WriteLine(builder.ConnectionString);

        // �ڑ��̍쐬
        OdbcConnection myCon = new OdbcConnection();

        // MySQL �̐ڑ���������
        myCon.ConnectionString = builder.ConnectionString;

        // MySQL �ɐڑ�
        myCon.Open();


        return myCon;
    }
}
