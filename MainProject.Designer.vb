<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainProject
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.XMLTextBox = New System.Windows.Forms.TextBox()
        Me.lang_ComboBox = New System.Windows.Forms.ComboBox()
        Me.ExtractButton = New System.Windows.Forms.Button()
        Me.XMLPathTextBox = New System.Windows.Forms.TextBox()
        Me.XMLPathButton = New System.Windows.Forms.Button()
        Me.sfd = New System.Windows.Forms.SaveFileDialog()
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.BGW_ExML = New System.ComponentModel.BackgroundWorker()
        Me.ioGroupBox = New System.Windows.Forms.GroupBox()
        Me.outRadioButton = New System.Windows.Forms.RadioButton()
        Me.inRadioButton = New System.Windows.Forms.RadioButton()
        Me.ioGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'XMLTextBox
        '
        Me.XMLTextBox.Location = New System.Drawing.Point(33, 42)
        Me.XMLTextBox.Name = "XMLTextBox"
        Me.XMLTextBox.Size = New System.Drawing.Size(406, 21)
        Me.XMLTextBox.TabIndex = 0
        '
        'lang_ComboBox
        '
        Me.lang_ComboBox.FormattingEnabled = True
        Me.lang_ComboBox.Items.AddRange(New Object() {"English (영어)", "Korean (한국어)"})
        Me.lang_ComboBox.Location = New System.Drawing.Point(350, 232)
        Me.lang_ComboBox.Name = "lang_ComboBox"
        Me.lang_ComboBox.Size = New System.Drawing.Size(114, 20)
        Me.lang_ComboBox.TabIndex = 1
        Me.lang_ComboBox.Text = "English (영어)"
        '
        'ExtractButton
        '
        Me.ExtractButton.Font = New System.Drawing.Font("나눔바른고딕OTF", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ExtractButton.Location = New System.Drawing.Point(33, 84)
        Me.ExtractButton.Name = "ExtractButton"
        Me.ExtractButton.Size = New System.Drawing.Size(406, 98)
        Me.ExtractButton.TabIndex = 2
        Me.ExtractButton.Text = "Extract!"
        Me.ExtractButton.UseVisualStyleBackColor = True
        '
        'XMLPathTextBox
        '
        Me.XMLPathTextBox.Location = New System.Drawing.Point(12, 231)
        Me.XMLPathTextBox.Name = "XMLPathTextBox"
        Me.XMLPathTextBox.Size = New System.Drawing.Size(146, 21)
        Me.XMLPathTextBox.TabIndex = 3
        Me.XMLPathTextBox.Text = "C:\test.xml"
        '
        'XMLPathButton
        '
        Me.XMLPathButton.Location = New System.Drawing.Point(164, 231)
        Me.XMLPathButton.Name = "XMLPathButton"
        Me.XMLPathButton.Size = New System.Drawing.Size(31, 22)
        Me.XMLPathButton.TabIndex = 4
        Me.XMLPathButton.Text = "..."
        Me.XMLPathButton.UseVisualStyleBackColor = True
        '
        'sfd
        '
        Me.sfd.DefaultExt = "xml"
        Me.sfd.Filter = "XML File|*.xml"
        Me.sfd.Title = "Save The XML File!"
        '
        'ofd
        '
        Me.ofd.Filter = "XML File|*.xml"
        Me.ofd.Title = "Open The XML File!"
        '
        'BGW_ExML
        '
        '
        'ioGroupBox
        '
        Me.ioGroupBox.Controls.Add(Me.outRadioButton)
        Me.ioGroupBox.Controls.Add(Me.inRadioButton)
        Me.ioGroupBox.Location = New System.Drawing.Point(201, 188)
        Me.ioGroupBox.Name = "ioGroupBox"
        Me.ioGroupBox.Size = New System.Drawing.Size(143, 65)
        Me.ioGroupBox.TabIndex = 5
        Me.ioGroupBox.TabStop = False
        Me.ioGroupBox.Text = "In / Out"
        '
        'outRadioButton
        '
        Me.outRadioButton.AutoSize = True
        Me.outRadioButton.Location = New System.Drawing.Point(5, 42)
        Me.outRadioButton.Name = "outRadioButton"
        Me.outRadioButton.Size = New System.Drawing.Size(134, 16)
        Me.outRadioButton.TabIndex = 1
        Me.outRadioButton.TabStop = True
        Me.outRadioButton.Text = "Extract 'Out Nodes'"
        Me.outRadioButton.UseVisualStyleBackColor = True
        '
        'inRadioButton
        '
        Me.inRadioButton.AutoSize = True
        Me.inRadioButton.Location = New System.Drawing.Point(6, 20)
        Me.inRadioButton.Name = "inRadioButton"
        Me.inRadioButton.Size = New System.Drawing.Size(125, 16)
        Me.inRadioButton.TabIndex = 0
        Me.inRadioButton.TabStop = True
        Me.inRadioButton.Text = "Extract 'In Nodes'"
        Me.inRadioButton.UseVisualStyleBackColor = True
        '
        'MainProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 263)
        Me.Controls.Add(Me.ioGroupBox)
        Me.Controls.Add(Me.XMLPathButton)
        Me.Controls.Add(Me.XMLPathTextBox)
        Me.Controls.Add(Me.ExtractButton)
        Me.Controls.Add(Me.lang_ComboBox)
        Me.Controls.Add(Me.XMLTextBox)
        Me.Name = "MainProject"
        Me.Text = "XMLEx Final"
        Me.ioGroupBox.ResumeLayout(False)
        Me.ioGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents XMLTextBox As TextBox
    Friend WithEvents lang_ComboBox As ComboBox
    Friend WithEvents ExtractButton As Button
    Friend WithEvents XMLPathTextBox As TextBox
    Friend WithEvents XMLPathButton As Button
    Friend WithEvents sfd As SaveFileDialog
    Friend WithEvents ofd As OpenFileDialog
    Friend WithEvents BGW_ExML As System.ComponentModel.BackgroundWorker
    Friend WithEvents ioGroupBox As GroupBox
    Friend WithEvents outRadioButton As RadioButton
    Friend WithEvents inRadioButton As RadioButton
End Class
