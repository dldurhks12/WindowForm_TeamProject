using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 윈도우폼조별과제
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string filename = ""; //열기와 저장 코드블록 밖에 배치하여 두곳에서 모두 접근가능하게함.
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//메모장
        {
            Form2 _Form2 = new Form2(this); 
            _Form2.ShowDialog(); //form2로 넘어감
        }

        private void button2_Click(object sender, EventArgs e)//그림판
        {

        }

        private void button5_Click(object sender, EventArgs e)//메모 바로저장
        {
            this.saveFileDialog1.Filter = "텍스트 문서(*.txt)|*.txt|모든파일|*.*";
            saveFileDialog1.ShowDialog();//showdialog를 화면에 표시
            //2. 파일을 저장한다
            System.IO.File.WriteAllText(saveFileDialog1.FileName, textBox1.Text); //(파일명,쓸내용,그안의 문자열)순서
        }

        private void button3_Click(object sender, EventArgs e)//TXT파일 불러오기
        {
            openFileDialog1.ShowDialog();//openfiledialog를 화면에 표시
            this.openFileDialog1.Filter = "텍스트 문서(*.txt)|*.txt|모든파일|*.*";

            //1-1 선택한 파일명을 변수에 저장
            filename = openFileDialog1.FileName;


            //2. 파일의 내용을 읽는다.
            string Data = System.IO.File.ReadAllText(openFileDialog1.FileName); //오른쪽의 있는 양을 Data에 기록
            //3. 화면에 표시한다.
            textBox1.Text = Data;//위에서 기록한 Data를 텍스트박스에 출력
        }

        private void button4_Click(object sender, EventArgs e)//그림판 파일 불러오기
        {

        }
    }
}
