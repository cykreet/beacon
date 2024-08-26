using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Beacon.WorkspaceTests;

namespace Beacon;

public partial class MainForm : Form {
  private readonly string fontFamily = "Jetbrains Mono";
  private readonly List<FlowLayoutPanel> testContainers = [];

  public MainForm() {
    var windowValue = true;
    // set DWMWA_USE_IMMERSIVE_DARK_MODE (value of 20) to true to style window in dark mode
    // https://codingguides.quinnscomputing.com/2022/05/how-to-enable-dark-title-bar-in-windows.html
    DwmSetWindowAttribute(this.Handle, 20, ref windowValue, Marshal.SizeOf(windowValue));

    this.FormBorderStyle = FormBorderStyle.None;
    this.InitializeComponent();
    this.insertWorkspaceTypes();
    this.createWorkspaceTestList();
    this.versionString.Text = Application.ProductVersion;

    var testRunner = Program.getTestRunner();
    this.fileLabel.Click += this.onUploadPanelClick;
    testRunner!.testComplete += this.onTestComplete;
    this.submitButton.Click += this.onSubmitButtonClick;
    this.workspaceTypeSelect.SelectedValueChanged += onWorkspaceTypeSelect;
  }

  [DllImport("dwmapi.dll", PreserveSig = true)]
  private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref bool attrValue, int attrSize);

  private void MainForm_Load(object sender, EventArgs eventArgs) { }

  private void insertWorkspaceTypes() {
    var workspaceTypes = Enum.GetNames(typeof(WorkspaceType));
    this.workspaceTypeSelect.Items.AddRange(workspaceTypes);
  }

  private void createWarningContainer() {
    var warningContainer = new TableLayoutPanel();
    warningContainer.ColumnCount = 1;
    warningContainer.RowCount = 1;
  }

  private void createWorkspaceTestList() {
    var workspaceTests = Assembly.GetExecutingAssembly().GetTypes()
      .Where(type => type.IsSubclassOf(typeof(WorkspaceTest)) && !type.IsAbstract);

    foreach (var testType in workspaceTests) {
      var container = new FlowLayoutPanel();
      container.BackColor = ColorTranslator.FromHtml("#0f111a");
      container.Margin = new Padding(0, 0, 0, 10);
      container.Padding = new Padding(5);
      container.AutoSize = true;
      container.Name = testType.Name;
      container.BorderStyle = BorderStyle.FixedSingle;
      container.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      container.Dock = DockStyle.Top;
      container.Tag = new ContainerTag { state = ContainerState.Default };
      container.Paint += onContainerPaint;

      var headerContainer = new TableLayoutPanel();
      headerContainer.ColumnCount = 4;
      headerContainer.RowCount = 1;
      headerContainer.Dock = DockStyle.Fill;
      headerContainer.AutoSize = true;

      var checkbox = new CheckBox();
      checkbox.AutoSize = true;
      checkbox.Tag = testType;
      checkbox.Cursor = Cursors.Hand;
      checkbox.CheckedChanged += onTestChecked;

      var testName = testType.GetCustomAttribute<TestNameAttribute>().name;
      var testDescription = testType.GetCustomAttribute<TestDescriptionAttribute>().description;

      var nameLabel = new Label();
      nameLabel.AutoSize = true;
      nameLabel.ForeColor = Color.White;
      nameLabel.Font = new Font(this.fontFamily, 12f, FontStyle.Bold);
      nameLabel.Text = testName + " Test";

      var statusIndicator = new Label();
      statusIndicator.AutoSize = true;
      statusIndicator.Name = "statusIndicator";
      statusIndicator.Anchor = AnchorStyles.Right;
      statusIndicator.Font = new Font(this.fontFamily, 12f, FontStyle.Bold);
      // using visibility caused thread to hang, this is an annoying but easy fix
      statusIndicator.ForeColor = ColorTranslator.FromHtml("#0f111a");
      statusIndicator.Text = "!";
      statusIndicator.Dock = DockStyle.Right;
      // we have to handle tooltip hovers on our own, because for some reason just using
      // tooltip.SetToolTip also causes the thread to hang unnecessarily long and then crash
      statusIndicator.MouseHover += this.onWarningHover;

      headerContainer.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
      headerContainer.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
      headerContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
      headerContainer.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

      headerContainer.Controls.Add(checkbox, 0, 0);
      headerContainer.Controls.Add(nameLabel, 1, 0);
      // panel fills space for warning indicator to appear on the right
      headerContainer.Controls.Add(new Panel(), 2, 0);
      headerContainer.Controls.Add(statusIndicator, 3, 0);
      headerContainer.MaximumSize = new Size(int.MaxValue, nameLabel.Height);

      var descriptionLabel = new Label();
      descriptionLabel.AutoSize = true;
      descriptionLabel.Dock = DockStyle.Bottom;
      descriptionLabel.ForeColor = Color.DarkGray;
      descriptionLabel.Font = new Font(this.fontFamily, 9f);
      descriptionLabel.Text = testDescription;

      container.Controls.Add(headerContainer);
      container.Controls.Add(descriptionLabel);

      this.testsContainer.RowCount++;
      this.testsContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
      this.testsContainer.Controls.Add(container, 1, this.testsContainer.RowCount - 1);
      this.testContainers.Add(container);
    }
  }

  private static void onWorkspaceTypeSelect(object sender, EventArgs eventArgs) {
    var testRunner = Program.getTestRunner();
    var comboBox = (ComboBox)sender;
    var workspaceType = (WorkspaceType)Enum.Parse(typeof(WorkspaceType), comboBox.SelectedItem.ToString());
    testRunner?.setWorkspaceType(workspaceType);
  }

  private static void onContainerPaint(object sender, PaintEventArgs eventArgs) {
    if (sender is not FlowLayoutPanel container) return;
    var containerTag = container.Tag is ContainerTag tag ? tag : default;
    var borderColour = Color.RoyalBlue;
    switch (containerTag.state) {
      case ContainerState.Failure:
        borderColour = Color.Crimson;
        break;
      case ContainerState.Success:
        borderColour = Color.PaleGreen;
        break;
      case ContainerState.Loading:
        borderColour = Color.White;
        break;
      default:
      case ContainerState.Default:
        break;
    }

    ControlPaint.DrawBorder(eventArgs.Graphics, container.ClientRectangle, borderColour, ButtonBorderStyle.Solid);
  }

  private void onUploadPanelClick(object sender, EventArgs eventArgs) {
    var dialog = new OpenFileDialog();
    dialog.Title = @"Select a file to scan";
    dialog.Filter = @"Zip files (*.zip)|*.zip";
    if (dialog.ShowDialog() != DialogResult.OK) return;
    this.fileLabel.Text = dialog.SafeFileName;

    Task.Run(() => {
      var zipReader = new ZipReader(dialog.FileName);
      Program.getTestRunner()?.setWorkspace(zipReader);
      this.submitButton.Enabled = true;
    });
  }

  private void onSubmitButtonClick(object sender, EventArgs eventArgs) {
    // we're treating this as our state reset
    foreach (var container in this.testContainers) {
      var containerTag = (ContainerTag)container.Tag;
      if (containerTag.state == ContainerState.Default) continue;

      var statusIndicator = container.Controls.Find("statusIndicator", true).FirstOrDefault();
      if (statusIndicator != null) statusIndicator.ForeColor = ColorTranslator.FromHtml("#0f111a");
      containerTag.state = ContainerState.Default;
      container.Tag = containerTag;
      container.Invalidate();
      container.Update();
    }

    if (this.workspaceTypeSelect.SelectedItem == null) return;
    Task.Run(() => Program.getTestRunner()?.runTests());
  }

  private void onWarningHover(object sender, EventArgs eventArgs) {
    if (sender is not Label warningSender) return;
    var warnings = warningSender.Tag as string;
    this.tooltip.Show(warnings, warningSender);
  }

  private void onTestComplete(object? sender, TestResult result) {
    Sentry.info(
      $"Test completed: \x1b[1m{(result.passed ? "\x1b[92mPASSED" : "\x1b[91mFAILED")}\x1b[22m\x1b[39m");

    Task.Run(() => {
      var testType = (Type)sender!;
      var testContainer = this.testContainers.Find(container => container.Name == testType.Name);
      var warningIndicator = testContainer.Controls.Find("statusIndicator", true).FirstOrDefault();
      var containerTag = (ContainerTag)testContainer.Tag;
      containerTag.state = result.passed ? ContainerState.Success : ContainerState.Failure;
      testContainer.Tag = containerTag;

      if (warningIndicator != null) {
        switch (containerTag.state) {
          case ContainerState.Failure:
            warningIndicator.ForeColor = Color.Crimson;
            warningIndicator.Text = @"!";
            break;
          case ContainerState.Success:
            warningIndicator.ForeColor = Color.PaleGreen;
            warningIndicator.Text = @"✓";
            break;
          case ContainerState.Default:
          case ContainerState.Loading:
          default:
            throw new ArgumentOutOfRangeException();
        }

        var warnings = string.Join("\n", result.warnings);
        warningIndicator.Tag = warnings;
      }

      testContainer.Invalidate();
      testContainer.Update();
    });
  }

  private static void onTestChecked(object sender, EventArgs eventArgs) {
    var checkbox = (CheckBox)sender;
    var testType = (Type)checkbox.Tag;
    var testRunner = Program.getTestRunner();
    if (checkbox.Checked) testRunner?.enableTest(testType);
    else if (checkbox.Checked == false) testRunner?.disableTest(testType);
  }

  private enum ContainerState {
    Default,
    Loading,
    Success,
    Failure
  }

  private struct ContainerTag {
    public ContainerState state { get; set; }
  }
}