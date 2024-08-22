using System;
using System.Windows.Forms;

namespace Beacon;

public partial class MainForm : Form {
  public MainForm() {
    this.FormBorderStyle = FormBorderStyle.FixedSingle;
    this.InitializeComponent();
  }
  
  private void MainForm_Load(object sender, EventArgs e) {}

  private void uploadButtonClick(object sender, EventArgs e) {
    var dialog = new OpenFileDialog();
    dialog.Filter = "Zip files (*.zip)|*.zip";
    if (dialog.ShowDialog() != DialogResult.OK) return;
    var zipFile = dialog.FileName;
    this.fileLabel.Text = zipFile;
  }
}