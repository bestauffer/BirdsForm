namespace BirdsForm
{
    partial class FormNewBird
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBird = new System.Windows.Forms.TextBox();
            this.buttonNewBird = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(226, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add a new type of Bird";
            // 
            // textBoxBird
            // 
            this.textBoxBird.Location = new System.Drawing.Point(230, 122);
            this.textBoxBird.Name = "textBoxBird";
            this.textBoxBird.Size = new System.Drawing.Size(226, 20);
            this.textBoxBird.TabIndex = 1;
            // 
            // buttonNewBird
            // 
            this.buttonNewBird.Location = new System.Drawing.Point(247, 167);
            this.buttonNewBird.Name = "buttonNewBird";
            this.buttonNewBird.Size = new System.Drawing.Size(188, 23);
            this.buttonNewBird.TabIndex = 2;
            this.buttonNewBird.Text = "Click to Enter New Bird Type";
            this.buttonNewBird.UseVisualStyleBackColor = true;
            this.buttonNewBird.Click += new System.EventHandler(this.buttonNewBird_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(227, 307);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(53, 20);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "status";
            // 
            // FormNewBird
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 482);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonNewBird);
            this.Controls.Add(this.textBoxBird);
            this.Controls.Add(this.label1);
            this.Name = "FormNewBird";
            this.Text = "FormNewBird";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBird;
        private System.Windows.Forms.Button buttonNewBird;
        private System.Windows.Forms.Label labelStatus;
    }
}