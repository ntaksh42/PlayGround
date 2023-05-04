namespace StudyXML
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
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this._btnCreate = new System.Windows.Forms.Button();
            this._btnRead = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _btnCreate
            // 
            this._btnCreate.Location = new System.Drawing.Point(12, 23);
            this._btnCreate.Name = "_btnCreate";
            this._btnCreate.Size = new System.Drawing.Size(136, 42);
            this._btnCreate.TabIndex = 0;
            this._btnCreate.Text = "Create";
            this._btnCreate.UseVisualStyleBackColor = true;
            this._btnCreate.Click += new System.EventHandler(this._btnCreate_Click);
            // 
            // _btnRead
            // 
            this._btnRead.Location = new System.Drawing.Point(12, 71);
            this._btnRead.Name = "_btnRead";
            this._btnRead.Size = new System.Drawing.Size(136, 40);
            this._btnRead.TabIndex = 1;
            this._btnRead.Text = "Read";
            this._btnRead.UseVisualStyleBackColor = true;
            this._btnRead.Click += new System.EventHandler(this._btnRead_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 153);
            this.Controls.Add(this._btnRead);
            this.Controls.Add(this._btnCreate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnCreate;
        private System.Windows.Forms.Button _btnRead;
    }
}

