namespace GetFilePath
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.file_paths = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // file_paths
            // 
            this.file_paths.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.file_paths.Location = new System.Drawing.Point(12, 12);
            this.file_paths.Multiline = true;
            this.file_paths.Name = "file_paths";
            this.file_paths.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.file_paths.Size = new System.Drawing.Size(578, 157);
            this.file_paths.TabIndex = 1;
            this.file_paths.WordWrap = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(474, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "クリップボードにコピー";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 222);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.file_paths);
            this.Name = "Form1";
            this.Text = "ファイルパス取得";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.filepathtext_DragDrop);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox file_paths;
        private System.Windows.Forms.Button button1;
    }
}

