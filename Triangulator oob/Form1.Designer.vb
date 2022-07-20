Namespace Triangulator
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
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

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabCanvas = New System.Windows.Forms.TabPage()
        Me.pboxCanvas = New System.Windows.Forms.PictureBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.OsmXmlTreeCnt1 = New OsmXmlTreeView.OsmXmlTreeCnt()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ClmCombos = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.btnNewMap = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chboxShowInfo = New System.Windows.Forms.CheckBox()
        Me.sbarSelectNokta = New System.Windows.Forms.HScrollBar()
        Me.ChkPolySel = New System.Windows.Forms.CheckBox()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.sbarAnim = New System.Windows.Forms.HScrollBar()
        Me.BtnSaveAnim = New System.Windows.Forms.Button()
        Me.BtnLoadAnim = New System.Windows.Forms.Button()
        Me.BtnClearAnim = New System.Windows.Forms.Button()
        Me.BtnJump = New System.Windows.Forms.Button()
        Me.TxtJump = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.chkImpLog = New System.Windows.Forms.CheckBox()
            Me.chkMove = New System.Windows.Forms.CheckBox()
            Me.BtnSave = New System.Windows.Forms.Button()
            Me.ListView2 = New System.Windows.Forms.ListView()
            Me.Kenarlar = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.TabControl1.SuspendLayout()
            Me.tabCanvas.SuspendLayout()
            CType(Me.pboxCanvas, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage2.SuspendLayout()
            CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage3.SuspendLayout()
            Me.TabPage4.SuspendLayout()
            Me.SuspendLayout()
            '
            'TabControl1
            '
            Me.TabControl1.Controls.Add(Me.tabCanvas)
            Me.TabControl1.Controls.Add(Me.TabPage2)
            Me.TabControl1.Controls.Add(Me.TabPage3)
            Me.TabControl1.Controls.Add(Me.TabPage4)
            Me.TabControl1.Location = New System.Drawing.Point(3, 12)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(822, 712)
            Me.TabControl1.TabIndex = 15
            '
            'tabCanvas
            '
            Me.tabCanvas.AutoScroll = True
            Me.tabCanvas.AutoScrollMargin = New System.Drawing.Size(9100, 8400)
            Me.tabCanvas.Controls.Add(Me.pboxCanvas)
            Me.tabCanvas.Location = New System.Drawing.Point(4, 22)
            Me.tabCanvas.Name = "tabCanvas"
            Me.tabCanvas.Padding = New System.Windows.Forms.Padding(3)
            Me.tabCanvas.Size = New System.Drawing.Size(814, 686)
            Me.tabCanvas.TabIndex = 0
            Me.tabCanvas.Text = "Canvas"
            Me.tabCanvas.UseVisualStyleBackColor = True
            '
            'pboxCanvas
            '
            Me.pboxCanvas.BackColor = System.Drawing.Color.White
            Me.pboxCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pboxCanvas.Location = New System.Drawing.Point(3, 3)
            Me.pboxCanvas.Name = "pboxCanvas"
            Me.pboxCanvas.Size = New System.Drawing.Size(6826, 6826)
            Me.pboxCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.pboxCanvas.TabIndex = 1
            Me.pboxCanvas.TabStop = False
            '
            'TabPage2
            '
            Me.TabPage2.Controls.Add(Me.PictureBox2)
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage2.Size = New System.Drawing.Size(814, 686)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "TabPage2"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'PictureBox2
            '
            Me.PictureBox2.BackColor = System.Drawing.Color.White
            Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PictureBox2.Location = New System.Drawing.Point(3, 3)
            Me.PictureBox2.Name = "PictureBox2"
            Me.PictureBox2.Size = New System.Drawing.Size(808, 680)
            Me.PictureBox2.TabIndex = 2
            Me.PictureBox2.TabStop = False
            '
            'TabPage3
            '
            Me.TabPage3.Controls.Add(Me.OsmXmlTreeCnt1)
            Me.TabPage3.Location = New System.Drawing.Point(4, 22)
            Me.TabPage3.Name = "TabPage3"
            Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage3.Size = New System.Drawing.Size(814, 686)
            Me.TabPage3.TabIndex = 2
            Me.TabPage3.Text = "TabPage3"
            Me.TabPage3.UseVisualStyleBackColor = True
            '
            'OsmXmlTreeCnt1
            '
            Me.OsmXmlTreeCnt1.HideSelection = False
            Me.OsmXmlTreeCnt1.Location = New System.Drawing.Point(-4, 0)
            Me.OsmXmlTreeCnt1.Name = "OsmXmlTreeCnt1"
            Me.OsmXmlTreeCnt1.Size = New System.Drawing.Size(370, 686)
            Me.OsmXmlTreeCnt1.TabIndex = 1
            '
            'TabPage4
            '
            Me.TabPage4.Controls.Add(Me.Button13)
            Me.TabPage4.Controls.Add(Me.Button12)
            Me.TabPage4.Controls.Add(Me.ListView1)
            Me.TabPage4.Location = New System.Drawing.Point(4, 22)
            Me.TabPage4.Margin = New System.Windows.Forms.Padding(2)
            Me.TabPage4.Name = "TabPage4"
            Me.TabPage4.Padding = New System.Windows.Forms.Padding(2)
            Me.TabPage4.Size = New System.Drawing.Size(814, 686)
            Me.TabPage4.TabIndex = 3
            Me.TabPage4.Text = "TabPage4"
            Me.TabPage4.UseVisualStyleBackColor = True
            '
            'Button13
            '
            Me.Button13.Location = New System.Drawing.Point(473, 34)
            Me.Button13.Name = "Button13"
            Me.Button13.Size = New System.Drawing.Size(75, 23)
            Me.Button13.TabIndex = 4
            Me.Button13.Text = "Test Of All"
            Me.Button13.UseVisualStyleBackColor = True
            '
            'Button12
            '
            Me.Button12.Location = New System.Drawing.Point(473, 5)
            Me.Button12.Name = "Button12"
            Me.Button12.Size = New System.Drawing.Size(75, 23)
            Me.Button12.TabIndex = 3
            Me.Button12.Text = "Button12"
            Me.Button12.UseVisualStyleBackColor = True
            '
            'ListView1
            '
            Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ClmCombos, Me.ColumnHeader3})
            Me.ListView1.GridLines = True
            Me.ListView1.HideSelection = False
            Me.ListView1.Location = New System.Drawing.Point(4, 4)
            Me.ListView1.Margin = New System.Windows.Forms.Padding(2)
            Me.ListView1.Name = "ListView1"
            Me.ListView1.Size = New System.Drawing.Size(451, 437)
            Me.ListView1.TabIndex = 2
            Me.ListView1.UseCompatibleStateImageBehavior = False
            Me.ListView1.View = System.Windows.Forms.View.Details
            '
            'ClmCombos
            '
            Me.ClmCombos.Text = "ClmCombos"
            Me.ClmCombos.Width = 315
            '
            'ColumnHeader3
            '
            Me.ColumnHeader3.Text = "Seq"
            '
            'btnNewMap
            '
            Me.btnNewMap.Location = New System.Drawing.Point(831, 34)
            Me.btnNewMap.Name = "btnNewMap"
            Me.btnNewMap.Size = New System.Drawing.Size(75, 23)
            Me.btnNewMap.TabIndex = 16
            Me.btnNewMap.Text = "New Map"
            Me.btnNewMap.UseVisualStyleBackColor = True
            '
            'Timer1
            '
            Me.Timer1.Interval = 200
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(0, 727)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(1056, 15)
            Me.Label1.TabIndex = 17
            Me.Label1.Text = "Label1"
            '
            'chboxShowInfo
            '
            Me.chboxShowInfo.AutoSize = True
            Me.chboxShowInfo.Location = New System.Drawing.Point(831, 273)
            Me.chboxShowInfo.Name = "chboxShowInfo"
            Me.chboxShowInfo.Size = New System.Drawing.Size(78, 17)
            Me.chboxShowInfo.TabIndex = 32
            Me.chboxShowInfo.Text = "Show infos"
            Me.chboxShowInfo.UseVisualStyleBackColor = True
            '
            'sbarSelectNokta
            '
            Me.sbarSelectNokta.LargeChange = 1
            Me.sbarSelectNokta.Location = New System.Drawing.Point(831, 449)
            Me.sbarSelectNokta.Name = "sbarSelectNokta"
            Me.sbarSelectNokta.Size = New System.Drawing.Size(157, 19)
            Me.sbarSelectNokta.TabIndex = 33
            '
            'ChkPolySel
            '
            Me.ChkPolySel.AutoSize = True
            Me.ChkPolySel.Location = New System.Drawing.Point(831, 250)
            Me.ChkPolySel.Name = "ChkPolySel"
            Me.ChkPolySel.Size = New System.Drawing.Size(97, 17)
            Me.ChkPolySel.TabIndex = 34
            Me.ChkPolySel.Text = "Polygon Select"
            Me.ChkPolySel.UseVisualStyleBackColor = True
            '
            'btnLoad
            '
            Me.btnLoad.Location = New System.Drawing.Point(913, 34)
            Me.btnLoad.Name = "btnLoad"
            Me.btnLoad.Size = New System.Drawing.Size(75, 23)
            Me.btnLoad.TabIndex = 35
            Me.btnLoad.Text = "Load Map"
            Me.btnLoad.UseVisualStyleBackColor = True
            '
            'OpenFileDialog1
            '
            Me.OpenFileDialog1.FileName = "OpenFileDialog1"
            '
            'sbarAnim
            '
            Me.sbarAnim.Location = New System.Drawing.Point(831, 188)
            Me.sbarAnim.Name = "sbarAnim"
            Me.sbarAnim.Size = New System.Drawing.Size(157, 19)
            Me.sbarAnim.TabIndex = 36
            '
            'BtnSaveAnim
            '
            Me.BtnSaveAnim.Location = New System.Drawing.Point(913, 133)
            Me.BtnSaveAnim.Name = "BtnSaveAnim"
            Me.BtnSaveAnim.Size = New System.Drawing.Size(75, 23)
            Me.BtnSaveAnim.TabIndex = 37
            Me.BtnSaveAnim.Text = "SaveAnim"
            Me.BtnSaveAnim.UseVisualStyleBackColor = True
            '
            'BtnLoadAnim
            '
            Me.BtnLoadAnim.Location = New System.Drawing.Point(913, 104)
            Me.BtnLoadAnim.Name = "BtnLoadAnim"
            Me.BtnLoadAnim.Size = New System.Drawing.Size(75, 23)
            Me.BtnLoadAnim.TabIndex = 38
            Me.BtnLoadAnim.Text = "LoadAnim"
            Me.BtnLoadAnim.UseVisualStyleBackColor = True
            '
            'BtnClearAnim
            '
            Me.BtnClearAnim.Location = New System.Drawing.Point(831, 104)
            Me.BtnClearAnim.Name = "BtnClearAnim"
            Me.BtnClearAnim.Size = New System.Drawing.Size(75, 23)
            Me.BtnClearAnim.TabIndex = 39
            Me.BtnClearAnim.Text = "ClearAnim"
            Me.BtnClearAnim.UseVisualStyleBackColor = True
            '
            'BtnJump
            '
            Me.BtnJump.Location = New System.Drawing.Point(913, 162)
            Me.BtnJump.Name = "BtnJump"
            Me.BtnJump.Size = New System.Drawing.Size(75, 23)
            Me.BtnJump.TabIndex = 40
            Me.BtnJump.Text = "JumpFrame"
            Me.BtnJump.UseVisualStyleBackColor = True
            '
            'TxtJump
            '
            Me.TxtJump.Location = New System.Drawing.Point(831, 162)
            Me.TxtJump.Name = "TxtJump"
            Me.TxtJump.Size = New System.Drawing.Size(75, 20)
            Me.TxtJump.TabIndex = 41
            '
            'chkImpLog
            '
            Me.chkImpLog.AutoSize = True
            Me.chkImpLog.Location = New System.Drawing.Point(831, 296)
            Me.chkImpLog.Name = "chkImpLog"
            Me.chkImpLog.Size = New System.Drawing.Size(84, 17)
            Me.chkImpLog.TabIndex = 42
            Me.chkImpLog.Text = "Log Impacts"
            Me.chkImpLog.UseVisualStyleBackColor = True
            '
            'chkMove
            '
            Me.chkMove.AutoSize = True
            Me.chkMove.Location = New System.Drawing.Point(831, 319)
            Me.chkMove.Name = "chkMove"
            Me.chkMove.Size = New System.Drawing.Size(114, 17)
            Me.chkMove.TabIndex = 43
            Me.chkMove.Text = "Log Mouse Moves"
            Me.chkMove.UseVisualStyleBackColor = True
            '
            'BtnSave
            '
            Me.BtnSave.Location = New System.Drawing.Point(913, 63)
            Me.BtnSave.Name = "BtnSave"
            Me.BtnSave.Size = New System.Drawing.Size(75, 23)
            Me.BtnSave.TabIndex = 44
            Me.BtnSave.Text = "SaveMap"
            Me.BtnSave.UseVisualStyleBackColor = True
            '
            'ListView2
            '
            Me.ListView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Kenarlar})
            Me.ListView2.GridLines = True
            Me.ListView2.HideSelection = False
            Me.ListView2.Location = New System.Drawing.Point(832, 484)
            Me.ListView2.Name = "ListView2"
            Me.ListView2.Size = New System.Drawing.Size(155, 216)
            Me.ListView2.TabIndex = 45
            Me.ListView2.UseCompatibleStateImageBehavior = False
            Me.ListView2.View = System.Windows.Forms.View.Details
            '
            'Form1
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1004, 770)
            Me.Controls.Add(Me.ListView2)
            Me.Controls.Add(Me.BtnSave)
            Me.Controls.Add(Me.chkMove)
            Me.Controls.Add(Me.chkImpLog)
            Me.Controls.Add(Me.TxtJump)
            Me.Controls.Add(Me.BtnJump)
            Me.Controls.Add(Me.BtnClearAnim)
            Me.Controls.Add(Me.BtnLoadAnim)
            Me.Controls.Add(Me.BtnSaveAnim)
        Me.Controls.Add(Me.sbarAnim)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.ChkPolySel)
        Me.Controls.Add(Me.sbarSelectNokta)
        Me.Controls.Add(Me.chboxShowInfo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnNewMap)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.TabControl1.ResumeLayout(false)
        Me.tabCanvas.ResumeLayout(false)
        CType(Me.pboxCanvas,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabPage2.ResumeLayout(false)
        CType(Me.PictureBox2,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabPage3.ResumeLayout(false)
        Me.TabPage4.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents tabCanvas As System.Windows.Forms.TabPage
        Friend WithEvents pboxCanvas As System.Windows.Forms.PictureBox
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
        Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
        Friend WithEvents Button13 As System.Windows.Forms.Button
        Friend WithEvents Button12 As System.Windows.Forms.Button
        Friend WithEvents ListView1 As System.Windows.Forms.ListView
        Friend WithEvents ClmCombos As System.Windows.Forms.ColumnHeader
        Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
        Friend WithEvents btnNewMap As System.Windows.Forms.Button
        Friend WithEvents Timer1 As System.Windows.Forms.Timer
        Friend WithEvents OsmXmlTreeCnt1 As OsmXmlTreeView.OsmXmlTreeCnt
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents chboxShowInfo As System.Windows.Forms.CheckBox

        Public Sub New()


            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Friend WithEvents sbarSelectNokta As System.Windows.Forms.HScrollBar
        Friend WithEvents ChkPolySel As System.Windows.Forms.CheckBox
        Friend WithEvents btnLoad As System.Windows.Forms.Button
        Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
        Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
        Friend WithEvents sbarAnim As System.Windows.Forms.HScrollBar
        Friend WithEvents BtnSaveAnim As System.Windows.Forms.Button
        Friend WithEvents BtnLoadAnim As System.Windows.Forms.Button
        Friend WithEvents BtnClearAnim As System.Windows.Forms.Button
        Friend WithEvents BtnJump As System.Windows.Forms.Button
        Friend WithEvents TxtJump As System.Windows.Forms.TextBox
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents chkImpLog As System.Windows.Forms.CheckBox
        Friend WithEvents chkMove As System.Windows.Forms.CheckBox
        Friend WithEvents BtnSave As System.Windows.Forms.Button
        Friend WithEvents ListView2 As ListView
        Friend WithEvents Kenarlar As ColumnHeader
    End Class
End Namespace