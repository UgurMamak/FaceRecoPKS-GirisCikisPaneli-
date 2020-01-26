#region LIB
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV.UI;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
using System.Threading;
using System.Security.Principal;
using Microsoft.Win32.SafeHandles;

using MaterialSkin.Controls;
using MaterialSkin;
using MetroFramework.Controls;
using MetroFramework;

using System.Data.Sql;
using System.Data.SqlClient;

#endregion
namespace FaceRecoEmcv2
{
    public partial class FrmFaceRecognition : MaterialForm
    {
        public FrmFaceRecognition()
        {
            #region Material tasatım kodları
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.Green900, Primary.Green500, Accent.Green100, TextShade.WHITE);
            #endregion

            #region Eğitim dosyasını kontrol eder.           
            if (CsTrain.DizinKontrol) { message_bar.Text = "Eğitim verileri yüklendi."; }
            else { message_bar.Text = "Eğitim verisi bulunamadı. İlk önce yüz eğitimi gerçekleştirin."; }

            CameraCapture();//Kamerayı çalıştıran fonksiyonu çağırdık.(**)
            lblTanimaTur.Text = "LBPH";//varsayılan olrak tanıma türünü eigenfaces verdim.(**)
            #endregion
        }

        #region değişkenler ve tanımlamalar
        Image<Bgr, Byte> currentFrame; //webcamden alınan kamera görüntüsünü tutması için bgr renk uzayından image tipinde değişken tanımladık.
        Image<Gray, byte> result = null; //algılanan yüzü ve eğitme için kullanılacak olan yüzü tutmak için gri fortta Image değişkenleri oluşturduk.
        Image<Gray, byte> grayframe = null; //kameradan alınan anlık görüntüleri gri formata dönüştürünce atayacağımız Image değişkeni
        Capture _capture; //Kameradan görüntü yakalam işlemi(**)

        //Yüz tespiti yapan metoddur. Bu metot yüz bulma işlemini haarcascade sınıflandırıcısını kullanarak gerçekleştirir.(**)  
        public CascadeClassifier FaceCascade = new CascadeClassifier(Application.StartupPath + "/Cascades/haarcascade_frontalface_default.xml");
     
