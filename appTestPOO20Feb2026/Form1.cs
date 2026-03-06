using System.Xml.Serialization;

namespace appTestPOO20Feb2026
{
  public partial class Form1 : Form
  {
    private System.Windows.Forms.Timer timer;
    private PictureBox pictureBox1;
    private PictureBox pictureBox2;
    private int speed = 2;
    private bool isOverlapping = false;

    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      pictureBox1 = new PictureBox();
      pictureBox1.Image = Image.FromFile("pic.png");
      pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      pictureBox1.Size = new Size(200, 200);
      int formWidth = this.ClientSize.Width;
      int formHeight = this.ClientSize.Height;
      Point centerPoint = new Point((formWidth - pictureBox1.Width) / 2, (formHeight - pictureBox1.Height) / 2);
      pictureBox1.Location = centerPoint;
      this.Controls.Add(pictureBox1);

      pictureBox2 = new PictureBox();
      pictureBox2.Image = Image.FromFile("drogas.png");
      pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
      pictureBox2.Size = new Size(150, 150);
      pictureBox2.Location = centerPoint;
      pictureBox2.BringToFront();
      this.Controls.Add(pictureBox2);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      //Start a timer to move the picture box
      timer = new System.Windows.Forms.Timer();
            timer.Interval = 5; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Start();
    }
    private void Timer_Tick(object sender, EventArgs e)
    {
      if (pictureBox1 != null)
      {
        pictureBox1.Left += speed;
        if (pictureBox1.Left > this.ClientSize.Width)
        {
          pictureBox1.Left = -pictureBox1.Width;
        }

        if (pictureBox2 != null)
        {
          bool intersect = pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds);
          if (intersect && !isOverlapping)
          {
            speed = Math.Min(speed + 2, 50);
            isOverlapping = true;
          }
          else if (!intersect)
          {
            isOverlapping = false;
          }
        }
      }
    }
  }
}
