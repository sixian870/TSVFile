using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TSVFile
{
    public partial class frmTSVFile : Form
    {
        ///<summary>
        ///關於視窗
        ///</summary>
        frmAbout about =new frmAbout();

        ///<summary>
        ///單字清單
        ///</summary>
        WordCollection _WordList= new WordCollection();

        public frmTSVFile()
        {
            InitializeComponent();
        }

        ///<summary>
        ///更新ListView的內容
        ///</summary>
        private void UpdateListView(string keyword = "")
        {
            lvwWord.BeginUpdate(); //暫停重繪
            lvwWord.Items.Clear();// 清除ListView的所有項目

            // 將WordCollection物件中的資料載入到ListView中
            foreach (WordItem item in _WordList)
            {
                if (item == null) continue;

                // 如果有輸入關鍵字，且單字本身「不包含」這個關鍵字（不區分大小寫），就跳過不顯示
                if (!string.IsNullOrEmpty(keyword) &&
                    item.Word.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    continue;
                }

                // 建立ListViewItem物件
                ListViewItem lvi = new ListViewItem(item.Word);
                lvi.SubItems.Add(item.Phonogram ?? "");
                lvi.SubItems.Add(item.SoundPath ?? "");
                lvi.SubItems.Add(item.Explain ?? "");
                // 將ListViewItem物件加入到ListView中
                lvwWord.Items.Add(lvi);
            }
            // 自動調整所有欄位寬度以符合內容長度
            if (lvwWord.Items.Count > 0)
            {
                lvwWord.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            else
            {
                lvwWord.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }

            lvwWord.EndUpdate(); //重繪;
            // 即時更新狀態列顯示目前搜尋到的數量
            tsslMessage.Text = string.IsNullOrEmpty(keyword) ?
                $"成功載入 {_WordList.Count} 個單字" :
                $"找到 {lvwWord.Items.Count} 筆符合「{keyword}」的結果";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // 把文字方塊目前輸入的內容傳給 UpdateListView 進行過濾
            UpdateListView(txtSearch.Text.Trim());
        }

        private void frmTSVFile_Load(object sender, EventArgs e)
        {
            tsslMessage.Text = "請開啟檔案";
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            about.ShowDialog(this);
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Textfiles (*.txt)|*.txt|TSV files (*.tsv)|*.tsv|Allfiles (*.*)|*.*";
            ofd.Title = "開啟檔案";
            // 設定初始目錄為程式所在目錄
            ofd.InitialDirectory = Application.StartupPath;
            DialogResult dr = ofd.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                // 讀取檔案並且將每一行的資料放入字串陣列
                string[] lines = File.ReadAllLines(ofd.FileName, Encoding.UTF8);
                // 將字串陣列的資料載入到WordCollection物件中
                _WordList.LoadFromStringArray(lines);
                // 將WordCollection物件中的資料載入到ListView中
                UpdateListView();
                this.tsslMessage.Text = $"{_WordList.Count} 單字已成功載入";
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTSVFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("確定要離開嗎?", "離開", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true; // 取消關閉
            }
        }

        // 用來記錄目前是正向排序還是反向排序
        private bool isAscending = true;

        private void lvwWord_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            isAscending = !isAscending; // 切換正反向狀態
            lvwWord.ListViewItemSorter = new ListViewItemComparer(e.Column, isAscending); // 設定 ListView 的排序器
            lvwWord.Sort(); // 執行排序
        }

        public class ListViewItemComparer : System.Collections.IComparer
        {
            private int col;
            private bool asc;

            public ListViewItemComparer(int column, bool ascending)
            {
                col = column;
                asc = ascending;
            }

            public int Compare(object x, object y)
            {
                int returnVal = string.Compare(((ListViewItem)x).SubItems[col].Text,
                                               ((ListViewItem)y).SubItems[col].Text);

                // 如果是反向排序，就把結果乘以 -1
                return asc ? returnVal : -returnVal;
            }
        }
    }
}
