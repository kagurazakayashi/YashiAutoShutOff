<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nums1 = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.numi1 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numh1 = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numd1 = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numm1 = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numy1 = New System.Windows.Forms.NumericUpDown()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.nums2 = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.numi2 = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.numh2 = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.numd2 = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.numm2 = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.numy2 = New System.Windows.Forms.NumericUpDown()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nums1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numi1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numh1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numd1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numm1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numy1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nums2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numi2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numh2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numd2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numm2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numy2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.nums1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.numi1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.numh1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.numd1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.numm1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.numy1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(324, 67)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "当前时间"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(271, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 19)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "秒"
        '
        'nums1
        '
        Me.nums1.Enabled = False
        Me.nums1.Location = New System.Drawing.Point(271, 39)
        Me.nums1.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.nums1.Name = "nums1"
        Me.nums1.Size = New System.Drawing.Size(47, 21)
        Me.nums1.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(218, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 19)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "分"
        '
        'numi1
        '
        Me.numi1.Enabled = False
        Me.numi1.Location = New System.Drawing.Point(218, 39)
        Me.numi1.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.numi1.Name = "numi1"
        Me.numi1.Size = New System.Drawing.Size(47, 21)
        Me.numi1.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(165, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 19)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "时"
        '
        'numh1
        '
        Me.numh1.Enabled = False
        Me.numh1.Location = New System.Drawing.Point(165, 39)
        Me.numh1.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.numh1.Name = "numh1"
        Me.numh1.Size = New System.Drawing.Size(47, 21)
        Me.numh1.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(112, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 19)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "日"
        '
        'numd1
        '
        Me.numd1.Enabled = False
        Me.numd1.Location = New System.Drawing.Point(112, 39)
        Me.numd1.Maximum = New Decimal(New Integer() {31, 0, 0, 0})
        Me.numd1.Name = "numd1"
        Me.numd1.Size = New System.Drawing.Size(47, 21)
        Me.numd1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(59, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 19)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "月"
        '
        'numm1
        '
        Me.numm1.Enabled = False
        Me.numm1.Location = New System.Drawing.Point(59, 39)
        Me.numm1.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.numm1.Name = "numm1"
        Me.numm1.Size = New System.Drawing.Size(47, 21)
        Me.numm1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "年"
        '
        'numy1
        '
        Me.numy1.Enabled = False
        Me.numy1.Location = New System.Drawing.Point(6, 39)
        Me.numy1.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numy1.Name = "numy1"
        Me.numy1.Size = New System.Drawing.Size(47, 21)
        Me.numy1.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.nums2)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.numi2)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.numh2)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.numd2)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.numm2)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.numy2)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 85)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(324, 67)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "定时时间"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(271, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 19)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "秒"
        '
        'nums2
        '
        Me.nums2.Location = New System.Drawing.Point(271, 39)
        Me.nums2.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.nums2.Name = "nums2"
        Me.nums2.Size = New System.Drawing.Size(47, 21)
        Me.nums2.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(218, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 19)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "分"
        '
        'numi2
        '
        Me.numi2.Location = New System.Drawing.Point(218, 39)
        Me.numi2.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.numi2.Name = "numi2"
        Me.numi2.Size = New System.Drawing.Size(47, 21)
        Me.numi2.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(165, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 19)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "时"
        '
        'numh2
        '
        Me.numh2.Location = New System.Drawing.Point(165, 39)
        Me.numh2.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.numh2.Name = "numh2"
        Me.numh2.Size = New System.Drawing.Size(47, 21)
        Me.numh2.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(112, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 19)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "日"
        '
        'numd2
        '
        Me.numd2.Location = New System.Drawing.Point(112, 39)
        Me.numd2.Maximum = New Decimal(New Integer() {31, 0, 0, 0})
        Me.numd2.Name = "numd2"
        Me.numd2.Size = New System.Drawing.Size(47, 21)
        Me.numd2.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(59, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 19)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "月"
        '
        'numm2
        '
        Me.numm2.Location = New System.Drawing.Point(59, 39)
        Me.numm2.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.numm2.Name = "numm2"
        Me.numm2.Size = New System.Drawing.Size(47, 21)
        Me.numm2.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(6, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 19)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "年"
        '
        'numy2
        '
        Me.numy2.Location = New System.Drawing.Point(6, 39)
        Me.numy2.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numy2.Name = "numy2"
        Me.numy2.Size = New System.Drawing.Size(47, 21)
        Me.numy2.TabIndex = 0
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(12, 164)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton1.TabIndex = 13
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "禁用"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(81, 164)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton2.TabIndex = 14
        Me.RadioButton2.Text = "提醒"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(150, 164)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton3.TabIndex = 15
        Me.RadioButton3.Text = "关机"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(219, 164)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton4.TabIndex = 16
        Me.RadioButton4.Text = "重启"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Location = New System.Drawing.Point(288, 164)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton5.TabIndex = 17
        Me.RadioButton5.Text = "休眠"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(348, 192)
        Me.Controls.Add(Me.RadioButton5)
        Me.Controls.Add(Me.RadioButton4)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "雅诗简易定时关机"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.nums1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numi1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numh1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numd1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numm1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numy1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.nums2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numi2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numh2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numd2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numm2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numy2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label6 As Label
    Friend WithEvents nums1 As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents numi1 As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents numh1 As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents numd1 As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents numm1 As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents numy1 As NumericUpDown
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents nums2 As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents numi2 As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents numh2 As NumericUpDown
    Friend WithEvents Label10 As Label
    Friend WithEvents numd2 As NumericUpDown
    Friend WithEvents Label11 As Label
    Friend WithEvents numm2 As NumericUpDown
    Friend WithEvents Label12 As Label
    Friend WithEvents numy2 As NumericUpDown
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents RadioButton5 As RadioButton
End Class
