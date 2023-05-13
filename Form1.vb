Imports System.IO
Imports System.Runtime

Public Class Form1
    'Settings
    Dim windowtitel As String = "Factorio Versionmanager"
    Dim reglink As String = "HKEY_CURRENT_USER\SOFTWARE\Hivetec\FVM"
    '
    'Global Vars
    Dim factorio_folder As String
    Dim mods_folder As String
    Dim storage_folder As String
    Dim folders_ok As Boolean
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = windowtitel
        Dim regfac As String = My.Computer.Registry.GetValue(reglink, "Steam", Nothing)
        Dim regmods As String = My.Computer.Registry.GetValue(reglink, "Mods", Nothing)
        Dim regstor As String = My.Computer.Registry.GetValue(reglink, "Storage", Nothing)
        folders_ok = True
        If regfac = Nothing Or regmods = Nothing Or regstor = Nothing Then
            MsgBox("One or more Folders are not set. Use the buttons below to set them.", MsgBoxStyle.Critical, "Folders not set")
            folders_ok = False
            GoTo quit
        End If
        If regfac = "na" Or regmods = "na" Or regstor = "na" Then
            MsgBox("One or more Folders are invalid. Use the buttons below to set them.", MsgBoxStyle.Critical, "Folders not valid")
            folders_ok = False
            GoTo quit
        End If
        If Not My.Computer.FileSystem.DirectoryExists(regfac) Then
            MsgBox("Steam-Folder not found. Please reset it.", MsgBoxStyle.Critical, "Folder not found")
            folders_ok = False
            My.Computer.Registry.SetValue(reglink, "Steam", "na")
        End If
        If Not My.Computer.FileSystem.DirectoryExists(regmods) Then
            MsgBox("Appdata-Folder not found. Please reset it.", MsgBoxStyle.Critical, "Folder not found")
            folders_ok = False
            My.Computer.Registry.SetValue(reglink, "Mods", "na")
        End If
        If Not My.Computer.FileSystem.DirectoryExists(regstor) Then
            MsgBox("Storage-Folder not found. Please reset it.", MsgBoxStyle.Critical, "Folder not found")
            folders_ok = False
            My.Computer.Registry.SetValue(reglink, "Storage", "na")
        End If
        If Not folders_ok Then
            GoTo quit
        End If
        factorio_folder = regfac
        mods_folder = regmods
        storage_folder = regstor
        recheck_folder()
        Fetch_mods()
        Read_saved_versions()
