# TSV 檔案格式讀取程式

本專案是一款基於 C# Windows Forms 開發的數位單字檢視工具。

程式採用物件導向架構，將結構化的文字檔案（TSV/TXT）動態載入至自訂集合，以視覺化的多欄位清單呈現，提供流暢的數據瀏覽功能。


## 核心功能

### 1. 動態檔案載入：

* 支援讀取標準 `TSV` 、 `TXT` 檔，內建防錯機制（Null 聯合運算子），能自動捕捉並過濾破損或不完整的單字資料，確保系統不會當機。
  
### 2. 即時關鍵字查詢：

* 提供搜尋方塊，在使用者輸入字串時進行即時過濾與畫面重繪，快速鎖定特定單字。

### 3. 雙擊排序：

* 整合自訂 IComparer 排序器，點擊任意欄位標題（單字、音標、解釋等）即可在正序（A-Z）與倒序（Z-A）之間動態切換。

### 4. 介面縮放：

* 清單欄位能根據載入資料的長度自動縮放調整寬度，避免文字被遮擋的困擾;介面也進行了設定，無論使用者放大縮小都不會跑版。

### 5. 無滑鼠操作：

* 全程支援 `tab 鍵` 跳轉與 `空白鍵` 選取，還設定了其他快捷鍵。


## 使用說明

1.  **開啟檔案**：
   
    * 點選左上角選單的 「檔案」 -> 「開啟檔案」（或使用鍵盤快捷鍵 Ctrl + O）。

      <img width="500" alt="螢幕擷取畫面 2026-05-24 180752" src="https://github.com/user-attachments/assets/88257242-7e14-462e-b8ea-08c375cc422e" />
  
    * 選取內含單字資料的 WordCards.txt 或符合格式的 .tsv 檔案，點選確定。
  
      <img width="500" alt="螢幕擷取畫面 2026-05-24 180823" src="https://github.com/user-attachments/assets/e5526262-8544-4cb3-ba6d-2ad3cec5db15" />

    * 下方狀態列會即時回饋並顯示：成功載入 XXX 個單字。
  
      <img width="500" alt="螢幕擷取畫面 2026-05-24 180843" src="https://github.com/user-attachments/assets/fc106bdd-10a1-48c4-80e5-afd866e5f851" />

2.  **檢視與查詢**：
   
    * **搜尋單字**：直接在最上方的 「查詢單字：」 文字框中輸入你想查的單字或字母，清單會隨之即時連動過濾。
  
      <img width="500" alt="螢幕擷取畫面 2026-05-24 181846" src="https://github.com/user-attachments/assets/37401a5c-1a6b-456b-8afe-6ec6254061fd" />
  
    * **點擊排序**：用滑鼠點擊清單的任一欄位標題(單字、音標、音檔路徑、解釋)，可以切換單字排序 A-Z 與 Z-A。
  
      <img width="300" alt="螢幕擷取畫面 2026-05-24 181904" src="https://github.com/user-attachments/assets/558bad6e-1eff-4f6b-bd1c-4dc6ff1c4072" /> <img width="300" alt="螢幕擷取畫面 2026-05-24 181928" src="https://github.com/user-attachments/assets/6573ab5a-9992-4b99-be49-3568c3d62c8a" />

3.  **結束程式**：

    * 點選 「檔案」 -> 「離開」（或使用鍵盤快捷鍵 Ctrl + X），或直接點擊視窗右上角的「X」，會彈出確認視窗，避免使用者誤按，若要關閉程式按「是(Y)」即可結束。

      <img width="500" alt="image" src="https://github.com/user-attachments/assets/215b4d14-7503-46f5-9759-fb02c17a54e4" />


## 開發環境

* **開發語言**：C# (.NET Framework)
* **開發工具**：Visual Studio 2022
