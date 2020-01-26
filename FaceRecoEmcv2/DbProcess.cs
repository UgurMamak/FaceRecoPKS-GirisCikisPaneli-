#region LIB
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
#endregion 
namespace FaceRecoEmcv2
{
    class DbProcess
    {
        public const string Baglanti = "Data Source=.;Initial Catalog=DbPKS; Integrated Security=True;";
        SqlCommand cmd;
        SqlDataReader reader;

        #region Sql bağlantı işlemleri
        public SqlCommand CreateCommand()//sql ile bağlantıyı sağlayan fonksiyon
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Baglanti;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            return command;
        }
        // Prosedüre bağlanma işlemi hep tekrarlandığı için connection fonksiyonu yazarak çağırma işlemini gerçekleştirdik.
        public void Connection(string prc)//prosedüre bağlanma işlemi
        {
            cmd = CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = prc;
            if (cmd.Connection.State == ConnectionState.Closed) cmd.Connection.Open();
        }
        #endregion

        #region personelleri listeler
        public SqlDataReader prcPersonelList()
        {
            Connection("prcPersoneList");
            reader = cmd.ExecuteReader();
            return reader;
        }
        #endregion

        public SqlDataReader prcIslemler(string isim,DateTime tarih,string saat,int persId)
        {
            //0 giriş yaptı. 1 çıkış yaptı
            Connection("prcIslemYap");
            cmd.Parameters.AddWithValue("@adsoyad", isim);
            cmd.Parameters.AddWithValue("@tarih", tarih);
            cmd.Parameters.AddWithValue("@saat", saat);
            cmd.Parameters.AddWithValue("@persId", persId);
            reader = cmd.ExecuteReader();
            return reader;
        }


    }
}
