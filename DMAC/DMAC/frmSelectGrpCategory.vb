Public Class frmSelectGrpCategory
    Dim szGroup As String
    Private Sub trvRptViewGroup_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvRptViewGroup.AfterSelect
        Try
            If e.Node.ToolTipText.Trim <> "" Then
                Me.txtDescription.Text = e.Node.ToolTipText
                oExcelSS.getReportPreview(e.Node.Tag, Me.pbPreview)
                btnSelect.Enabled = True
                btnAssign.Enabled = True
            Else
                btnSelect.Enabled = False
                btnAssign.Enabled = False
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("frmReportViewUser_AfterSelect Error# " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub frmSelectGrpCategory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            oExcelSS.fillTrvSelectReports(trvRptViewGroup)
            If oExcelSS.shortcutFor.ToLower = "report" Then
                Me.btnSelect.Text = "Select"
                Me.btnAssign.Enabled = False
            Else
                Me.btnAssign.Enabled = True
                Me.btnSelect.Text = "Open Report"
            End If
            btnSelect.Enabled = False
        Catch ex As Exception
            oExcelSS.ErrorLog("frmReportViewUser_Load Error# " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If oExcelSS.shortcutFor.ToLower = "report" Then
            oExcelSS.selectedShortcutFromList = Me.trvRptViewGroup.SelectedNode.Text.Trim
            oExcelSS.selectedShortcutFromListTag = Me.trvRptViewGroup.SelectedNode.Tag
        Else
            Master.RunReportLauncher("DMAC-Report", Me.trvRptViewGroup.SelectedNode.Text.Trim)
        End If
        Me.Close()
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        If ofdImage.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IO.File.Exists(ofdImage.FileName) Then
                Dim fs As New IO.FileStream(ofdImage.FileName, IO.FileMode.Open, IO.FileAccess.Read)
                Dim bt() As Byte = New Byte(fs.Length - 1) {}
                fs.Read(bt, 0, bt.Length)
                AutosizeImage(fs, pbPreview)
                fs.Close()
                Dim nImage As Image = pbPreview.Image
                If Not nImage Is Nothing Then
                    Using ms As System.IO.MemoryStream = New System.IO.MemoryStream
                        nImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                        Dim bImage() As Byte
                        bImage = ms.ToArray
                        Dim p As System.Data.SqlClient.SqlParameter() = New System.Data.SqlClient.SqlParameter(1) {}
                        p(0) = New System.Data.SqlClient.SqlParameter("@ReportIDKey", trvRptViewGroup.SelectedNode.Tag)
                        p(1) = New System.Data.SqlClient.SqlParameter("@image", bImage)
                        oExcelSS.isSavedData("uspDmac_SavePreviewReportImage", , , , "strStatus", p)
                    End Using
                End If
            Else
                MsgBox("File Not Found")
            End If
        End If
    End Sub
    Public Sub AutosizeImage(ByVal ImagePath As System.IO.FileStream, ByVal picBox As PictureBox, Optional ByVal pSizeMode As PictureBoxSizeMode = PictureBoxSizeMode.CenterImage)
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
End Class