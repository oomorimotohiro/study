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
            this.calc = new System.Windows.Forms.Button();
            this.left = new System.Windows.Forms.TextBox();
            this.right = new System.Windows.Forms.TextBox();
            this.ope = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // calc
            // 
            this.calc.Location = new System.Drawing.Point(92, 102);
            this.calc.Name = "calc";
            this.calc.Size = new System.Drawing.Size(65, 23);
            this.calc.TabIndex = 0;
            this.calc.Text = "計算";
            this.calc.UseVisualStyleBackColor = true;
            this.calc.Click += new System.EventHandler(this.calc_Click);
            // 
            // left
            // 
            this.left.Location = new System.Drawing.Point(22, 44);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(65, 19);
            this.left.TabIndex = 1;
            // 
            // right
            // 
            this.right.Location = new System.Drawing.Point(164, 44);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(65, 19);
            this.right.TabIndex = 2;
            // 
            // ope
            // 
            this.ope.FormattingEnabled = true;
            this.ope.Items.AddRange(new object[] {
            "＋",
            "－",
            "×",
            "÷"});
            this.ope.Location = new System.Drawing.Point(108, 44);
            this.ope.Name = "ope";
            this.ope.Size = new System.Drawing.Size(35, 20);
            this.ope.TabIndex = 3;
            this.ope.SelectedIndexChanged += new System.EventHandler(this.ope_SelectedIndexChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 137);
            this.Controls.Add(this.ope);
            this.Controls.Add(this.right);
            this.Controls.Add(this.left);
            this.Controls.Add(this.calc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "C#研修001";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox left;
        private System.Windows.Forms.TextBox right;
        private System.Windows.Forms.ComboBox ope;
        private System.Windows.Forms.Button calc;
    }
}

