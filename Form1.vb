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

quit:
        recheck_folder()
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
        For Each fmod In IO.Directory.GetFiles(mods_folder & "\mods", "*.zip")
            modname = fmod.Replace(mods_folder & "\mods\", "")
            ListBox_found_mods.Items.Add(modname)
        Next
        Label_found_mods.Text = "Found Mods: " & ListBox_found_mods.Items.Count
    End Sub
End Class
