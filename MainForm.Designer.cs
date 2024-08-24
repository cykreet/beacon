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
      this.label2 = new System.Windows.Forms.Label();
      this.submitButton = new System.Windows.Forms.Button();
      this.uploadPanel = new System.Windows.Forms.Panel();
      this.uploadLabel = new System.Windows.Forms.Label();
      this.fileLabel = new System.Windows.Forms.Label();
      this.testsContainer = new System.Windows.Forms.FlowLayoutPanel();
      this.uploadPanel.SuspendLayout();
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
      this.submitButton.Enabled = false;
      this.submitButton.FlatAppearance.BorderSize = 0;
      this.submitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
      this.submitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
      this.submitButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.submitButton.ForeColor = System.Drawing.Color.White;
      this.submitButton.Location = new System.Drawing.Point(28, 454);
      this.submitButton.Name = "submitButton";
      this.submitButton.Size = new System.Drawing.Size(265, 33);
      this.submitButton.TabIndex = 7;
      this.submitButton.Text = "Check Folder";
      this.submitButton.UseVisualStyleBackColor = false;
      // 
      // uploadPanel
      // 
      this.uploadPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(78)))), ((int)(((byte)(86)))));
      this.uploadPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.uploadPanel.Controls.Add(this.uploadLabel);
      this.uploadPanel.Controls.Add(this.fileLabel);
      this.uploadPanel.Location = new System.Drawing.Point(28, 71);
      this.uploadPanel.Name = "uploadPanel";
      this.uploadPanel.Size = new System.Drawing.Size(265, 27);
      this.uploadPanel.TabIndex = 9;
      // 
      // uploadLabel
      // 
      this.uploadLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.uploadLabel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
      this.uploadLabel.Location = new System.Drawing.Point(-2, -1);
      this.uploadLabel.Name = "uploadLabel";
      this.uploadLabel.Size = new System.Drawing.Size(36, 34);
      this.uploadLabel.TabIndex = 0;
      this.uploadLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      this.uploadLabel.Click += new System.EventHandler(this.onUploadButtonClick);
      // 
      // fileLabel
      // 
      this.fileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.fileLabel.ForeColor = System.Drawing.Color.White;
      this.fileLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.fileLabel.Location = new System.Drawing.Point(40, 0);
      this.fileLabel.Name = "fileLabel";
      this.fileLabel.Size = new System.Drawing.Size(224, 24);
      this.fileLabel.TabIndex = 1;
      this.fileLabel.Text = "Upload zip file";
      this.fileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // testsContainer
      // 
      this.testsContainer.AutoScroll = true;
      this.testsContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.testsContainer.Location = new System.Drawing.Point(28, 115);
      this.testsContainer.Margin = new System.Windows.Forms.Padding(0);
      this.testsContainer.Name = "testsContainer";
      this.testsContainer.Size = new System.Drawing.Size(264, 311);
      this.testsContainer.TabIndex = 10;
      this.testsContainer.WrapContents = false;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
      this.ClientSize = new System.Drawing.Size(323, 499);
      this.Controls.Add(this.testsContainer);
      this.Controls.Add(this.uploadPanel);
      this.Controls.Add(this.submitButton);
      this.Controls.Add(this.label2);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Location = new System.Drawing.Point(15, 15);
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.ShowIcon = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.Text = "Beacon";
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.uploadPanel.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private System.Windows.Forms.FlowLayoutPanel testsContainer;

    private System.Windows.Forms.Label fileLabel;

    private System.Windows.Forms.Panel uploadPanel;
    private System.Windows.Forms.Label uploadLabel;

    #endregion

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button submitButton;
}