﻿'------------------------------------------------------------------------------
' <auto-generated>
'     이 코드는 도구를 사용하여 생성되었습니다.
'     런타임 버전:4.0.30319.0
'
'     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
'     이러한 변경 내용이 손실됩니다.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    '참고: 자동으로 생성되므로 직접 이 파일을 수정하지 마십시오.  변경할 사항이 있거나
    ' 파일에서 빌드 오류가 발생하는 경우 프로젝트 디자이너로
    ' 이동([프로젝트 속성]으로 이동하거나 솔루션 탐색기에서 My Project 노드를
    ' 두 번 클릭)한 다음 [응용 프로그램] 탭에서 변경하십시오.
    '
    Partial Friend Class MyApplication
        
        <Global.System.Diagnostics.DebuggerStepThroughAttribute()>  _
        Public Sub New()
            MyBase.New(Global.Microsoft.VisualBasic.ApplicationServices.AuthenticationMode.Windows)
            Me.IsSingleInstance = false
            Me.EnableVisualStyles = true
            Me.SaveMySettingsOnExit = true
            Me.ShutDownStyle = Global.Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses
        End Sub
        
        <Global.System.Diagnostics.DebuggerStepThroughAttribute()>  _
        Protected Overrides Sub OnCreateMainForm()
            Me.MainForm = Global.RollRat_File_Security.frmSecurity
        End Sub
    End Class
End Namespace