quit:
        recheck_folder()
    End Sub

    Private Sub Read_saved_versions()
        ListBox_saved_version.Items.Clear()
        Dim savename As String
        For Each save In IO.Directory.GetDirectories(storage_folder)
            savename = save.Replace(storage_folder & "\", "")
            ListBox_saved_version.Items.Add(savename)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'factorio folder
        Dim folder As String
        FolderBrowserDialog1.ShowDialog()
        folder = FolderBrowserDialog1.SelectedPath
        If Not My.Computer.FileSystem.DirectoryExists(folder) Then
            MsgBox("Folder not found. Please reset it.", MsgBoxStyle.Critical, "Folder not found")
            GoTo quit
        End If
        My.Computer.Registry.SetValue(reglink, "Steam", folder)
        factorio_folder = folder
        recheck_folder()
quit:
    End Sub

    Private Sub recheck_folder()
        If My.Computer.FileSystem.DirectoryExists(factorio_folder) And My.Computer.FileSystem.DirectoryExists(mods_folder) And My.Computer.FileSystem.DirectoryExists(storage_folder) Then
            folders_ok = True
            Label_steamlink.Text = factorio_folder
            Label_modslink.Text = mods_folder
            Label_storagelink.Text = storage_folder
        Else
            folders_ok = False
        End If
        Button_delete_save.Enabled = folders_ok
        Button_restore_save.Enabled = folders_ok
        Button_new_save.Enabled = folders_ok
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'mods folder
        Dim folder As String
        FolderBrowserDialog1.ShowDialog()
        folder = FolderBrowserDialog1.SelectedPath
        If Not My.Computer.FileSystem.DirectoryExists(folder) Then
            MsgBox("Folder not found. Please reset it.", MsgBoxStyle.Critical, "Folder not found")
            GoTo quit
        End If
        My.Computer.Registry.SetValue(reglink, "Mods", folder)
        mods_folder = folder
        recheck_folder()
quit:
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'storage folder
        Dim folder As String
        FolderBrowserDialog1.ShowDialog()
        folder = FolderBrowserDialog1.SelectedPath
        If Not My.Computer.FileSystem.DirectoryExists(folder) Then
            MsgBox("Folder not found. Please reset it.", MsgBoxStyle.Critical, "Folder not found")
            GoTo quit
        End If
        My.Computer.Registry.SetValue(reglink, "Storage", folder)
        storage_folder = folder
        recheck_folder()
quit:
    End Sub
    Private Sub Fetch_mods()
        ListBox_found_mods.Items.Clear()
        Dim modname As String
        If Not My.Computer.FileSystem.DirectoryExists(mods_folder & "\mods") Then
            GoTo quit
        End If
        For Each fmod In IO.Directory.GetFiles(mods_folder & "\mods", "*.zip")
            modname = fmod.Replace(mods_folder & "\mods\", "")
            ListBox_found_mods.Items.Add(modname)
        Next
        Label_found_mods.Text = "Found Mods: " & ListBox_found_mods.Items.Count
quit:
    End Sub

    Private Sub Button_new_save_Click(sender As Object, e As EventArgs) Handles Button_new_save.Click
        If TextBox_savename.Text = "" Then
            MsgBox("No name entered.", MsgBoxStyle.Critical, "Missing name")
            GoTo quit
        End If
        Dim savename As String = TextBox_savename.Text
        If My.Computer.FileSystem.DirectoryExists(storage_folder & "\" & savename) Then
            MsgBox("Name already in use.", MsgBoxStyle.Critical, "Used name")
            GoTo quit
        End If
        ProgressBar_restore.Maximum = 5
        Setbar(0)
        My.Computer.FileSystem.CreateDirectory(storage_folder & "\" & savename)
        Setbar(1)
        My.Computer.FileSystem.CopyDirectory(factorio_folder & "\bin", storage_folder & "\" & savename & "\bin", True)
        Setbar(2)
        My.Computer.FileSystem.CopyDirectory(factorio_folder & "\data", storage_folder & "\" & savename & "\data", True)
        Setbar(3)
        My.Computer.FileSystem.CopyDirectory(factorio_folder & "\doc-html", storage_folder & "\" & savename & "\doc-html", True)
        Setbar(4)
        My.Computer.FileSystem.CopyDirectory(mods_folder & "\mods", storage_folder & "\" & savename & "\mods", True)
        Setbar(5)
        MsgBox("Done.", MsgBoxStyle.Information, "Save")
        Read_saved_versions()
quit:
    End Sub
    Private Sub Setbar(value As Integer)
        If value <= ProgressBar_restore.Maximum Then
            ProgressBar_restore.Value = value
            ProgressBar_restore.Refresh()
        End If
    End Sub

    Private Sub Button_restore_save_Click(sender As Object, e As EventArgs) Handles Button_restore_save.Click
        Dim selected_save As String
        If ListBox_saved_version.SelectedItem = "" Then
            GoTo quit
        End If
        If ListBox_saved_version.SelectedIndex < 0 Then
            GoTo quit
        End If
        selected_save = ListBox_saved_version.SelectedItem

        If Not My.Computer.FileSystem.DirectoryExists(storage_folder & "\" & selected_save & "\bin") Then
            MsgBox("Saved version corrupted. Please copy by hand.", MsgBoxStyle.Critical, "Save not correct")
            GoTo quit
        End If
        If Not My.Computer.FileSystem.DirectoryExists(storage_folder & "\" & selected_save & "\data") Then
            MsgBox("Saved version corrupted. Please copy by hand.", MsgBoxStyle.Critical, "Save not correct")
            GoTo quit
        End If
        If Not My.Computer.FileSystem.DirectoryExists(storage_folder & "\" & selected_save & "\doc-html") Then
            MsgBox("Saved version corrupted. Please copy by hand.", MsgBoxStyle.Critical, "Save not correct")
            GoTo quit
        End If
        If Not My.Computer.FileSystem.DirectoryExists(storage_folder & "\" & selected_save & "\mods") Then
            MsgBox("Saved version corrupted. Please copy by hand.", MsgBoxStyle.Critical, "Save not correct")
            GoTo quit
        End If

        ProgressBar_restore.Maximum = 8
        Setbar(0)
        If My.Computer.FileSystem.DirectoryExists(mods_folder & "\mods") Then
            My.Computer.FileSystem.DeleteDirectory(mods_folder & "\mods", FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        Setbar(1)
        If My.Computer.FileSystem.DirectoryExists(factorio_folder & "\bin") Then
            My.Computer.FileSystem.DeleteDirectory(factorio_folder & "\bin", FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        Setbar(2)
        If My.Computer.FileSystem.DirectoryExists(factorio_folder & "\data") Then
            My.Computer.FileSystem.DeleteDirectory(factorio_folder & "\data", FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        Setbar(3)
        If My.Computer.FileSystem.DirectoryExists(factorio_folder & "\doc-html") Then
            My.Computer.FileSystem.DeleteDirectory(factorio_folder & "\doc-html", FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If

        Setbar(4)
        My.Computer.FileSystem.CopyDirectory(storage_folder & "\" & selected_save & "\bin", factorio_folder & "\bin", True)
        Setbar(5)
        My.Computer.FileSystem.CopyDirectory(storage_folder & "\" & selected_save & "\data", factorio_folder & "\data", True)
        Setbar(6)
        My.Computer.FileSystem.CopyDirectory(storage_folder & "\" & selected_save & "\doc-html", factorio_folder & "\doc-html", True)
        Setbar(7)
        My.Computer.FileSystem.CopyDirectory(storage_folder & "\" & selected_save & "\mods", mods_folder & "\mods", True)
        Setbar(8)

        MsgBox("Done.", MsgBoxStyle.Information, "Restore")
        Fetch_mods()
quit:
    End Sub

    Private Sub Button_delete_save_Click(sender As Object, e As EventArgs) Handles Button_delete_save.Click
        Dim selected_save As String
        If ListBox_saved_version.SelectedItem = "" Then
            GoTo quit
        End If
        If ListBox_saved_version.SelectedIndex < 0 Then
            GoTo quit
        End If
        selected_save = ListBox_saved_version.SelectedItem
        If Not My.Computer.FileSystem.DirectoryExists(storage_folder & "\" & selected_save) Then
            GoTo quit
        End If
        Select Case MessageBox.Show("Do you want to delete Saved version " & selected_save & "?", "Delete Save?", MessageBoxButtons.YesNo)
            Case Windows.Forms.DialogResult.Yes
                My.Computer.FileSystem.DeleteDirectory(storage_folder & "\" & selected_save, FileIO.DeleteDirectoryOption.DeleteAllContents)
            Case Windows.Forms.DialogResult.No
        End Select
        Read_saved_versions()
quit:
    End Sub
End Class
