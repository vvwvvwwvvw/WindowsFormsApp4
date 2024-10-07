using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MouseClick += delegate { MyAreaClick(); };
        }
        public delegate void ClickEvent(object sender);

        // event 필드
        public event ClickEvent MyClick;
        // 예제를 단순화 하기위해
        // MyArea가 클릭되면 아래 함수가 호출된다고 가정
        void MyAreaClicked()
        {
            if (MyClick != null) 
            {
                MyClick(this);
            }
        }
    }
    class Program
    {
        static MyArea area;

        static void Main(string[] args)
        {
            area = new MyArea();

            // 이벤트 가입
            area.MyClick += Area_Click;
            area.MyClick += AfterClick;

            // 이벤트 탈퇴
            area.MyClick -= Area_Click;

            // Error : 이벤트 직접 호출 불가
            // area.MyClick(this);

            area.ShowDialog();
        }
        static void Area_Click(object sender)
        {
            area.Text += "MyArea 클릭!";
        }
        static void AfterClick(object sender)
        {
            area.Text += "AfterClick 클릭!";
        }
    }
}
