using System.Drawing;

namespace Beacon;

partial class MainForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label7 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.Color.White;
      this.label2.Location = new System.Drawing.Point(731, -64);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(194, 55);
      this.label2.TabIndex = 2;
      this.label2.Text = "Beacon";
      // 
      // label3
      // 
      this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(121)))), ((int)(((byte)(131)))));
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(409, 157);
      this.label3.Name = "label3";
      this.label3.Padding = new System.Windows.Forms.Padding(5);
      this.label3.Size = new System.Drawing.Size(320, 40);
      this.label3.TabIndex = 3;
      this.label3.Text = "Check if this is a ZIP folder";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label4
      // 
      this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(121)))), ((int)(((byte)(131)))));
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(409, 216);
      this.label4.Name = "label4";
      this.label4.Padding = new System.Windows.Forms.Padding(5);
      this.label4.Size = new System.Drawing.Size(320, 40);
      this.label4.TabIndex = 4;
      this.label4.Text = "Check the size for this ZIP folder";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label5
      // 
      this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(121)))), ((int)(((byte)(131)))));
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(409, 273);
      this.label5.Name = "label5";
      this.label5.Padding = new System.Windows.Forms.Padding(5);
      this.label5.Size = new System.Drawing.Size(320, 40);
      this.label5.TabIndex = 5;
      this.label5.Text = "Check if this folder is password protected";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label6
      // 
      this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(121)))), ((int)(((byte)(131)))));
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(409, 329);
      this.label6.Name = "label6";
      this.label6.Padding = new System.Windows.Forms.Padding(5);
      this.label6.Size = new System.Drawing.Size(320, 40);
      this.label6.TabIndex = 6;
      this.label6.Text = "Check if this folder contains malicious files";
      this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
      this.button1.FlatAppearance.BorderSize = 0;
      this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
      this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
      this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button1.ForeColor = System.Drawing.Color.White;
      this.button1.Location = new System.Drawing.Point(317, 402);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(201, 33);
      this.button1.TabIndex = 7;
      this.button1.Text = "Check Folder";
      this.button1.UseVisualStyleBackColor = false;
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.Gray;
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panel1.Location = new System.Drawing.Point(97, 113);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(666, 2);
      this.panel1.TabIndex = 8;
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(78)))), ((int)(((byte)(86)))));
      this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel2.Controls.Add(this.label7);
      this.panel2.Controls.Add(this.label1);
      this.panel2.Location = new System.Drawing.Point(125, 157);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(221, 211);
      this.panel2.TabIndex = 9;
      // 
      // label7
      // 
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.ForeColor = System.Drawing.Color.White;
      this.label7.Location = new System.Drawing.Point(1, 186);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(219, 24);
      this.label7.TabIndex = 1;
      this.label7.Text = "Show Uploaded File Name";
      this.label7.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
      this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
      this.label1.Location = new System.Drawing.Point(34, 70);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(148, 77);
      this.label1.TabIndex = 0;
      this.label1.Text = "Upload Folder";
      this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      this.label1.Click += new System.EventHandler(this.label1_Click_2);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
      this.ClientSize = new System.Drawing.Size(878, 499);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.ShowIcon = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.Text = "Beacon";
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private System.Windows.Forms.Label label7;

    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label1;

    #endregion

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Panel panel1;

}