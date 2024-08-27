using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Beacon.Controls;
using Beacon.WorkspaceTests;
using Waypoint;
using System.IO;


namespace Beacon;

public sealed partial class MainForm : Form {
  public static readonly Color backColour = ColorTranslator.FromHtml("#0f111a");
  private readonly string fontFamily = "Jetbrains Mono";
  private readonly List<FlowLayoutPanel> testContainers = [];
  private readonly WarningTooltip warningTooltip = new();

  public MainForm() {
    var windowValue = true;
    // set DWMWA_USE_IMMERSIVE_DARK_MODE (value of 20) to true to style window in dark mode
    // https://codingguides.quinnscomputing.com/2022/05/how-to-enable-dark-title-bar-in-windows.html
    DwmSetWindowAttribute(this.Handle, 20, ref windowValue, Marshal.SizeOf(windowValue));

    // todo: rider doesn't support adding files to resources, and im not installing visual studio just for this
    
   
      // Determine path
      var assembly = Assembly.GetExecutingAssembly();
      string resourcePath = name;
      // Format: "{Namespace}.{Folder}.{filename}.{Extension}"
      if (!name.StartsWith(nameof(SignificantDrawerCompiler)))
      {
        resourcePath = assembly.GetManifestResourceNames()
          .Single(str => str.EndsWith(name));
      }

      using (Stream stream = assembly.GetManifestResourceStream(resourcePath)) {
        byte[] result;
        using (var streamReader = new MemoryStream())
        {
          InputStream.CopyTo(streamReader);
          result = streamReader.ToArray(); // fontData
        }
        var bytes = new byte[stream.Length];
        var fontData = stream.Read(bytes, (int)stream.Length, (int)stream.Length);
        var fontLength = bytes.Length;
        var memoryData = Marshal.AllocCoTaskMem(fontLength);
        Marshal.Copy(bytes, 0, memoryData, fontLength);
        privateFontCollection.AddMemoryFont(memoryData, fontLength);
        this.Font = new Font(privateFontCollection.Families[0], this.Font.Size);    
      }
      
      // PrivateFontCollection privateFontCollection = new();
    // var fontLength = Properties.Resources.JetBrains_Mono_Font.Length;
    // byte[] fontData = Properties.Resources.JetBrains_Mono_Font;
    

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

  private void createWorkspaceTestList() {
    var workspaceTests = Program.getTestRunner()?.getTests().Select(test => test.GetType());
    if (workspaceTests == null) return;
    foreach (var testType in workspaceTests) {
      var container = new FlowLayoutPanel();
      container.BackColor = backColour;
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
      statusIndicator.Font = new Font(this.fontFamily, 14f, FontStyle.Bold);
      // using visibility caused thread to hang, this is an annoying but easy fix
      statusIndicator.ForeColor = backColour;
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
      if (statusIndicator != null) {
        statusIndicator.ForeColor = backColour;
        statusIndicator.Tag = null;
      }

      containerTag.state = ContainerState.Default;
      container.Tag = containerTag;
      container.Invalidate();
      container.Update();
    }

    if (this.workspaceTypeSelect.SelectedItem == null) return;
    Task.Run(() => Program.getTestRunner()?.runTests());
  }

  private void onWarningHover(object sender, EventArgs eventArgs) {
    if (sender is not Label statusIndicator) return;
    if (statusIndicator.Tag is not string warnings) {
      this.warningTooltip.Hide(statusIndicator);
      return;
    }

    this.warningTooltip.Show(warnings, statusIndicator);
  }

  private void onTestComplete(object? sender, TestResult result) =>
    Task.Run(() => {
      var testType = (Type)sender!;
      var testContainer = this.testContainers.Find(container => container.Name == testType.Name);
      var statusIndicator = testContainer.Controls.Find("statusIndicator", true).FirstOrDefault();
      var containerTag = (ContainerTag)testContainer.Tag;
      containerTag.state = result.passed ? ContainerState.Success : ContainerState.Failure;
      testContainer.Tag = containerTag;

      if (statusIndicator != null) {
        if (result.warnings.Any()) {
          statusIndicator.ForeColor = Color.Orange;
          statusIndicator.Text = @"⚠";
        } else {
          switch (containerTag.state) {
            case ContainerState.Failure:
              statusIndicator.ForeColor = Color.Red;
              statusIndicator.Text = @"!";
              break;
            case ContainerState.Success:
              statusIndicator.ForeColor = Color.PaleGreen;
              statusIndicator.Text = @"✓";
              break;
            case ContainerState.Default:
            case ContainerState.Loading:
            default:
              throw new ArgumentOutOfRangeException();
          }
        }

        statusIndicator.Tag = result.warnings.Any() ? string.Join("\n", result.warnings) : null;
      }

      testContainer.Invalidate();
      testContainer.Update();
    });

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