        // Yüz bulma ve tanıma video kameradan yapılıyorsa, bulunan kişi bilgileri hemen yüz bölgesinin altına yazılmaktadır. bu tanımlama kullanılan yazıyı tanımlamakta(**)
         MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 0.5, 0.5);
        
        //Classifier_Train'deki class'ta bulunan metotları kullanabilmek için nesne oluşturdum.(**)
        ClassTrain CsTrain = new ClassTrain();

        DbProcess prc = new DbProcess();
        int sayac = 0;
        string KisiAdSoyad;
        SqlDataReader reader,reader2;

        #endregion


        #region Kamera başlatma Fonksiyonu
        public void CameraCapture()
        {
            _capture = new Capture(0);
            _capture.QueryFrame();
            //Idle uygulamanın atıl moda geçmesini temsil eder.(**)
            //Uygulamada klavye mouse hareketi olmadığı için arka tarafta iş yok gözükür ve uygulama atıl moda geçer.(**)
            //herhangi bir kontrol tarafından değil doğrudan windows tarafından tetiklenir.(**)
             Application.Idle += new EventHandler(GoruntuYakala_Parrellel);           
        }
        #endregion

        #region görüntü alma işlemini sonlandırır.
        private void StopCapture()
        {
             Application.Idle -= new EventHandler(GoruntuYakala_Parrellel);      
            if (_capture != null) { _capture.Dispose(); }
        }
        #endregion



        #region Yüz tanıma işleminii yapar.      
        void GoruntuYakala_Parrellel(object sender, EventArgs e)
        {
            //kameradan alınan anlık görüntü yeniden boyutlandırılır.(**)
            currentFrame = _capture.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            //eğer görüntü alındıysa if yapısının içine girer.(**)
            if (currentFrame != null)
            {
                //Daha hızlı işlem yapabilmek için kameradan alınan anlık görüntü griye dönüştürülür.(**)
                grayframe = currentFrame.Convert<Gray, Byte>();
                //Verilen görüntüde dikdörtgen bölgeleri bulur ve bir dizi olarak bu bölgeleri saklar. Görüntüdeki yüz bölgesinin koordinatlarını hesaplar.               
                Rectangle[] facesDetected = FaceCascade.DetectMultiScale(grayframe, 1.2, 10, new Size(50, 50), Size.Empty);
                //Algılanan görüntünün çerçeveye alınacak bölgesi belirlenir.(**)
                //Paralel.For normal for döngüsünden daha hızlı çalışır.(**)
                Parallel.For(0, facesDetected.Length, i =>
                {
                    try
                    {
                        facesDetected[i].X += (int)(facesDetected[i].Height * 0.15);
                        facesDetected[i].Y += (int)(facesDetected[i].Width * 0.22);
                        facesDetected[i].Height -= (int)(facesDetected[i].Height * 0.3);
                        facesDetected[i].Width -= (int)(facesDetected[i].Width * 0.35);                     
                        //anlık görüntüden algılanan yüz resmini griye dönüştürür ve kopyasını alır.(**) 
                        result = currentFrame.Copy(facesDetected[i]).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                        result._EqualizeHist();//Histogram eşitleme(**)
                        //algılanan yüzü çerçeveye alarak çizer.(**)
                        currentFrame.Draw(facesDetected[i], new Bgr(Color.Red), 2);

                        //cstrain classındaki dizinkontrol metodunun değerine bakar eğer eğitim verisi yüklüyse true değerini alır ve if içine girer(**)
                        if (CsTrain.DizinKontrol)
                        {
                            //Griye dönüştürülüp yeniden boyutlandırılan ve histogram eşitlemesi yapılmış anlık yüz görüntüsü(**)
                            //class'taki tanıma metoduna gönderilir ve sonuç bilgisi alınır.(**)
                             KisiAdSoyad = CsTrain.Recognition(result);
                            int FaceValue = (int)CsTrain.GetYuzDistance;//yüzün sayısal değeri döndürülür.(**)
                            //Anlık görüntüden tanınan yüz çerçeveye alınır ve kim olduğu yazılır(**)
                            currentFrame.Draw(KisiAdSoyad + " ", ref font, new Point(facesDetected[i].X - 2, facesDetected[i].Y - 2), new Bgr(Color.LightGreen));
                            lblKisi.Text = KisiAdSoyad;
                            if (KisiAdSoyad == "TANINMADI") panel2.BackColor = Color.Red;
                            else
                            {                               
                                panel2.BackColor = Color.Green;
                                sayac++;
                                if(sayac==25)
                                {
                                     //StopCapture();
                                    fnkIslemYap();
                                    sayac = 0;
                                }
                            }  
                        }
                    }
                    catch{}
                });
                //Algılanan ve tanınan  yüzü göster.(**)
                imgKamera.Image = currentFrame.ToBitmap();
            }
        }
        #endregion

        void fnkIslemYap()
        {
            reader = prc.prcPersonelList();
            while(reader.Read())
            {
                string isim = (reader[1].ToString() + "_" + reader[2].ToString()).ToLower();//vtdeki personel ismini çeker.
                if(KisiAdSoyad.ToLower()==isim)
                {
                    reader2 = prc.prcIslemler(isim,DateTime.Now, DateTime.Now.ToLongTimeString(),Convert.ToInt32(reader[0].ToString()));
                    while (reader2.Read())
                    {
                        KisiAdSoyad = "TANINMADI";
                        if (reader2[0].ToString() == "0") { lblMesaj.Text = "Giriş yapıldı";/* CameraCapture();*/ }
                        else if(reader2[0].ToString()=="1") { lblMesaj.Text = "Çıkış yapıldı.";/*CameraCapture();*/ }
                        break;
                    }
                    break;                    
                }
            }
            
        }


        #region Eigenface alg
        private void BtnEigenface_Click(object sender, EventArgs e)
        {
            CsTrain.TanimaTuru = "EMGU.CV.EigenFaceRecognizer";//Cstrain nesnesi ile tanima turunu bilmesi için tanimaturunu gönderdik.(**)
            CsTrain.Retrain();//Tanıma yöntemini değiştirince eğitim verisini yeniden yüklemekye yarayacak metot(**)
            lblTanimaTur.Text = "Eigenface";
        }
        #endregion

        #region fisherface
        private void BtnFisherface_Click(object sender, EventArgs e)
        {
            CsTrain.TanimaTuru = "EMGU.CV.FisherFaceRecognizer";//Cstrain nesnesi ile tanima turunu bilmesi için tanimaturunu gönderdik.(**)
            CsTrain.Retrain();//Tanıma yöntemini değiştirince eğitim verisini yeniden yüklemekye yarayacak metot(**)
            lblTanimaTur.Text = "Fisherface";
        }
        #endregion

        #region LBPH
        private void BtnLBPH_Click(object sender, EventArgs e)
        {
            CsTrain.TanimaTuru = "EMGU.CV.LBPHFaceRecognizer";//Cstrain nesnesi ile tanima turunu bilmesi için tanimaturunu gönderdik.(**)
            CsTrain.Retrain();//Tanıma yöntemini değiştirince eğitim verisini yeniden yüklemekye yarayacak metot(**)
            lblTanimaTur.Text = "LBPH";
        }
        #endregion

       

        //Eigenfaces yönteminde eşik değerini değiştirebilmek için txtboxın changed özelliği ile her değer değiştiğinde aşağıdaki işlem gerçekleşir.(**)
        private void Eigne_threshold_txtbx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CsTrain.SetEigenEsikDeger = Math.Abs(Convert.ToInt32(TxtEigenEsikDegeri.Text));
                message_bar.Text = "Eigen Eşik değeri";
            }
            catch
            {
                message_bar.Text = "eşik değerinde int değerler kullanın";
            }
        }


        /*
        //Eğitme işlemini yeniden yükler.
        public void retrain()
        {
            CsTrain = new ClassTrain();
            if (CsTrain.DizinKontrol) { message_bar.Text = "Eğitim verileri yüklendi."; }
            else { message_bar.Text = "Eğitim verisi bulunamadı, ilk önce eğitim işlemini gerçekleştirin. "; }
        }*/

 

 


       


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            CsTrain.Retrain();
        }

        private void FrmFaceRecognition_Load(object sender, EventArgs e)
        {

        }



        /*
        private void CikisMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();//bellekte program ile ilgili tutulan herşeyi siler. temizler(**)
        }
         */

    }
}
