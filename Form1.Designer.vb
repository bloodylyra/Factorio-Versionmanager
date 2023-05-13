<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form1))
        GroupBox1 = New GroupBox()
        Button_restore_save = New Button()
        Button_delete_save = New Button()
        ListBox_saved_version = New ListBox()
        GroupBox2 = New GroupBox()
        TextBox_savename = New TextBox()
        Button_new_save = New Button()
        Label_found_mods = New Label()
        ListBox_found_mods = New ListBox()
        GroupBox3 = New GroupBox()
        Label_storagelink = New Label()
        Label_modslink = New Label()
        Label_steamlink = New Label()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        FolderBrowserDialog1 = New FolderBrowserDialog()
        ProgressBar_restore = New ProgressBar()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox3.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Button_restore_save)
        GroupBox1.Controls.Add(Button_delete_save)
        GroupBox1.Controls.Add(ListBox_saved_version)
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(219, 263)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Saved versions"
        ' 
        ' Button_restore_save
        ' 
        Button_restore_save.Location = New Point(138, 234)
        Button_restore_save.Name = "Button_restore_save"
        Button_restore_save.Size = New Size(75, 23)
        Button_restore_save.TabIndex = 2
        Button_restore_save.Text = "Restore"
        Button_restore_save.UseVisualStyleBackColor = True
        ' 
        ' Button_delete_save
        ' 
        Button_delete_save.Location = New Point(6, 234)
        Button_delete_save.Name = "Button_delete_save"
        Button_delete_save.Size = New Size(75, 23)
        Button_delete_save.TabIndex = 1
        Button_delete_save.Text = "Delete"
        Button_delete_save.UseVisualStyleBackColor = True
        ' 
        ' ListBox_saved_version
        ' 
        ListBox_saved_version.FormattingEnabled = True
        ListBox_saved_version.ItemHeight = 15
        ListBox_saved_version.Location = New Point(6, 22)
        ListBox_saved_version.Name = "ListBox_saved_version"
        ListBox_saved_version.Size = New Size(207, 199)
        ListBox_saved_version.TabIndex = 0
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(TextBox_savename)
        GroupBox2.Controls.Add(Button_new_save)
        GroupBox2.Controls.Add(Label_found_mods)
        GroupBox2.Controls.Add(ListBox_found_mods)
        GroupBox2.Location = New Point(237, 12)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(348, 263)
        GroupBox2.TabIndex = 1
        GroupBox2.TabStop = False
        GroupBox2.Text = "Installed Version"
        ' 
        ' TextBox_savename
        ' 
        TextBox_savename.Location = New Point(112, 234)
        TextBox_savename.Name = "TextBox_savename"
        TextBox_savename.Size = New Size(222, 23)
        TextBox_savename.TabIndex = 3
        ' 
        ' Button_new_save
        ' 
        Button_new_save.Location = New Point(6, 234)
        Button_new_save.Name = "Button_new_save"
        Button_new_save.Size = New Size(100, 23)
        Button_new_save.TabIndex = 2
        Button_new_save.Text = "Save Version"
        Button_new_save.UseVisualStyleBackColor = True
        ' 
        ' Label_found_mods
        ' 
        Label_found_mods.AutoSize = True
        Label_found_mods.Location = New Point(6, 19)
        Label_found_mods.Name = "Label_found_mods"
        Label_found_mods.Size = New Size(80, 15)
        Label_found_mods.TabIndex = 1
        Label_found_mods.Text = "Found Mods: "
        ' 
        ' ListBox_found_mods
        ' 
        ListBox_found_mods.FormattingEnabled = True
        ListBox_found_mods.ItemHeight = 15
        ListBox_found_mods.Location = New Point(6, 37)
        ListBox_found_mods.Name = "ListBox_found_mods"
        ListBox_found_mods.Size = New Size(328, 184)
        ListBox_found_mods.TabIndex = 0
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(Label_storagelink)
        GroupBox3.Controls.Add(Label_modslink)
        GroupBox3.Controls.Add(Label_steamlink)
        GroupBox3.Controls.Add(Button3)
        GroupBox3.Controls.Add(Button2)
        GroupBox3.Controls.Add(Button1)
        GroupBox3.Location = New Point(12, 281)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(573, 109)
        GroupBox3.TabIndex = 2
        GroupBox3.TabStop = False
        GroupBox3.Text = "Settings"
        ' 
        ' Label_storagelink
        ' 
        Label_storagelink.AutoSize = True
        Label_storagelink.Location = New Point(163, 84)
        Label_storagelink.Name = "Label_storagelink"
        Label_storagelink.Size = New Size(46, 15)
        Label_storagelink.TabIndex = 5
        Label_storagelink.Text = "storage"
        ' 
        ' Label_modslink
        ' 
        Label_modslink.AutoSize = True
        Label_modslink.Location = New Point(163, 55)
        Label_modslink.Name = "Label_modslink"
        Label_modslink.Size = New Size(37, 15)
        Label_modslink.TabIndex = 4
        Label_modslink.Text = "mods"
        ' 
        ' Label_steamlink
        ' 
        Label_steamlink.AutoSize = True
        Label_steamlink.Location = New Point(163, 26)
        Label_steamlink.Name = "Label_steamlink"
        Label_steamlink.Size = New Size(39, 15)
        Label_steamlink.TabIndex = 3
        Label_steamlink.Text = "steam"
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(6, 80)
        Button3.Name = "Button3"
        Button3.Size = New Size(151, 23)
        Button3.TabIndex = 2
        Button3.Text = "Storage Folder"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(6, 51)
        Button2.Name = "Button2"
        Button2.Size = New Size(151, 23)
        Button2.TabIndex = 1
        Button2.Text = "Appdata Factorio Folder"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(6, 22)
        Button1.Name = "Button1"
        Button1.Size = New Size(151, 23)
        Button1.TabIndex = 0
        Button1.Text = "Steam Factorio folder"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ProgressBar_restore
        ' 
        ProgressBar_restore.Location = New Point(12, 396)
        ProgressBar_restore.Maximum = 8
        ProgressBar_restore.Name = "ProgressBar_restore"
        ProgressBar_restore.Size = New Size(572, 31)
        ProgressBar_restore.TabIndex = 3
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(596, 439)
        Controls.Add(ProgressBar_restore)
        Controls.Add(GroupBox3)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form1"
        Text = "Form1"
        GroupBox1.ResumeLayout(False)
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button_restore_save As Button
    Friend WithEvents Button_delete_save As Button
    Friend WithEvents ListBox_saved_version As ListBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TextBox_savename As TextBox
    Friend WithEvents Button_new_save As Button
    Friend WithEvents Label_found_mods As Label
    Friend WithEvents ListBox_found_mods As ListBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label_storagelink As Label
    Friend WithEvents Label_modslink As Label
    Friend WithEvents Label_steamlink As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents ProgressBar_restore As ProgressBar
End Class
