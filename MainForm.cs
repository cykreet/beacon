using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Beacon.WorkspaceTests;

namespace Beacon;

public partial class MainForm : Form {
  private readonly string fontFamily = "Jetbrains Mono";

  public MainForm() {
    this.FormBorderStyle = FormBorderStyle.FixedSingle;
    this.InitializeComponent();
    this.createWorkspaceTestList();

    var testRunner = Program.getTestRunner();
    this.fileLabel.Click += this.onUploadPanelClick;
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
      var container = new FlowLayoutPanel();
      container.BackColor = ColorTranslator.FromHtml("#0f111a");
      container.Margin = new Padding(0, 0, 0, 10);
      container.Padding = new Padding(5);
      container.AutoSize = true;
      container.BorderStyle = BorderStyle.FixedSingle;
      container.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      container.Dock = DockStyle.Top;
      container.Paint += onContainerPaint;

      var headerContainer = new FlowLayoutPanel();
      var checkbox = new CheckBox();
      checkbox.AutoSize = true;
      checkbox.Tag = testType;
      checkbox.Dock = DockStyle.Fill;
      checkbox.Cursor = Cursors.Hand;
      checkbox.CheckedChanged += onTestChecked;

      var testName = testType.GetCustomAttribute<TestNameAttribute>()?.name;
      var testDescription = testType.GetCustomAttribute<TestDescriptionAttribute>()?.description;

      var nameLabel = new Label();
      nameLabel.AutoSize = true;
      nameLabel.ForeColor = Color.White;
      nameLabel.Font = new Font(this.fontFamily, 12f, FontStyle.Bold);
      nameLabel.Dock = DockStyle.Fill;
      nameLabel.Text = testName + " Test";

      headerContainer.Controls.Add(checkbox);
      headerContainer.Controls.Add(nameLabel);
      headerContainer.MaximumSize = new Size(headerContainer.Width, nameLabel.Height);

      var descriptionLabel = new Label();
      descriptionLabel.AutoSize = true;
      descriptionLabel.Dock = DockStyle.Bottom;
      descriptionLabel.ForeColor = Color.DarkGray;
      descriptionLabel.Font = new Font(this.fontFamily, 9f);
      descriptionLabel.Text = testDescription;

      container.Controls.Add(headerContainer);
      container.Controls.Add(descriptionLabel);

      // var temp = this.testsContainer.RowStyles[this.testsContainer.RowCount - 1];
      this.testsContainer.RowCount++;
      this.testsContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
      this.testsContainer.Controls.Add(container, 1, this.testsContainer.RowCount - 1);
    }
  }

  private static void onContainerPaint(object sender, PaintEventArgs eventArgs) {
    if (sender is not FlowLayoutPanel container) return;
    ControlPaint.DrawBorder(eventArgs.Graphics, container.ClientRectangle, Color.RoyalBlue, ButtonBorderStyle.Solid);
  }

  private void onUploadPanelClick(object sender, EventArgs eventArgs) {
    var dialog = new OpenFileDialog();
    dialog.Title = "Select a file to scan";
    dialog.Filter = "Zip files (*.zip)|*.zip";
    if (dialog.ShowDialog() != DialogResult.OK) return;
    this.fileLabel.Text = dialog.FileName;

    var zipReader = new ZipReader(dialog.FileName);
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