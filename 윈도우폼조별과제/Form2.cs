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
    public partial class Form2 : Form
    {
        private Form1 _Form1;
        public Form2(Form1 form1)
        {
            _Form1 = form1; //form1과 연결부분
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void 새로만들기ToolStripMenuItem_Click(object sender, EventArgs e)//새로만들기 클릭이벤트
        {
            textBox1.Text = ""; //텍스트박스안의 문자가 사라짐(빈문자열("")을 넣었기때문에)
        }

        string filename = ""; //열기와 저장 코드블록 밖에 배치하여 두곳에서 모두 접근가능하게함.
        
        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)//열기 클릭이벤트 
        {
            //1. 사용자에게 열 파일을 선택하게함
            openFileDialog1.ShowDialog();//openfiledialog를 화면에 표시
            this.openFileDialog1.Filter = "텍스트 문서(*.txt)|*.txt|모든파일|*.*";

            //1-1 선택한 파일명을 변수에 저장
            filename = openFileDialog1.FileName;


            //2. 파일의 내용을 읽는다.
            string Data=System.IO.File.ReadAllText(openFileDialog1.FileName); //오른쪽의 있는 양을 Data에 기록
            //3. 화면에 표시한다.
            textBox1.Text =Data;//위에서 기록한 Data를 텍스트박스에 출력

        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)//저장 클릭이벤트
        {
            //파일명이 입력되어 있으면
            if(filename !="")
            {
                //해당 파일명으로 현재 내용을 저장 선택하게함
                System.IO.File.WriteAllText(filename,textBox1.Text);
            }

            //그렇지 않으면 다른이름으로 저장과 동일하게 작동.
            else
            {
                saveFileDialog1.ShowDialog();//showdialog를 화면에 표시
                this.saveFileDialog1.Filter = "텍스트 문서(*.txt)|*.txt|모든파일(*.*)|*.*";
                try
                {
                    System.IO.File.WriteAllText(saveFileDialog1.FileName, textBox1.Text); //(파일명,쓸내용,그안의 문자열)순서
                    filename = saveFileDialog1.FileName;//파일을 다른이름으로 저장후 그 파일을 계속작업할때 이전의 파일이름을 불러와서 이름을 다시 적을필요x
                }
                 catch ( Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                }
        }

        private void 다른이름으로저장ToolStripMenuItem_Click(object sender, EventArgs e)//다른이름으로 저장 클릭이벤트
        {
            //1. 사용자에게 저장할 파일을 선택하게함
            this.saveFileDialog1.Filter = "텍스트 문서(*.txt)|*.txt|모든파일(*.*)|*.*";
            saveFileDialog1.ShowDialog();//showdialog를 화면에 표시
            //2. 파일을 저장한다
            System.IO.File.WriteAllText(saveFileDialog1.FileName, textBox1.Text); //(파일명,쓸내용,그안의 문자열)순서
        }

        private void 끝내기ToolStripMenuItem_Click(object sender, EventArgs e)//끝내기 클릭이벤트
        {
            //프로그램 종료하기=창닫기
            Close();
        }

        private void 자동줄바꿈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.WordWrap = !textBox1.WordWrap;//현재값의 워드랩을 반대로하여 자기자신값에 쓰기

          //if( textBox1.WordWrap==true)
          //  {
          //      textBox1.WordWrap = false;
          //  }
          //  else
          //  {
          //      textBox1.WordWrap = true;
          //  }
        }

        private void 글꼴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fontDialog1.ShowDialog(); //폰트다이얼로그속성 가져오기
            textBox1.Font = fontDialog1.Font; //가져온 폰트다이얼로그는 텍스트박스1에 적용됨 (글꼴이 바뀌면 텍스트박스에서 변화한글꼴이 나타남)
        }

        private void 상태표시줄ToolStripMenuItem_Click(object sender, EventArgs e)//statussrip보여주기 여부 선택
        {

            statusStrip1.Visible= !statusStrip1.Visible; //상태표시줄 보이는기준은 Visible속성을 통해 조절가능하므로 상태표시줄 클릭시 Visible속성이 반대가 되도록설정
        }

        private void 메모장정보ToolStripMenuItem_Click(object sender, EventArgs e)//메모장정보(form3) 불러오기
        {
            Form3 _Form= new Form3();
            _Form.ShowDialog();
        }

     
    }
}
