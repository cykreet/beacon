using System;
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

    this.submitButton.Click += onSubmitButtonClick;
    var testRunner = Program.getTestRunner();
    testRunner!.testComplete += onTestComplete;
  }

  private void MainForm_Load(object sender, EventArgs e) { }

  private void createWorkspaceTestList() {
    var workspaceTests = Assembly.GetExecutingAssembly().GetTypes()
      .Where(type => type.IsSubclassOf(typeof(WorkspaceTest)) && !type.IsAbstract);

    foreach (var testType in workspaceTests) {
      // todo: all broken, container should contain the checkbox, name, description
      // then also a kind of notification icon for test warnings and test completion/idle
      // icons -- notification icon should display warnings on hover
      var container = new ContainerControl();
      // container.BackColor = ColorTranslator.FromHtml("#454f77");
      container.Margin = new Padding(0, 0, 0, 20);
      container.Padding = new Padding(5);
      container.AutoSize = true;
      container.Height = 2;

      var checkbox = new CheckBox();
      checkbox.AutoSize = true;
      checkbox.Tag = testType;
      // checkbox.Margin = new Padding(0, 0, 5, 0);
      checkbox.Dock = DockStyle.Left;
      // checkbox.Anchor = AnchorStyles.Top | AnchorStyles.Left;
      checkbox.CheckedChanged += onTestChecked;

      var testName = testType.GetCustomAttribute<TestNameAttribute>()?.name;
      var testDescription = testType.GetCustomAttribute<TestDescriptionAttribute>()?.description;

      var nameLabel = new Label();
      nameLabel.AutoSize = true;
      nameLabel.Dock = DockStyle.Left;
      // nameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      nameLabel.Text = testName + " Test";

      var descriptionLabel = new Label();
      descriptionLabel.AutoSize = true;
      checkbox.Dock = DockStyle.Bottom;
      descriptionLabel.Text = testDescription;

      container.Controls.Add(checkbox);
      container.Controls.Add(nameLabel);
      container.Controls.Add(descriptionLabel);
      this.testsContainer.Controls.Add(container);
    }
  }

  private void onUploadButtonClick(object sender, EventArgs eventArgs) {
    var dialog = new OpenFileDialog();
    dialog.Filter = "Zip files (*.zip)|*.zip";
    if (dialog.ShowDialog() != DialogResult.OK) return;
    var zipReader = new ZipReader(dialog.FileName);
    this.fileLabel.Text = dialog.FileName;

    Program.getTestRunner()?.setWorkspace(zipReader);
    this.submitButton.Enabled = true;
  }

  private static void onSubmitButtonClick(object sender, EventArgs eventArgs) {
    var testRunner = Program.getTestRunner();
    testRunner?.runTests();
  }

  private static void onTestComplete(object? sender, TestResult result) =>
    // colours: https://stackoverflow.com/a/74807043
    Sentry.info(
      $"{result.name} Test completed: \x1b[1m{(result.passed ? "\x1b[92mPASSED" : "\x1b[91mFAILED")}\x1b[22m\x1b[39m");

  private static void onTestChecked(object sender, EventArgs eventArgs) {
    var checkbox = (CheckBox)sender;
    var testType = (Type)checkbox.Tag;
    var testRunner = Program.getTestRunner();
    if (checkbox.Checked) testRunner?.enableTest(testType);
    else if (checkbox.Checked == false) testRunner?.disableTest(testType);
  }
}