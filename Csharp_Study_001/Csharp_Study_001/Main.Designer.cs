namespace Csharp_Study_001
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Calc = new System.Windows.Forms.Button();
            this.LeftText = new System.Windows.Forms.TextBox();
            this.RightText = new System.Windows.Forms.TextBox();
            this.Ope = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // calc
            // 
            this.Calc.Location = new System.Drawing.Point(92, 102);
            this.Calc.Name = "calc";
            this.Calc.Size = new System.Drawing.Size(65, 23);
            this.Calc.TabIndex = 0;
            this.Calc.Text = "計算";
            this.Calc.UseVisualStyleBackColor = true;
            this.Calc.Click += new System.EventHandler(this.Calc_Click);
            // 
            // left
            // 
            this.LeftText.Location = new System.Drawing.Point(22, 44);
            this.LeftText.Name = "left";
            this.LeftText.Size = new System.Drawing.Size(65, 19);
            this.LeftText.TabIndex = 1;
            // 
            // right
            // 
            this.RightText.Location = new System.Drawing.Point(164, 44);
            this.RightText.Name = "right";
            this.RightText.Size = new System.Drawing.Size(65, 19);
            this.RightText.TabIndex = 2;
            // 
            // ope
            // 
            this.Ope.FormattingEnabled = true;
            this.Ope.Items.AddRange(new object[] {
            tasu,
            hiku,
            kake,
            waru});
            this.Ope.Location = new System.Drawing.Point(108, 44);
            this.Ope.Name = "ope";
            this.Ope.Size = new System.Drawing.Size(35, 20);
            this.Ope.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 137);
            this.Controls.Add(this.Ope);
            this.Controls.Add(this.RightText);
            this.Controls.Add(this.LeftText);
            this.Controls.Add(this.Calc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "C#研修001";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox LeftText;
        private System.Windows.Forms.TextBox RightText;
        private System.Windows.Forms.ComboBox Ope;
        private System.Windows.Forms.Button Calc;
    }
}

