Imports System.Runtime.InteropServices

Public Class MemoryEditor

    'http://www.mpgh.net/forum/33-visual-basic-programming/220798-vb-net-read-memory.html
    <DllImport("kernel32.dll", SetLastError:=True)> _
    Private Shared Function ReadProcessMemory( _
       ByVal hProcess As IntPtr, _
       ByVal lpBaseAddress As IntPtr, _
       <Out()> ByVal lpBuffer() As Byte, _
       ByVal dwSize As Integer, _
       ByRef lpNumberOfBytesRead As Integer) As Boolean
    End Function
    Private Function FindAddress(ByVal pHandle As IntPtr, ByVal BaseAddress As IntPtr, ByVal StaticPointer As IntPtr, ByVal Offsets() As IntPtr) As IntPtr
        ' Crearemos un buffer de 4 bytes para sistema de32-bit o 8 bytes sobre un sistema de 64-bit .
        Dim tmp(IntPtr.Size - 1) As Byte
        Dim Address As IntPtr = BaseAddress
        ' Checaremos para 32-bit vs 64-bit.
        If IntPtr.Size = 4 Then
            Address = New IntPtr(Address.ToInt32 + StaticPointer.ToInt32)
        Else
            Address = New IntPtr(Address.ToInt64 + StaticPointer.ToInt64)
        End If
        ' Loop de cada Offset hasta encontrar el Address
        For i As Integer = 0 To Offsets.Length - 1
            ReadProcessMemory(pHandle, Address, tmp, IntPtr.Size, 0)
            If IntPtr.Size = 4 Then
                Address = BitConverter.ToInt32(tmp, 0) + Offsets(i).ToInt32()
            Else
                Address = BitConverter.ToInt64(tmp, 0) + Offsets(i).ToInt64()
            End If
        Next
        Return Address
    End Function
    Public Function Obtener_Address()
        Dim p As Process() = Process.GetProcessesByName("Gunz")

        ' Obtendremos el Handle y el BaseAddress de nuestro proceso
        Dim pID As IntPtr = p(0).Handle
        Dim base As IntPtr = p(0).MainModule.BaseAddress
        ' Colocamos Nuestro Pointer Estatico
        Dim sptr As IntPtr = &H26C7C8
        ' Y aqui nuestro Offset segun los necesarios
        Dim offsets() As IntPtr = {&H0, &H1F8, &H8, &H84, &H0}
        Dim addr As IntPtr = FindAddress(pID, base, sptr, offsets)
        Dim f As String
        f = addr.ToString
        Return f
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        WriteInteger(TextBox1.Text, TextBox2.Text, TextBox3.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim work As New A(TextBox1.Text, TextBox2.Text, ListBox1)
        Dim ab As Threading.Thread = New Threading.Thread(AddressOf work.Sets)
        ab.Start()
    End Sub

    Public Class A
        Public Shared procnamea As String
        Public Shared valuea As Integer
        Public Shared lists As ListBox
        Public Sub New(ByVal procname As String, ByVal value As Integer, ByRef list As ListBox)
            procnamea = procname
            valuea = value
            lists = list
        End Sub
        Public Shared Sub Sets()
            Try
                For A = 0 To &H7FFFFFFF
                    If ReadInteger(procnamea, A) = valuea Then
                        lists.Items.Add(A)
                    End If
                Next
            Catch ex As Exception
                MsgBox("error")
            End Try
        End Sub
    End Class

    Private Sub MemoryEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class