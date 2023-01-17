Dim oMIE 
Function Debug(T)
    If Not IsObject( oMIE ) Then 
       Set oMIE = CreateObject("VBSDebugger.Debug")
           oMIE.SetDialogTitle("Cutt.Ly Logger") 
           oMIE.ToolBar(False) 
           oMIE.SetDialogWidth(603)
           oMIE.SetDialogHeight(335) 
           oMIE.OpenDebugDialog()
     End If 
           oMIE.Write(T)
End Function

Debug "hola"
Dim IE
Dim MyDocument
'msgbox "aa"
Set IE = CreateObject("InternetExplorer.Application")
IE.Visible = 0
IE.navigate "https://cutt.ly/RjmR9Bj"
While IE.ReadyState <> 4 : WScript.Sleep 100 : Wend
Debug "Ready Page"
WScript.Sleep(5000)
IE.Quit