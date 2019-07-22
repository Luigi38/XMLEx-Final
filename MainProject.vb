Imports System.ComponentModel
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Xml

Public Class MainProject

    ''' <summary>
    ''' Settings XML. (설정 XML.)
    ''' </summary>
    Public Shared setxml As New XmlDocument
    ''' <summary>
    ''' Settings 'XML'...
    ''' </summary>
    Public Shared setaNode As XmlNode
    ''' <summary>
    '''Settings XML Path. (설정 XML 경로.)
    ''' </summary>
    Public Shared settings_i As String = Application.StartupPath & "\settings.xml"

    ''' <summary>
    ''' Loading XML Path. (XML 경로.)
    ''' </summary>
    Public Shared XML_info As String = String.Empty
    ''' <summary>
    ''' Language. (언어.)
    ''' </summary>
    Public Shared Lang As CultureInfo
    ''' <summary>
    ''' In/Out Nodes. (True: In Nodes, False: Out Nodes)
    ''' </summary>
    Public ioNodes As Boolean

    ''' <summary>
    ''' 따로 저장 여부.
    ''' </summary>
    Public DDaroSaved As Boolean = False

    Private trd_FileName As String = String.Empty
    Private truly_sFileName As String = String.Empty

    Private Sub MainProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            'Exceptions.
            If Not File.Exists(settings_i) Then
                Throw New FileNotFoundException("'settings.xml' file doesn't found.")
                Application.Exit()
            End If

            setxml.Load(settings_i)
            setaNode = setxml.SelectSingleNode("/XMLEx-Settings")

            If setaNode IsNot Nothing Then

                XML_info = setaNode.ChildNodes(0).InnerText
                If Not XML_info = "N/A" Then
                    XMLPathTextBox.Text = XML_info
                Else
                    XML_info = String.Empty
                    XMLPathTextBox.Text = String.Empty
                End If

                Select Case setaNode.ChildNodes(1).InnerText
                    Case "English"
                        Lang = New CultureInfo("en-US")
                        lang_ComboBox.Text = "English (영어)"
                    Case "Korean"
                        Lang = New CultureInfo("ko-KR")
                        lang_ComboBox.Text = "Korean (한국어)"
                    Case Else
                        lang_ComboBox.Text = "English"
                        Throw New CultureNotFoundException("We can't translate that culture name.")
                End Select

                Select Case setaNode.ChildNodes(2).InnerText
                    Case "InNodes"
                        ioNodes = True
                        inRadioButton.Checked = True
                    Case "OutNodes"
                        ioNodes = False
                        outRadioButton.Checked = True
                End Select

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & ex.StackTrace, Me.Text & ": Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExtractButton_Click(sender As Object, e As EventArgs) Handles ExtractButton.Click
        Try

            If String.IsNullOrEmpty(XML_info) Then Throw New ArgumentNullException("Please select the xml file.")
            If String.IsNullOrWhiteSpace(XMLTextBox.Text) Then Throw New ArgumentNullException("Please write the Node Name.")

            BGW_ExML.RunWorkerAsync()

        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & ex.StackTrace, Me.Text & ": Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExtractButton_DoubleClick(sender As Object, e As EventArgs) Handles ExtractButton.DoubleClick
        Try

            If String.IsNullOrEmpty(XML_info) Then Throw New ArgumentNullException("Please select the xml file.")
            If String.IsNullOrWhiteSpace(XMLTextBox.Text) Then Throw New ArgumentNullException("Please write the Node Name.")

            SaveIn_Ex()

        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & ex.StackTrace, Me.Text & ": Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveIn_Ex()
        Try

            If sfd.ShowDialog() = DialogResult.OK Then
                trd_FileName = sfd.FileName
                DDaroSaved = True
                BGW_ExML.RunWorkerAsync()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & ex.StackTrace, Me.Text & ": Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BGW_ExML_DoWork(sender As Object, e As DoWorkEventArgs) Handles BGW_ExML.DoWork
        Try

            Loading.Show()
            Loading.Text = Me.Text & ": Extracting XML..."
            Loading.DLb.Text = "Loading The XML File..."
            Loading.DLb.Refresh()
            Loading.DPr.Style = ProgressBarStyle.Marquee
            Loading.DPr.Refresh()

            Dim s As String() = XMLTextBox.Text.Split(" ")
            Dim doc As New XmlDocument
            Dim NewElementList As XmlNodeList
            doc.Load(XML_info)
            Dim str As String = String.Empty
            truly_sFileName = Path.GetFileNameWithoutExtension(XML_info)

            If ioNodes Then

                For i As Integer = 0 To s.Count - 1
                    Dim curri As Integer

                    If i > 0 Then
                        Dim p As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\tmp_xmlin.xml"
                        File.WriteAllText(p, str)
                        doc.Load(p)
                        str = String.Empty
                    End If

                    NewElementList = doc.GetElementsByTagName(s(i))
                    If i = 0 Then
                        Loading.DPr.Maximum = s.Count * NewElementList.Count
                        Loading.DPr.Refresh()
                        Loading.DLb.Text = "Extracting XML Nodes..."
                        Loading.DLb.Refresh()
                    End If

                    For Each x As XmlNode In NewElementList
                        str = str & vbNewLine & x.InnerXml
                        curri += 1
                        Loading.DLb.Text = String.Format("Extracting XML Nodes... ({0}/{1})", curri, Loading.DPr.Maximum)
                        Loading.DLb.Left = Loading.DLb.Left - 50
                        Loading.DLb.Refresh()
                        Loading.DPr.Style = ProgressBarStyle.Continuous
                        Loading.DPr.Value = curri
                        Loading.DPr.Refresh()
                    Next

                Next

            ElseIf ioNodes = False Then

                For i As Integer = 0 To s.Count - 1

                    Dim crrui As Integer
                    str = String.Empty
                    NewElementList = doc.GetElementsByTagName(s(i))
                    If i = 0 Then
                        Loading.DPr.Maximum = s.Count * NewElementList.Count
                        Loading.DPr.Refresh()
                        Loading.DLb.Text = "Extracting XML Nodes..."
                        Loading.DLb.Refresh()
                    End If

                    For Each x As XmlNode In NewElementList
                        str = str & vbNewLine & x.OuterXml
                        crrui += 1
                        Loading.DLb.Text = String.Format("Extracting XML Nodes... ({0}/{1})", crrui, Loading.DPr.Maximum)
                        Loading.DLb.Left = Loading.DLb.Left - 50
                        Loading.DLb.Refresh()
                        Loading.DPr.Style = ProgressBarStyle.Continuous
                        Loading.DPr.Value = crrui
                        Loading.DPr.Refresh()
                    Next

                    Dim d As Boolean = False
                    Dim q As Integer = 0
                    While d = True
                        q += 1
                        d = Not File.Exists(String.Format("{0}\{1}_{2}.xml", Application.StartupPath, truly_sFileName, q))
                    End While
                    File.WriteAllText(String.Format("{0}\{1}_{2}.xml", Application.StartupPath, truly_sFileName, q + 1), str, Encoding.UTF8)

                Next
            End If

            If String.IsNullOrWhiteSpace(str) Then
                Throw New ArgumentNullException("There is no ChildNodes. Please Try again!")
            End If

            If ioNodes Then 'InNodes 전용 File Write.
                Dim d As Boolean = False
                Dim q As Integer = 0
                While d = True
                    q += 1
                    d = Not File.Exists(String.Format("{0}\{1}_{2}.xml", Application.StartupPath, truly_sFileName, q))
                End While
                File.WriteAllText(String.Format("{0}\{1}_{2}.xml", Application.StartupPath, truly_sFileName, q + 1), str, Encoding.UTF8)
            End If

            Loading.Dispose()
            MessageBox.Show("XML Extracted!", Me.Text & ": Extracted", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & ex.StackTrace, Me.Text & ": Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub XMLPathButton_Click(sender As Object, e As EventArgs) Handles XMLPathButton.Click
        Try

            If ofd.ShowDialog() = DialogResult.OK Then
                XMLPathTextBox.Text = ofd.FileName
                XML_info = ofd.FileName

                If setaNode IsNot Nothing Then
                    setaNode.ChildNodes(0).InnerText = XML_info
                    setxml.Save(settings_i)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & ex.StackTrace, Me.Text & ": Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Lang_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lang_ComboBox.SelectedIndexChanged
        Try

            If setaNode IsNot Nothing Then
                Dim s As String = lang_ComboBox.Text
                Select Case s
                    Case "English (영어)"
                        Lang = New CultureInfo("en-US")
                        setaNode.ChildNodes(1).InnerText = "English"
                    Case "Korean (한국어)"
                        Lang = New CultureInfo("ko-KR")
                        setaNode.ChildNodes(1).InnerText = "Korean"
                    Case Else
                        Throw New NullReferenceException("Something went wrong...")
                End Select
                setxml.Save(settings_i)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & ex.StackTrace, Me.Text & ": Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles inRadioButton.CheckedChanged
        Try

            If setaNode IsNot Nothing Then
                If inRadioButton.Checked Then
                    ioNodes = True
                    setaNode.ChildNodes(2).InnerText = "InNodes"
                ElseIf outRadioButton.Checked Then
                    ioNodes = False
                    setaNode.ChildNodes(2).InnerText = "OutNodes"
                Else
                    Throw New NullReferenceException("Something went wrong...")
                End If
                setxml.Save(settings_i)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & ex.StackTrace, Me.Text & ": Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
