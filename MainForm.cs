using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Beacon.WorkspaceTests;

namespace Beacon;

public partial class MainForm : Form {
  public MainForm() {
    this.FormBorderStyle = FormBorderStyle.FixedSingle;
    this.InitializeComponent();
    this.createWorkspaceTestList();

    this.submitButton.Click += this.submitButtonClick;
    var testRunner = Program.getTestRunner();
    testRunner!.testComplete += onTestComplete;
  }

  private void MainForm_Load(object sender, EventArgs e) { }

  private void createWorkspaceTestList() {
    var workspaceTests = Assembly.GetExecutingAssembly().GetTypes()
      .Where(type => type.IsSubclassOf(typeof(WorkspaceTest)) && !type.IsAbstract);

    var yPosition = 20;
    foreach (var testType in workspaceTests) {
      var checkbox = new CheckBox();
      checkbox.AutoSize = true;
      checkbox.Location = new Point(20, yPosition);
      checkbox.Tag = testType;
      checkbox.CheckedChanged += this.onTestChecked;

      var testName = testType.GetCustomAttribute<TestNameAttribute>()?.name;
      var testDescription = testType.GetCustomAttribute<TestDescriptionAttribute>()?.description;

      var label = new Label();
      label.AutoSize = true;
      label.Location = new Point(60, yPosition);
      label.Text = testName + " Test";

      this.Controls.Add(checkbox);
      this.Controls.Add(label);

      yPosition += 30;
    }
  }

  private void uploadButtonClick(object sender, EventArgs eventArgs) {
    var dialog = new OpenFileDialog();
    dialog.Filter = "Zip files (*.zip)|*.zip";
    if (dialog.ShowDialog() != DialogResult.OK) return;
    var zipFile = dialog.FileName;
    this.fileLabel.Text = zipFile;
  }

  private void submitButtonClick(object sender, EventArgs eventArgs) {
    var testRunner = Program.getTestRunner();
    var zipReader = new ZipReader("./test.zip");
    testRunner?.runTests(zipReader);
  }

  private static void onTestComplete(object? sender, TestResult result) =>
    // colours: https://stackoverflow.com/a/74807043
    Sentry.info(
      $"{result.name} Test completed: \x1b[1m{(result.passed ? "\x1b[92mPASSED" : "\x1b[91mFAILED")}\x1b[22m\x1b[39m");

  private void onTestChecked(object sender, EventArgs eventArgs) {
    var checkbox = (CheckBox)sender;
    var testType = (Type)checkbox.Tag;
    var testRunner = Program.getTestRunner();
    if (checkbox.Checked) testRunner?.enableTest(testType);
    else if (checkbox.Checked == false) testRunner?.disableTest(testType);
  }
}