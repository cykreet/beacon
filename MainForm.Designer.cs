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
      this.submitButton = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.fileLabel = new System.Windows.Forms.Label();
      this.uploadLabel = new System.Windows.Forms.Label();
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
      // submitButton
      // 
      this.submitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
      this.submitButton.FlatAppearance.BorderSize = 0;
      this.submitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
      this.submitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
      this.submitButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.submitButton.ForeColor = System.Drawing.Color.White;
      this.submitButton.Location = new System.Drawing.Point(317, 402);
      this.submitButton.Name = "submitButton";
      this.submitButton.Size = new System.Drawing.Size(201, 33);
      this.submitButton.TabIndex = 7;
      this.submitButton.Text = "Check Folder";
      this.submitButton.UseVisualStyleBackColor = false;
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
      this.panel2.Controls.Add(this.fileLabel);
      this.panel2.Controls.Add(this.uploadLabel);
      this.panel2.Location = new System.Drawing.Point(125, 157);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(221, 211);
      this.panel2.TabIndex = 9;
      // 
      // fileLabel
      // 
      this.fileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.fileLabel.ForeColor = System.Drawing.Color.White;
      this.fileLabel.Location = new System.Drawing.Point(1, 186);
      this.fileLabel.Name = "fileLabel";
      this.fileLabel.Size = new System.Drawing.Size(219, 24);
      this.fileLabel.TabIndex = 1;
      this.fileLabel.Text = "Show Uploaded File Name";
      this.fileLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // uploadLabel
      // 
      this.uploadLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.uploadLabel.Image = ((System.Drawing.Image)(resources.GetObject("uploadLabel.Image")));
      this.uploadLabel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
      this.uploadLabel.Location = new System.Drawing.Point(34, 70);
      this.uploadLabel.Name = "uploadLabel";
      this.uploadLabel.Size = new System.Drawing.Size(148, 77);
      this.uploadLabel.TabIndex = 0;
      this.uploadLabel.Text = "Upload Folder";
      this.uploadLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      this.uploadLabel.Click += new System.EventHandler(this.uploadButtonClick);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
      this.ClientSize = new System.Drawing.Size(878, 499);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.submitButton);
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

    private System.Windows.Forms.Label fileLabel;

    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label uploadLabel;

    #endregion

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button submitButton;
    private System.Windows.Forms.Panel panel1;

}