using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TSVFile
{
    internal class WordCollection : Collection<WordItem>
    {
        ///<summary>
        ///從字串陣列載入資料
        ///</summary>
        ///<paramname="lines">輸入的單字字串陣列</param>
        public void LoadFromStringArray(string[] lines)
        {
            this.Clear();
            // 將字串陣列的資料載入到WordCollection物件中
            foreach (string line in lines)
            {
                // 產生WordItem物件
                WordItem item = new WordItem(line);
                this.Add(item);
            }
        }
    }
}
