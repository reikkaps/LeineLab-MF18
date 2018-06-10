using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace FaceDetection
{
    public partial class MainForm : Form
    {

        private Capture _capture = null;
        private bool _captureInProgress;
        public MainForm()
        {
            InitializeComponent();
            CvInvoke.UseOpenCL = false;
            try
            {
                _capture = new Capture(0);
                _capture.ImageGrabbed += ProcessFrame;
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }

            Image<Bgr, Byte> test = new Image<Bgr, Byte>("TestDataResources\\lena.jpg");

            captureBox.Image = ApplyDetection(test.Mat);
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            Mat frame = new Mat();
            _capture.Retrieve(frame, 0);

            ApplyDetection(frame);

            captureBox.Image = frame;
        }

        private Mat ApplyDetection(Mat image)
        {
            long detectionTime;
            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();

            //The cuda cascade classifier doesn't seem to be able to load "haarcascade_frontalface_default.xml" file in this release
            //disabling CUDA module for now
            bool tryUseCuda = false;
            bool tryUseOpenCL = true;

            DetectFace.Detect(
              image, "Dlls\\EmguCv\\haarcascade_frontalface_default.xml", "Dlls\\EmguCv\\haarcascade_eye.xml",
              faces, eyes,
              tryUseCuda,
              tryUseOpenCL,
              out detectionTime);

            foreach (Rectangle face in faces)
                CvInvoke.Rectangle(image, face, new Bgr(Color.Red).MCvScalar, 2);
            foreach (Rectangle eye in eyes)
                CvInvoke.Rectangle(image, eye, new Bgr(Color.Blue).MCvScalar, 2);

            return image;
        }

        private void captureButton_Click(object sender, EventArgs e)
        {

            if (_capture != null)
            {
                if (_captureInProgress)
                {  //stop the capture
                    captureButton.Text = "Start";
                    _capture.Pause();
                }
                else
                {
                    //start the capture
                    captureButton.Text = "Stop";
                    _capture.Start();
                }

                _captureInProgress = !_captureInProgress;
            }
        }

        private void ReleaseData(object sender, FormClosingEventArgs e)
        {
            if (_capture != null)
                _capture.Dispose();
        }
    }
}
