﻿Namespace My
    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private Sub AppStart(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf ResolveAssemblies
        End Sub

        Private Function ResolveAssemblies(sender As Object, e As System.ResolveEventArgs) As Reflection.Assembly
            Dim desiredAssembly = New Reflection.AssemblyName(e.Name)
          
            If desiredAssembly.Name = "Guna.UI" Then
                Return Reflection.Assembly.Load(My.Resources.Guna_UI)
            ElseIf desiredAssembly.Name = "ScintillaNET" Then
                Return Reflection.Assembly.Load(My.Resources.ScintillaNET)
            ElseIf desiredAssembly.Name = "Xylon Antivir" Then
                Return Reflection.Assembly.Load(My.Resources.Xylon_Antivir)
            ElseIf desiredAssembly.Name = "AutocompleteMenu-ScintillaNET" Then
                Return Reflection.Assembly.Load(My.Resources.AutocompleteMenu_ScintillaNET)
            ElseIf desiredAssembly.Name = "Mono.Cecil" Then
                Return Reflection.Assembly.Load(My.Resources.Mono_Cecil)
            ElseIf desiredAssembly.Name = "HtmlAgilityPack" Then
                Return Reflection.Assembly.Load(My.Resources.HtmlAgilityPack)
            End If
          
            Return Nothing
        End Function

    End Class


End Namespace

