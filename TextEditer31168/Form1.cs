using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditer31168
{
    public partial class Form1 : Form
    {
        string a;
        public Form1()
        {
            InitializeComponent();
            this.Text = "新規作成";
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ファイルToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 開くOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdFileOpen.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(ofdFileOpen.FileName, Encoding.GetEncoding("utf-8"), false))
                {
                    rtTextArea.Text = sr.ReadToEnd();
                }
            }
            
        }

        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 名前を付けて保存AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(sfdFileSave.ShowDialog() == DialogResult.OK)
            {
                using(StreamWriter sw = new StreamWriter(Text ,false, Encoding.GetEncoding("utf-8")))
                {
                    sw.WriteLine(rtTextArea.Text);
                    a = sfdFileSave.FileName;
                }
            }
        }

        private void 上書き保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(a))
            {
                using (StreamWriter sw = new StreamWriter(a, false, Encoding.GetEncoding("utf-8")))
                {
                    sw.WriteLine(rtTextArea.Text);
                }
            }
            else
            {
                MessageBox.Show("ふぁっく");
            }

            
        }

        private void コピーCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtTextArea.SelectionLength > 0)
            {
             
                rtTextArea.Copy();
            }
        }

        private void 貼り付けPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataObject data = Clipboard.GetDataObject();
            if (data != null && data.GetDataPresent(DataFormats.Text) == true)
            {
               
                rtTextArea.Paste();
            }
        }

        private void 切り取りTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtTextArea.SelectionLength > 0)
            {
               
                rtTextArea.Cut();
            }
        }

        private void 削除DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtTextArea.SelectionLength > 0)
            {

                rtTextArea.Clear();
            }
        }

        private void 元に戻すUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtTextArea.CanUndo)
            {
                //アンドゥする
                rtTextArea.Undo();
                //アンドゥバッファを削除する
                rtTextArea.ClearUndo();
            }
            
        }

        private void やり直しRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtTextArea.CanRedo)
            {
                rtTextArea.Redo();
                
            }
        }

        private void 色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                rtTextArea.ForeColor = colorDialog1.Color;
            }
        }

        private void 新規作成NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtTextArea.Clear();
            this.Text = "新規作成";
            
        }

        private void フォントToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                rtTextArea.Font = fontDialog1.Font;
                rtTextArea.ForeColor = fontDialog1.Color;
            }
        }
    }
}
