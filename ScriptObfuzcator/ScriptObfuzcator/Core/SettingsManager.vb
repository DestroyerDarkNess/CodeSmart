Imports CodeSmart.Core.SettingsManager

Namespace Core


    Public Class SettingsManager

#Region " Enum "

        Public Enum ThemeApp
            Dark
            Light
            Blue
        End Enum

        Public Enum ProcesorMethod
            Sync
            Async
        End Enum

#End Region

#Region " Environment "

        Private _BarStatus As Boolean = True
        Public Property GetBarStatus() As Boolean
            Get
                Return SettingsLoader.LoadShowStatusBarStatus()
            End Get
            Set(ByVal value As Boolean)
                SettingsLoader.SaveShowStatusBarStatus(value)
            End Set
        End Property

        Private _GraphicsOptic As Boolean = True
        Public Property GraphicsOptic() As Boolean
            Get
                Return SettingsLoader.LoadGraphicsOpti()
            End Get
            Set(ByVal value As Boolean)
                SettingsLoader.SaveGraphicsOpti(value)
            End Set
        End Property

#End Region



        Private _GetProcesorMethod As ProcesorMethod = ProcesorMethod.Sync
        Public Property GetProcesorMethod() As ProcesorMethod
            Get
                Return _GetProcesorMethod
            End Get
            Set(ByVal value As ProcesorMethod)
                _GetProcesorMethod = value
            End Set
        End Property


    End Class

    Public Class SettingsLoader



#Region " Declare "

        Declare Function GetPrivateProfileStringA Lib "kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As System.Text.StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
        Declare Function WritePrivateProfileStringA Lib "kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer

        Public Shared SettingLoader As New Core.SettingsManager

        Private Shared Scripts As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\Scripts.txt"
        Private Shared IniFile As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\Settings.ini"
        Public Shared DLL_Index As Integer

#End Region


        Public Shared Function ReadIni(ByVal Section As String, ByVal Key As String, Optional ByVal DefaultValue As String = Nothing) As String
            Dim buffer As New System.Text.StringBuilder(260)
                GetPrivateProfileStringA(Section, Key, DefaultValue, buffer, buffer.Capacity, IniFile)
                Return buffer.ToString
          End Function

        Public Shared Function WriteIni(ByVal Section As String, ByVal Key As String, ByVal Value As String) As Boolean
            Return (WritePrivateProfileStringA(Section, Key, Value, IniFile) <> 0)
        End Function

#Region " Theme "

        Public Shared Sub SaveTheme(ByVal Theme As String)
            WriteIni("Settings", "Theme", Theme)
         End Sub

        Public Shared Sub SaveThemeAs(ByVal Theme As ThemeApp)
            Select Case Theme
                Case SettingsManager.ThemeApp.Dark : WriteIni("Settings", "Theme", "Dark")
                Case SettingsManager.ThemeApp.Light : WriteIni("Settings", "Theme", "Light")
                Case SettingsManager.ThemeApp.Blue : WriteIni("Settings", "Theme", "Blue")
            End Select
            WriteIni("Settings", "Theme", "Dark")
        End Sub

        Public Shared Function LoadTheme()
            Dim Theme As String = ReadIni("Settings", "Theme", "Dark")
            Select Case Theme
                Case "Dark" : Return SettingsManager.ThemeApp.Dark
                Case "Light" : Return SettingsManager.ThemeApp.Light
                Case "Blue" : Return SettingsManager.ThemeApp.Blue
            End Select
            Return Theme
        End Function

        Public Shared Sub SaveShowStatusBarStatus(ByVal Bar As Boolean)
            WriteIni("Settings", "BarStatus", Bar)
        End Sub

        Public Shared Function LoadShowStatusBarStatus() As Boolean
            Dim BarStatus As String = ReadIni("Settings", "GraphicsOpti", True)
            Return CBool(BarStatus)
        End Function

        Public Shared Sub SaveGraphicsOpti(ByVal Opt As Boolean)
            WriteIni("Settings", "GraphicsOpti", Opt)
        End Sub

        Public Shared Function LoadGraphicsOpti() As Boolean
            Dim GraOpti As String = ReadIni("Settings", "GraphicsOpti", True)
            Return CBool(GraOpti)
        End Function

#End Region

        Public Shared Sub UpdateAllSettins()
            Form1.UpdateSettings()
            Obfuzcator.UpdateSettings()
        End Sub

    End Class

End Namespace


