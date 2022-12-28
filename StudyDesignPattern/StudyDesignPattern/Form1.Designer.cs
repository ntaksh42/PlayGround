namespace StudyDesignPattern
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._panelDrw = new System.Windows.Forms.Panel();
            this._btnRight = new System.Windows.Forms.Button();
            this._btnCall = new System.Windows.Forms.Button();
            this._radioBtnMario = new System.Windows.Forms.RadioButton();
            this._radioBtnLuigi = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // _panelDrw
            // 
            this._panelDrw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._panelDrw.Location = new System.Drawing.Point(25, 85);
            this._panelDrw.Name = "_panelDrw";
            this._panelDrw.Size = new System.Drawing.Size(748, 271);
            this._panelDrw.TabIndex = 0;
            this._panelDrw.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // _btnRight
            // 
            this._btnRight.Location = new System.Drawing.Point(25, 376);
            this._btnRight.Name = "_btnRight";
            this._btnRight.Size = new System.Drawing.Size(90, 62);
            this._btnRight.TabIndex = 1;
            this._btnRight.Text = "→";
            this._btnRight.UseVisualStyleBackColor = true;
            this._btnRight.Click += new System.EventHandler(this._btnRight_Click);
            // 
            // _btnCall
            // 
            this._btnCall.Location = new System.Drawing.Point(158, 376);
            this._btnCall.Name = "_btnCall";
            this._btnCall.Size = new System.Drawing.Size(90, 62);
            this._btnCall.TabIndex = 2;
            this._btnCall.Text = "A";
            this._btnCall.UseVisualStyleBackColor = true;
            // 
            // _radioBtnMario
            // 
            this._radioBtnMario.AutoSize = true;
            this._radioBtnMario.Checked = true;
            this._radioBtnMario.Location = new System.Drawing.Point(25, 26);
            this._radioBtnMario.Name = "_radioBtnMario";
            this._radioBtnMario.Size = new System.Drawing.Size(78, 29);
            this._radioBtnMario.TabIndex = 3;
            this._radioBtnMario.TabStop = true;
            this._radioBtnMario.Text = "マリオ";
            this._radioBtnMario.UseVisualStyleBackColor = true;
            this._radioBtnMario.CheckedChanged += new System.EventHandler(this._radioBtnMario_CheckedChanged);
            // 
            // _radioBtnLuigi
            // 
            this._radioBtnLuigi.AutoSize = true;
            this._radioBtnLuigi.Location = new System.Drawing.Point(207, 26);
            this._radioBtnLuigi.Name = "_radioBtnLuigi";
            this._radioBtnLuigi.Size = new System.Drawing.Size(92, 29);
            this._radioBtnLuigi.TabIndex = 4;
            this._radioBtnLuigi.Text = "ルイージ";
            this._radioBtnLuigi.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._radioBtnLuigi);
            this.Controls.Add(this._radioBtnMario);
            this.Controls.Add(this._btnCall);
            this.Controls.Add(this._btnRight);
            this.Controls.Add(this._panelDrw);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel _panelDrw;
        private Button _btnRight;
        private Button _btnCall;
        private RadioButton _radioBtnMario;
        private RadioButton _radioBtnLuigi;
    }
}