Imports System.IO
Imports System.Drawing.Imaging
Imports System.Data.SqlClient

Public Class frmOutlookShortcuts
    Dim isshortcutselected As Boolean = False
    Dim selectedindex As Int16 = -1
    Dim _buttonArray As ArrayList
    Dim clsoutlookcontrol As New clsOutlookControls
    Dim extension As String = String.Empty
    Dim strMood As String

    Public Sub New(ByVal buttonArray As ArrayList)
        InitializeComponent()
        Me._buttonArray = buttonArray
        Dim cutomoutlookbuttons As New OutlookStyleControls.OutlookBarButton
        Dim clsoutlookcontrol As New clsOutlookControls
        PropertyGrid1.SelectedObject = cutomoutlookbuttons
    End Sub
    Private Sub frmOutlookShortcuts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            For Each obj As OutlookStyleControls.OutlookBarButton In _buttonArray
                lstButtons.Items.Add(New OutlookButtonList(obj.Text, obj.ShortcutType, obj.ShortcutFor, obj.LinkTo, obj))
            Next
            '---------obaidul-------
            '' when form load create and delete button will be disable
            btnRemoveOutlookbutton.Enabled = False
            btnCreateShortcut.Enabled = False
            btnOk.Visible = False
            strMood = "I"
            btnClear.Visible = True
            btnCancel.Enabled = False
            '-------------------
            lstButtons.DisplayMember = "getButtonShortcut"
            lstButtons.ValueMember = "getButton"
            txtShortcutname.Enabled = False
            radProgram.Enabled = False
            radReport.Enabled = False
            radCustom.Enabled = False
            radDocument.Enabled = False
            btnCreateShortcut.Enabled = False
            btnImages.Enabled = False
            btnChooseShortcuts.Enabled = False
            btnOk.Enabled = False
            ofdIcon.Title = "Open Image Files"
            ofdIcon.Filter = "Icon Files (*.ico)|*.ico|Png Files (*.png)|*.png"
            ofdFile.Title = "Open Files"
            ofdFile.Filter = "Document(*.doc,*.docx)|*.doc;*.docx|Excel(*.xls,*.xlsx)|*.xls;*.xlsx|PDF(*.pdf)|*.pdf"
        Catch ex As Exception
            oExcelSS.ErrorLog("frmOutlookShortcuts_Load Error##" + ex.Message.ToString())
        End Try
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        relaodOutlookBar()
        Me.Close()
    End Sub
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Try
            oExcelSS.isOutlookButtonBinded = True
            Dim dt As New DataTable("TableShortcuts")
            dt.Columns.Add("ShortcutType", GetType(String))
            dt.Columns.Add("ShortcutName", GetType(String))
            dt.Columns.Add("ShortcutFor", GetType(String))
            dt.Columns.Add("Linkto", GetType(String))
            dt.Columns.Add("IconImage", GetType(Byte()))
            dt.Columns.Add("Parameters", GetType(String))
            oExcelSS.arrayOutlookButtons = New ArrayList
            For Each itm As Object In lstButtons.Items
                oExcelSS.arrayOutlookButtons.Add(New OutlookButtonList(itm.getButtonShortcut, itm.shortcutType, itm.ShortcutFor, itm.getLinkTo, itm.getButton))
                Dim dr As DataRow = dt.NewRow
                Dim obj As Object = itm.getButton
                dr(0) = Convert.ToString(itm.getShortcutType())
                dr(1) = Convert.ToString(itm.getButtonShortcut())
                dr(2) = Convert.ToString(itm.getShortcutFor())
                dr(3) = Convert.ToString(itm.getLinkTo())
                '--- Paramters for feature entry as per the mail date 10-06-13
                dr("Parameters") = String.Empty
                '-----------------------
                Dim nimage As Image = obj.Image
                If Not nimage Is Nothing Then
                    Dim originalFormat As System.Drawing.Imaging.ImageFormat = nimage.RawFormat
                    If ImageFormat.Jpeg.Equals(nimage.RawFormat) Then
                        originalFormat = ImageFormat.Jpeg
                    ElseIf ImageFormat.Bmp.Equals(nimage.RawFormat) Then
                        originalFormat = ImageFormat.Bmp
                    ElseIf ImageFormat.Emf.Equals(nimage.RawFormat) Then
                        originalFormat = ImageFormat.Emf
                    ElseIf ImageFormat.Exif.Equals(nimage.RawFormat) Then
                        originalFormat = ImageFormat.Exif
                    ElseIf ImageFormat.Gif.Equals(nimage.RawFormat) Then
                        originalFormat = ImageFormat.Gif
                    ElseIf ImageFormat.Icon.Equals(nimage.RawFormat) Then
                        originalFormat = ImageFormat.Icon
                    ElseIf ImageFormat.MemoryBmp.Equals(nimage.RawFormat) Then
                        originalFormat = ImageFormat.MemoryBmp
                    ElseIf ImageFormat.Png.Equals(nimage.RawFormat) Then
                        originalFormat = ImageFormat.Png
                    ElseIf ImageFormat.Tiff.Equals(nimage.RawFormat) Then
                        originalFormat = ImageFormat.Tiff
                    ElseIf ImageFormat.Wmf.Equals(nimage.RawFormat) Then
                        originalFormat = ImageFormat.Wmf
                    End If
                    Using ms As MemoryStream = New MemoryStream
                        nimage.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                        dr(4) = ms.ToArray
                    End Using
                Else
                    dr(4) = Nothing
                End If
                dt.Rows.Add(dr)
            Next
            Dim param As String(,) = New String(,) {
                                                    {"@intUserIDKey", oExcelSS.userid},
                                                    {"@strUserID", oExcelSS.ActiveUserID}
                                                  }
            Dim status As Boolean = oExcelSS.isSavedData("uspAccess_InsertShortcut", "@tblShortcut", dt, param, "@strStatus")
            Me.Close()
        Catch ex As Exception
            oExcelSS.ErrorLog("btnOk_Click Error##" + ex.Message.ToString())
        End Try
    End Sub
    Private Function isImageExist(ByVal fileName As String) As Boolean
        Dim fexist As Boolean = False
        Try
            If File.Exists(fileName) Then
                fexist = True
            Else
                fexist = False
            End If
        Catch ex As Exception
            fexist = False
        End Try
        Return fexist
    End Function
    Private Sub btnCreateShortcut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateShortcut.Click
        Try
            If txtShortcutname.Text = "" Then
                MsgBox("Shortcut Name should not be empty!", MsgBoxStyle.Information, "DMAC")
                txtShortcutname.Focus()
                Exit Sub
            End If
            If txtLinkto.Text = "" Then
                MsgBox("The link for shortcut should not be empty!", MsgBoxStyle.Information, "DMAC")
                ' txtLinkto.Focus()
                btnChooseShortcuts.Focus()
                Exit Sub
            End If
            ''Check whether it is update or not
            If (btnCreateShortcut.Text = "Update Shortcut") Then
                If MsgBox("Do you want to make update", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "DMAC") = MsgBoxResult.Yes Then
                    '  btnCreateShortcut_Click(sender, e)
                End If
            End If
            Dim btn As New OutlookStyleControls.OutlookBarButton
            btn.Text = txtShortcutname.Text
            btn.Image = PictureBox1.Image
            If isshortcutselected AndAlso selectedindex >= 0 Then
                lstButtons.Items.RemoveAt(selectedindex)
                selectedindex = -1
            End If
            btn.ShortcutFor = oExcelSS.selectedShortcutFromList
            btn.LinkTo = oExcelSS.selectedShortcutFromListTag
            Dim shortcutType As String = String.Empty
            If radCustom.Checked Then
                shortcutType = "Custom"
            ElseIf radProgram.Checked Then
                shortcutType = "Program"
            ElseIf radReport.Checked Then
                shortcutType = "Report"
            ElseIf radDocument.Checked Then
                shortcutType = "Document" & IIf(extension <> "", " -" & extension, "")
            End If
            lstButtons.Items.Add(New OutlookButtonList(txtShortcutname.Text, shortcutType, oExcelSS.selectedShortcutFromList, oExcelSS.selectedShortcutFromListTag, btn))
            lstButtons.SelectedIndex = lstButtons.Items.Count - 1
            PictureBox1.Image = Nothing
            txtShortcutname.Text = String.Empty
            oExcelSS.selectedShortcutFromList = String.Empty
            txtLinkto.Text = String.Empty
            btnImages.Enabled = True
            btnChooseShortcuts.Enabled = True
            btnNewShortcut.Enabled = True
            btnCreateShortcut.Text = "Create Shortcut"
            btnCreateShortcut.Enabled = False
            txtShortcutname.Enabled = False
            isshortcutselected = False
            btnOk.Enabled = True
            btnChooseShortcuts.Enabled = False
            btnImages.Enabled = False

            ' added on obaidul-------
            refreshOutlookbar()
            ' btnOk.PerformClick()

            btnRemoveOutlookbutton.Enabled = False
            btnCreateShortcut.Enabled = False
            btnClose.Enabled = True
            btnCancel.Enabled = False
            '--------end ----by obaidul

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub refreshOutlookbar()
        Try
            oExcelSS.isOutlookButtonBinded = True
            Dim dt As New DataTable("TableShortcuts")
            dt.Columns.Add("ShortcutType", GetType(String))
            dt.Columns.Add("ShortcutName", GetType(String))
            dt.Columns.Add("ShortcutFor", GetType(String))
            dt.Columns.Add("Linkto", GetType(String))
            dt.Columns.Add("IconImage", GetType(Byte()))
            dt.Columns.Add("Parameters", GetType(String))
            oExcelSS.arrayOutlookButtons = New ArrayList
            For Each itm As Object In lstButtons.Items
                oExcelSS.arrayOutlookButtons.Add(New OutlookButtonList(itm.getButtonShortcut, itm.shortcutType, itm.ShortcutFor, itm.getLinkTo, itm.getButton))
                Dim dr As DataRow = dt.NewRow
                Dim obj As Object = itm.getButton
                dr(0) = Convert.ToString(itm.getShortcutType())
                dr(1) = Convert.ToString(itm.getButtonShortcut())
                dr(2) = Convert.ToString(itm.getShortcutFor())
                dr(3) = Convert.ToString(itm.getLinkTo())
                '--- Paramters for feature entry as per the mail date 10-06-13
                dr("Parameters") = String.Empty
                '-----------------------
                Dim nimage As Image = obj.Image
                If Not nimage Is Nothing Then
                    Dim originalFormat As System.Drawing.Imaging.ImageFormat = nimage.RawFormat
                    If ImageFormat.Jpeg.Equals(nimage.RawFormat) Then
                        originalFormat = ImageFormat.Jpeg
                    ElseIf ImageFormat.Bmp.Equals(nimage.RawFormat) Then
                        originalFormat = ImageFormat.Bmp
                    ElseIf ImageFormat.Emf.Equals(nimage.RawFormat) Then
                        originalFormat = ImageFormat.Emf
                    ElseIf ImageFormat.Exif.Equals(nimage.RawFormat) Then
                        originalFormat = ImageFormat.Exif
                    ElseIf ImageFormat.Gif.Equals(nimage.RawFormat) Then
                        originalFormat = ImageFormat.Gif
                    ElseIf ImageFormat.Icon.Equals(nimage.RawFormat) Then
                        originalFormat = ImageFormat.Icon
                    ElseIf ImageFormat.MemoryBmp.Equals(nimage.RawFormat) Then
                        originalFormat = ImageFormat.MemoryBmp
                    ElseIf ImageFormat.Png.Equals(nimage.RawFormat) Then
                        originalFormat = ImageFormat.Png
                    ElseIf ImageFormat.Tiff.Equals(nimage.RawFormat) Then
                        originalFormat = ImageFormat.Tiff
                    ElseIf ImageFormat.Wmf.Equals(nimage.RawFormat) Then
                        originalFormat = ImageFormat.Wmf
                    End If
                    Using ms As MemoryStream = New MemoryStream
                        nimage.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                        dr(4) = ms.ToArray
                    End Using
                Else
                    dr(4) = Nothing
                End If


                dt.Rows.Add(dr)
            Next
            Dim param As String(,) = New String(,) {
                                                    {"@intUserIDKey", oExcelSS.userid},
                                                    {"@strUserID", oExcelSS.ActiveUserID}
                                                  }
            Dim status As Boolean = oExcelSS.isSavedData("uspDmac_InsertShortcut", "@tblShortcut", dt, param, "@strStatus")
            relaodOutlookBar()
        Catch ex As Exception
            oExcelSS.ErrorLog("btnOk_Click Error##" + ex.Message.ToString())
        End Try
    End Sub
    Private Sub relaodOutlookBar()
        oExcelSS.dtShortcut.Clear()
        oExcelSS.dtShortcut = New DataTable("tblShortcut")
        Dim paramsql As SqlParameter() = New SqlParameter(0) {}
        paramsql(0) = New SqlParameter("@intUserIDKey", oExcelSS.userid)
        oExcelSS.dtShortcut = oExcelSS.getDataTable("uspDmac_GetShortcut", True, paramsql)
    End Sub
    Public Sub refreshShortcutButton()
        oExcelSS.dtShortcut.Clear()
        oExcelSS.dtShortcut = New DataTable("tblShortcut")
        Dim paramsql As SqlParameter() = New SqlParameter(0) {}
        paramsql(0) = New SqlParameter("@intUserIDKey", oExcelSS.userid)
        oExcelSS.dtShortcut = oExcelSS.getDataTable("uspDmac_GetShortcut", True, paramsql)
        oExcelSS.arrayOutlookButtons = New ArrayList
        For Each itm As Object In lstButtons.Items
            oExcelSS.arrayOutlookButtons.Add(New OutlookButtonList(itm.getButtonShortcut, itm.shortcutType, itm.ShortcutFor, itm.getLinkTo, itm.getButton))
        Next
    End Sub
    Private Sub lstButtons_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstButtons.SelectedIndexChanged
        Try
            If Not lstButtons.SelectedItem Is Nothing Then
                Dim selection As OutlookButtonList = DirectCast(lstButtons.SelectedItem, OutlookButtonList)
                PropertyGrid1.SelectedObject = selection
                radCustom.Enabled = False
                radDocument.Enabled = False
                radProgram.Enabled = False
                radReport.Enabled = False
                If Convert.ToString(selection.getButtonShortcut()) <> "" Then
                    selectedindex = lstButtons.SelectedIndex
                    btnNewShortcut.Enabled = False
                    btnRemoveOutlookbutton.Enabled = True
                    btnCreateShortcut.Enabled = True
                    btnCreateShortcut.Text = "Update Shortcut"
                    isshortcutselected = True
                    txtShortcutname.Enabled = True
                    btnImages.Enabled = True
                    btnChooseShortcuts.Enabled = True
                    txtShortcutname.Text = Convert.ToString(selection.getButtonShortcut())
                    txtLinkto.Text = Convert.ToString(selection.getShortcutFor())
                    oExcelSS.selectedShortcutFromList = Convert.ToString(selection.getShortcutFor())
                    oExcelSS.selectedShortcutFromListTag = Convert.ToString(selection.getLinkTo())
                    Dim shortcutType As String = Convert.ToString(selection.getShortcutType())
                    If shortcutType.IndexOf("-") > 0 Then
                        extension = Mid(shortcutType, (shortcutType.IndexOf("-") + 2))
                        shortcutType = Mid(shortcutType, 1, shortcutType.IndexOf("-"))
                    Else
                        If txtLinkto.Text.Length > 0 Then
                            extension = Mid(txtLinkto.Text, (txtLinkto.Text.IndexOf(".") + 2))
                        End If
                    End If
                    If shortcutType.Trim = "Program" Then
                        radProgram.Checked = True
                    ElseIf shortcutType.Trim = "Report" Then
                        radReport.Checked = True
                    ElseIf shortcutType.Trim = "Custom" Then
                        radCustom.Checked = True
                    ElseIf shortcutType.Trim = "Document" Then
                        radDocument.Checked = True
                    End If
                    Dim obj As Object = selection.getButton
                    PictureBox1.Image = obj.Image
                Else
                    txtShortcutname.Text = String.Empty
                    txtLinkto.Text = String.Empty
                    PictureBox1.Image = Nothing
                End If
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("btnOk_Click Error##" + ex.Message.ToString())
        End Try
    End Sub
    Private Sub btnImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImages.Click
        Try
            If ofdIcon.ShowDialog = DialogResult.OK Then
                If IO.File.Exists(ofdIcon.FileName) Then
                    Dim fs As New IO.FileStream(ofdIcon.FileName, IO.FileMode.Open, IO.FileAccess.Read)
                    Dim bt() As Byte = New Byte(fs.Length - 1) {}
                    fs.Read(bt, 0, bt.Length)
                    AutosizeImage(fs, PictureBox1)
                    fs.Close()
                Else
                    MsgBox("File Not Found")
                End If
            Else
                PictureBox1.Image = Nothing
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("btnImages_Click Error##" + ex.Message.ToString())
        End Try
    End Sub
    Private Sub btnChooseShortcuts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseShortcuts.Click
        Try
            Dim iniFilePath As String = IIf(oExcelSS.xArchitecture, oExcelSS.x86PFilePath, oExcelSS.PFilePath)
            If radProgram.Checked Then
                oExcelSS.shortcutFor = "Program"
            ElseIf radReport.Checked Then
                oExcelSS.shortcutFor = "Report"
            ElseIf radCustom.Checked Then
                oExcelSS.shortcutFor = "Custom"
            ElseIf radDocument.Checked Then
                oExcelSS.shortcutFor = "Document"
            End If
            Select Case oExcelSS.shortcutFor
                Case "Program"
                    Dim shortcutform As New frmProgramList(oExcelSS.shortcutFor)
                    shortcutform.ShowDialog()
                    oExcelSS.shortcutFor = String.Empty
                    If oExcelSS.selectedShortcutFromList <> "" Then
                        txtLinkto.Text = oExcelSS.selectedShortcutFromList
                    End If
                Case "Report"
                    Dim shortcutform As New frmSelectGrpCategory()
                    shortcutform.ShowDialog()
                    oExcelSS.shortcutFor = String.Empty
                    If oExcelSS.selectedShortcutFromList <> "" Then
                        txtLinkto.Text = oExcelSS.selectedShortcutFromList
                    End If
                Case "Custom"
                    If ofdcustom.ShowDialog() = DialogResult.OK Then
                        If IO.File.Exists(ofdcustom.FileName) Then
                            oExcelSS.selectedShortcutFromList = ofdcustom.SafeFileName
                            oExcelSS.selectedShortcutFromListTag = ofdcustom.FileName
                            txtLinkto.Text = ofdcustom.SafeFileName
                        End If
                    End If
                Case "Document"
                    If ofdFile.ShowDialog = DialogResult.OK Then
                        If IO.File.Exists(ofdFile.FileName) Then
                            extension = Mid(ofdFile.FileName, (ofdFile.FileName.LastIndexOf(".") + 2))

                            If PictureBox1.Image Is Nothing Then
                                Select Case extension.Trim.ToLower
                                    Case "docx", "doc"
                                        Dim docimage As String = iniFilePath & "\" & oExcelSS.AppFolderName & "\images\word16.ico"
                                        If isImageExist(docimage) Then
                                            Dim fs As New IO.FileStream(docimage, IO.FileMode.Open, IO.FileAccess.Read)
                                            Dim bt() As Byte = New Byte(fs.Length - 1) {}
                                            fs.Read(bt, 0, bt.Length)
                                            AutosizeImage(fs, PictureBox1)
                                            fs.Close()
                                        End If
                                    Case "xls", "xlsx"
                                        Dim xlsimage As String = iniFilePath & "\" & oExcelSS.AppFolderName & "\images\excel16.ico"
                                        If isImageExist(xlsimage) Then
                                            Dim fs As New IO.FileStream(xlsimage, IO.FileMode.Open, IO.FileAccess.Read)
                                            Dim bt() As Byte = New Byte(fs.Length - 1) {}
                                            fs.Read(bt, 0, bt.Length)
                                            AutosizeImage(fs, PictureBox1)
                                            fs.Close()
                                        End If
                                    Case "pdf"
                                        Dim pdfimage As String = iniFilePath & "\" & oExcelSS.AppFolderName & "\images\pdf16.ico"
                                        If isImageExist(pdfimage) Then
                                            Dim fs As New IO.FileStream(pdfimage, IO.FileMode.Open, IO.FileAccess.Read)
                                            Dim bt() As Byte = New Byte(fs.Length - 1) {}
                                            fs.Read(bt, 0, bt.Length)
                                            AutosizeImage(fs, PictureBox1)
                                            fs.Close()
                                        End If
                                End Select
                            End If
                            oExcelSS.selectedShortcutFromList = ofdFile.SafeFileName
                            oExcelSS.selectedShortcutFromListTag = ofdFile.FileName
                            txtLinkto.Text = ofdFile.SafeFileName
                        End If
                    End If
            End Select
        Catch ex As Exception
            oExcelSS.shortcutFor = String.Empty
            oExcelSS.ErrorLog("btnChooseFile_Click Error##" + ex.Message.ToString())
        End Try
    End Sub
    Public Sub AutosizeImage(ByVal ImagePath As FileStream, ByVal picBox As PictureBox, Optional ByVal pSizeMode As PictureBoxSizeMode = PictureBoxSizeMode.CenterImage)
        Try
            picBox.Image = Nothing
            picBox.SizeMode = pSizeMode
            Dim imgOrg As Bitmap
            Dim imgShow As Bitmap
            Dim g As Graphics
            Dim divideBy, divideByH, divideByW As Double
            imgOrg = DirectCast(Image.FromStream(ImagePath), Image)
            divideByW = imgOrg.Width / picBox.Width
            divideByH = imgOrg.Height / picBox.Height
            If divideByW > 1 Or divideByH > 1 Then
                If divideByW > divideByH Then
                    divideBy = divideByW
                Else
                    divideBy = divideByH
                End If
                imgShow = New Bitmap(CInt(CDbl(imgOrg.Width) / divideBy), CInt(CDbl(imgOrg.Height) / divideBy))
                imgShow.SetResolution(imgOrg.HorizontalResolution, imgOrg.VerticalResolution)
                g = Graphics.FromImage(imgShow)
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                g.DrawImage(imgOrg, New Rectangle(0, 0, CInt(CDbl(imgOrg.Width) / divideBy), CInt(CDbl(imgOrg.Height) / divideBy)), 0, 0, imgOrg.Width, imgOrg.Height, GraphicsUnit.Pixel)
                g.Dispose()
            Else
                imgShow = New Bitmap(imgOrg.Width, imgOrg.Height)
                imgShow.SetResolution(imgOrg.HorizontalResolution, imgOrg.VerticalResolution)
                g = Graphics.FromImage(imgShow)
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                g.DrawImage(imgOrg, New Rectangle(0, 0, imgOrg.Width, imgOrg.Height), 0, 0, imgOrg.Width, imgOrg.Height, GraphicsUnit.Pixel)
                g.Dispose()
            End If
            imgOrg.Dispose()
            picBox.Image = imgShow
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub btnNewShortcut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewShortcut.Click
        Try  
            btnCancel.Enabled = True
            btnClose.Enabled = False
            txtLinkto.Text = String.Empty
            txtShortcutname.Text = String.Empty
            txtShortcutname.Enabled = True
            PictureBox1.Image = Nothing
            btnCreateShortcut.Enabled = True
            btnImages.Enabled = True
            btnChooseShortcuts.Enabled = True
            radProgram.Enabled = True
            radReport.Enabled = True
            radCustom.Enabled = True
            radDocument.Enabled = True
            Dim iniFilePath As String = IIf(oExcelSS.xArchitecture, oExcelSS.x86PFilePath, oExcelSS.PFilePath)
            Dim executeFilePath As String = iniFilePath & "\" & oExcelSS.AppFolderName & "\images\dmac-icon1.ico"
            If IO.File.Exists(executeFilePath) Then
                Using ms As MemoryStream = New MemoryStream
                    Dim fs As New IO.FileStream(executeFilePath, IO.FileMode.Open, IO.FileAccess.Read)
                    Dim bt() As Byte = New Byte(fs.Length - 1) {}
                    fs.Read(bt, 0, bt.Length)
                    AutosizeImage(fs, PictureBox1)
                    fs.Close()
                End Using
            End If
            radProgram.Checked = True
            btnCreateShortcut.Text = "Create Shortcut"
            btnNewShortcut.Enabled = False

            txtShortcutname.Focus()
        Catch ex As Exception
            oExcelSS.ErrorLog("btnNewShortcut_Click Error##" + ex.Message.ToString())
        End Try
    End Sub
    Private Sub btnRemoveOutlookbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveOutlookbutton.Click
        Try
            If lstButtons.Text <> "" Then
                If MsgBox("Are you sure to Remove?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "DMAC") = MsgBoxResult.Yes Then
                    '' get selected listed
                    Dim selection As OutlookButtonList = DirectCast(lstButtons.SelectedItem, OutlookButtonList)
                    Dim Shortcutname = Convert.ToString(selection.getButtonShortcut())
                    Dim Linkto = Convert.ToString(selection.getShortcutFor())
                    Dim ShortcutFor = Convert.ToString(selection.getShortcutFor())
                    Dim strLinkTo = Convert.ToString(selection.getLinkTo())
                    Dim shortcutType As String = Convert.ToString(selection.getShortcutType())
                    Dim status As Boolean = oExcelSS.ExecuteShortcut(0, oExcelSS.userid, oExcelSS.ActiveUserID, shortcutType, Shortcutname, ShortcutFor, Linkto, "", "D", "@strStatus")
                    If status = True Then
                        lstButtons.Items.RemoveAt(lstButtons.FindStringExact(lstButtons.Text))
                        refreshShortcutButton()
                    Else
                        MsgBox("Unable to delete the shortcut", MsgBoxStyle.Critical)
                    End If
                    txtLinkto.Text = String.Empty
                    txtShortcutname.Text = String.Empty
                    PictureBox1.Image = Nothing
                    btnCreateShortcut.Text = "Create Shortcut"
                    btnCreateShortcut.Enabled = False
                    btnRemoveOutlookbutton.Enabled = False
                    btnNewShortcut.Enabled = True
                    isshortcutselected = False
                End If
                End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        selectedindex = -1
        btnCreateShortcut.Text = "Create Shortcut"
        btnCreateShortcut.Enabled = False
        txtShortcutname.Text = String.Empty
        txtShortcutname.Enabled = False
        txtLinkto.Text = String.Empty
        btnNewShortcut.Enabled = True
        PictureBox1.Image = Nothing
        btnNewShortcut.Enabled = True
        btnRemoveOutlookbutton.Enabled = False
    End Sub
    Private Sub radProgram_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radProgram.CheckedChanged
        PictureBox1.Image = Nothing
    End Sub
    Private Sub radReport_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radReport.CheckedChanged
        PictureBox1.Image = Nothing
    End Sub
    Private Sub radDocument_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDocument.CheckedChanged
        PictureBox1.Image = Nothing
    End Sub
    Private Sub radCustom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radCustom.CheckedChanged
        PictureBox1.Image = Nothing
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        btnClear_Click(Me, e)
        btnImages.Enabled = False
        btnChooseShortcuts.Enabled = False
        btnClose.Enabled = True
    End Sub

End Class