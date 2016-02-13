Class calSic

    Function factor(sic As String, n As Double, s As Double, ByRef sic_stmt As Double, len As Integer) As Double
        Dim ta As Double = 0
        If (sic(sic_stmt) = "(") Then
            sic_stmt += 1
            ta = var(sic, n, s, sic_stmt, len)
            If (sic(sic_stmt) = ")") Then
                sic_stmt += 1
                Return ta
            End If
        ElseIf "0" <= sic(sic_stmt) And sic(sic_stmt) <= "9" Then
            While True
                If "0" <= sic(sic_stmt) And sic(sic_stmt) <= "9" Then
                    ta *= 10
                    ta += sic(sic_stmt).ToString
                    sic_stmt += 1
                    If sic_stmt >= len Then Return ta
                Else
                    Exit While
                End If
            End While
        ElseIf sic(sic_stmt) = "n" Then
            sic_stmt += 1
            Return n
        ElseIf sic(sic_stmt) = "x" Then
            sic_stmt += 1
            Return s
        ElseIf sic(sic_stmt) = "s" Then
            '원래 sin이 확실히 맞는지 검사해야되는데 구현이 귀찮아서 안함
            sic_stmt += 3
            Return Math.Sin(factor(sic, n, s, sic_stmt, len))
        ElseIf sic(sic_stmt) = "c" Then
            sic_stmt += 3
            Return Math.Cos(factor(sic, n, s, sic_stmt, len))
        ElseIf sic(sic_stmt) = "p" Then
            sic_stmt += 2
            Return Math.PI
        ElseIf sic(sic_stmt) = "e" Then
            sic_stmt += 1
            Return Math.E
        End If
        Return ta
    End Function

    Function exp(sic As String, n As Double, s As Double, ByRef sic_stmt As Double, len As Integer) As Double
        Dim ta As Double = factor(sic, n, s, sic_stmt, len)
        While sic(sic_stmt) = "*" Or sic(sic_stmt) = "/"
            If (sic(sic_stmt) = "*") Then
                sic_stmt += 1
                ta *= factor(sic, n, s, sic_stmt, len)
                If sic_stmt >= len Then Return ta
            Else
                sic_stmt += 1
                ta /= factor(sic, n, s, sic_stmt, len)
                If sic_stmt >= len Then Return ta
            End If
        End While
        Return ta
    End Function

    Function var(sic As String, n As Double, s As Double, ByRef sic_stmt As Double, len As Integer) As Double
        Dim ta As Double = exp(sic, n, s, sic_stmt, len)
        If sic_stmt >= len Then Return ta
        While sic(sic_stmt) = "+" Or sic(sic_stmt) = "-"
            If (sic(sic_stmt) = "+") Then
                sic_stmt += 1
                ta += exp(sic, n, s, sic_stmt, len)
                If sic_stmt >= len Then Return ta
            Else
                sic_stmt += 1
                ta -= exp(sic, n, s, sic_stmt, len)
                If sic_stmt >= len Then Return ta
            End If
        End While
        Return ta
    End Function

End Class
