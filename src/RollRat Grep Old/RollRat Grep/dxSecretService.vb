'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Module dxSecretService

    '
    '   수정금지
    '

    '
    '   VB.NET 헥스 변환
    '
    Public Function File2VbNetHex(ByVal addr As String) As String
        Dim ss As New System.Text.StringBuilder
        Dim bytes() As Byte = IO.File.ReadAllBytes(addr)
        Dim prefix As String = "&H"
        Dim deli As String = ", "
        Dim rate As Integer = 16
        Dim postfix As String = " _"
        Dim ratec As Integer = 0

        ss.Append("{")

        For Each arg As Byte In bytes
            If rate = ratec Then
                ratec = 0
                ss.Append(postfix & vbCrLf)
            End If
            ss.Append(prefix & arg.ToString("X") & deli)
            ratec += 1
        Next

        If ratec <> 1 Then
            ss.Remove(ss.Length - deli.Length, deli.Length)
        End If

        ss.Append("}")

        Return ss.ToString
    End Function

    '
    '   af7b6456e6425c6ea64f1380ab85762259ddb1cfaef943fd
    '   e37f9f751de17db49dcc3d291fae7762386b895ad880d9fd
    '
    '   Note: Don't try unlock this.
    '
    Public af7b6456e6425c6ea64f1380ab85762259ddb1cfaef943fde37f9f751de17db49dcc3d291fae7762386b895ad880d9fd As Byte() = _
        {&H20, &H8, &H30, &HE2, &H63, &HA3, &H2D, &HFE, &H75, &HEF, &HA9, &HCA, &HB, &H8F, &H11, &H0, _
           &HC0, &H21, &HC9, &H1B, &H51, &H7E, &H9A, &H43, &H11, &H7A, &H79, &H8B, &H2E, &HCB, &H6F, &H84, _
           &H28, &H86, &HD0, &HB3, &H7F, &H80, &H74, &H1C, &H59, &H48, &H63, &HE2, &H62, &HF3, &H56, &H28, _
           &HCE, &HEA, &H2D, &H29, &HF2, &HA8, &HAD, &H5C, &H20, &HBF, &H99, &H6F, &HA1, &H2F, &HE0, &H61, _
           &HE9, &H14, &H34, &H18, &H67, &H26, &H80, &H49, &H49, &H32, &HF4, &H12, &H42, &H42, &HF5, &HF6, _
           &HBC, &H7, &H88, &H7F, &H1A, &H3A, &H70, &H3C, &HA5, &H77, &HEC, &HEE, &HC3, &HA0, &H9, &HF0, _
           &H8B, &HCD, &H5D, &H1A, &H44, &H2F, &H84, &H37, &H79, &H5E, &HB7, &H31, &HAF, &H7F, &H97, &HDB, _
           &H5D, &H6E, &H75, &HB, &HE6, &H3E, &H41, &HA7, &HD3, &H4B, &H94, &H4A, &H2A, &HE9, &H85, &HDE, _
           &HB6, &H43, &H4, &H79, &H20, &HEF, &H90, &HB4, &H33, &H63, &H37, &H28, &H96, &H81, &H16, &H83, _
           &HAE, &H77, &H20, &HD1, &HD2, &H30, &H46, &HE, &H6C, &H26, &H4E, &H82, &H0, &HC0, &H5B, &H2A, _
           &HE1, &HC7, &HE, &HA5, &H28, &H8C, &H8A, &HDE, &H6C, &H6F, &HE8, &H63, &H6E, &H50, &H2E, &H81, _
           &H6C, &HB8, &HF2, &HFF, &HD6, &HEC, &HF0, &HB4, &H82, &HBE, &HD, &HB2, &H5B, &HAE, &HDB, &H2A, _
           &HD2, &H20, &HE5, &H25, &H75, &H28, &H6A, &H36, &H75, &HE, &HAD, &H87, &HEC, &HAE, &HD6, &HCE, _
           &HC5, &H1F, &H9F, &HDC, &HFA, &H83, &H76, &H43, &HC8, &H9C, &H2A, &H14, &HA3, &H5C, &H8A, &HEB, _
           &H95, &HC2, &H2C, &HBC, &HB2, &H1C, &H61, &HDA, &H1E, &H1F, &H84, &H60, &HD, &H13, &H2C, &H9A, _
           &H11, &HD2, &H26, &HA8, &HFC, &H80, &HB7, &HC6, &H42, &H19, &H1E, &H20, &H5D, &HFD, &HB4, &HB5, _
           &H11, &HCA, &H75, &H71, &HE2, &HE3, &H1C, &HD3, &H51, &H1F, &HD3, &H58, &HE5, &H3C, &H1E, &HB2, _
           &H1E, &H40, &H5A, &H5B, &H17, &H1C, &H89, &H0, &H98, &HFB, &H1E, &H18, &H67, &H36, &HB9, &H1F, _
           &HB0, &H89, &H11, &H8B, &HE7, &HC1, &HFD, &H99, &H5D, &HF4, &HE4, &H69, &HE5, &H73, &HFF, &HE6, _
           &HB5, &H20, &H66, &HCD, &H95, &HBF, &HBC, &HA1, &H24, &H40, &H18, &H15, &H9B, &HD3, &HD2, &HB6, _
           &HDC, &HBD, &HDC, &H49, &HF, &HDE, &HBA, &HBB, &H6E, &H22, &H79, &H24, &HF7, &H91, &HB2, &H84, _
           &HF9, &H81, &HB5, &H54, &H6F, &HCD, &H86, &HC7, &HEE, &HB4, &HAA, &HE3, &HA1, &HA1, &H6A, &H32, _
           &H4A, &HB, &H2D, &H49, &H41, &H33, &H72, &H60, &H2, &HBB, &H5A, &H5E, &H26, &H42, &HF2, &HAA, _
           &H7F, &H81, &H42, &H30, &HC9, &HB, &HA0, &H8A, &H72, &H91, &H3E, &H75, &HCD, &HC5, &H5, &HBE, _
           &H9A, &H74, &H58, &H78, &H44, &HFE, &H15, &HB4, &H60, &H94, &H34, &H36, &HD2, &HD9, &HB6, &H84, _
           &H14, &H0, &HDC, &H73, &H9A, &H9F, &HF, &H83, &HB2, &H4A, &HD, &H1D, &H7F, &H53, &H3D, &H42, _
           &H8, &H20, &H70, &HAF, &HFD, &H7C, &HC8, &HFC, &H93, &H9, &H4, &H30, &HD7, &H7E, &HC8, &H99, _
           &HA7, &H7E, &HD1, &H4F, &H8, &H6D, &H59, &H8A, &HBC, &HCD, &H2A, &H8, &H57, &HE8, &H6, &H7, _
           &H38, &HEF, &HA6, &H58, &HF8, &HC, &HFA, &HF1, &H65, &HC4, &H71, &HB2, &H74, &HF6, &H40, &H20, _
           &H83, &HDB, &H6B, &HF0, &HBC, &HB9, &H4C, &H5, &HF8, &H1B, &HF2, &H5B, &HF0, &HA4, &HED, &H59, _
           &H76, &H28, &HD1, &HBD, &HEF, &H1A, &HC, &HF1, &HB, &HA7, &HFA, &H32, &HB3, &HEE, &H68, &H65, _
           &H13, &HBE, &H97, &HEA, &H15, &H4C, &HA7, &H6, &H88, &H38, &H64, &HA6, &H1E, &HED, &H9B, &H58, _
           &HE1, &HD6, &HB1, &HD7, &H91, &H65, &H9E, &H28, &H3D, &HF0, &H53, &HA1, &H74, &H3D, &H6, &H7A, _
           &H3C, &H8, &H40, &H11, &H68, &H99, &H7E, &H93, &HE, &HA, &HB8, &H10, &HAC, &H49, &H7B, &H46, _
           &H3, &H29, &H77, &HC2, &HDE, &H6A, &HDC, &HF0, &HF4, &H62, &H32, &H6D, &H84, &HF7, &HB4, &H85, _
           &HBA, &H65, &HB7, &H8F, &H49, &H8A, &HCC, &HC8, &H4F, &HB1, &H49, &H3D, &H4F, &HF7, &H32, &H71, _
           &H94, &H31, &H90, &HF1, &H68, &HE0, &H41, &H11, &HAE, &HA7, &H1F, &HD9, &H48, &H6C, &HC2, &H71, _
           &H69, &H5C, &HE4, &H94, &H83, &H14, &HC2, &H36, &H42, &HD0, &H7C, &H6E, &H14, &H2C, &H62, &HDE, _
           &HF9, &H4B, &HBC, &HDC, &HE4, &H96, &H72, &H30, &H21, &H77, &HD6, &H62, &H39, &H66, &HC8, &HF0, _
           &H59, &H78, &H1, &HC1, &H8F, &H3D, &H5C, &H23, &H7B, &HD3, &H22, &H80, &H83, &HDB, &H85, &H3, _
           &H9A, &HF7, &H66, &H88, &H9, &H3A, &H2C, &HA0, &HB4, &H42, &H3B, &HD4, &H32, &H55, &H41, &H5F, _
           &H11, &H41, &H78, &HF, &H94, &H42, &H49, &H55, &HAB, &H40, &H6D, &H44, &H3D, &H33, &HAF, &HB2, _
           &HC, &H4, &H9, &HE6, &H69, &HC7, &H90, &H51, &HF5, &HD7, &HD8, &HEC, &HEE, &H21, &H13, &HDE, _
           &H35, &H5C, &HEB, &HA9, &H2D, &H91, &H5F, &H51, &H8F, &H19, &HCD, &H32, &HE6, &H4, &HC6, &H6F, _
           &H50, &HB0, &H14, &H8C, &HD1, &HC8, &HA2, &H1B, &HF1, &HFC, &HE3, &H3C, &HC6, &H25, &H41, &HB3, _
           &H21, &HC4, &H3C, &H19, &H42, &H6, &H82, &HAC, &H5E, &H5D, &HEB, &H76, &H6F, &HF7, &H16, &H8, _
           &HAD, &HEB, &H82, &HEC, &HA, &H9F, &H1B, &HF6, &HCE, &H99, &H40, &H63, &H68, &H21, &HD8, &H9E, _
           &H38, &HC4, &H1C, &HED, &HBE, &HD, &H1F, &HB2, &HF8, &H74, &H9C, &H35, &HE8, &H52, &HD9, &H8A, _
           &H40, &HD2, &HFF, &HE, &H8, &HE1, &H63, &HD, &H58, &H1, &HA, &H87, &H6, &HCE, &HE8, &HE1, _
           &H3, &HB9, &HCF, &HEB, &H42, &H19, &H71, &H6F, &HA2, &HD3, &H9C, &HC8, &HD6, &H9E, &H8D, &H69, _
           &HA4, &HDC, &HC4, &H5F, &HF0, &H1C, &H49, &H51, &H9F, &H94, &HBA, &H71, &HAB, &H6D, &H69, &H70, _
           &H48, &HD9, &HE0, &HD0, &H42, &HA2, &HB8, &H95, &H6B, &HCA, &H2D, &H60, &HC6, &H52, &HB9, &H6A, _
           &HA1, &H44, &H68, &HAE, &HF0, &H7C, &HD2, &H6E, &H88, &HA, &HE9, &H6F, &HAB, &HA7, &HA0, &HAD, _
           &H73, &HC9, &H23, &H87, &HE1, &H9C, &H23, &HCD, &HFE, &H16, &H31, &H6C, &HFA, &H29, &H12, &HCD, _
           &H4, &H7, &H70, &H84, &H71, &H25, &HD5, &H3A, &H38, &HEF, &H5B, &H1B, &H97, &HE7, &HA0, &H69, _
           &H9C, &H66, &HED, &HE5, &H63, &H70, &H58, &H60, &HEF, &HA9, &H39, &H15, &HF1, &H3A, &HC3, &H35, _
           &HF, &H2F, &HCC, &HD5, &H86, &H84, &HBC, &H69, &H42, &H88, &HB5, &HDB, &H21, &H30, &H1A, &HA7, _
           &HEB, &H36, &HAD, &H97, &HB, &H89, &H93, &H4E, &HD9, &H66, &H4D, &HFD, &H9C, &HA6, &H41, &HD5, _
           &H31, &H64, &H9B, &H2A, &H74, &H66, &HA6, &H90, &HE8, &HB3, &HC6, &H4E, &HA6, &HF2, &H90, &H97, _
           &HCF, &H15, &HB9, &H48, &H31, &H1F, &H16, &H40, &HD1, &H2D, &H57, &H8F, &H26, &H8B, &HA8, &H34, _
           &H2E, &HE5, &H1B, &H8B, &H73, &H16, &HB9, &HB2, &H30, &HD5, &HDB, &H3A, &H1, &HF0, &H1F, &HB8, _
           &H84, &H9, &HD9, &H85, &HEF, &H99, &HD3, &H7, &HEE, &H63, &H86, &H5F, &H26, &H5F, &H15, &H3E, _
           &H11, &H1B, &H9D, &H62, &H71, &H3E, &H2, &HE6, &H83, &H42, &HB5, &HF0, &H76, &HB0, &H6A, &HA2, _
           &HB0, &H1C, &HA7, &H4B, &H8C, &H75, &HA8, &H78, &H75, &H9E, &H6E, &H94, &H62, &H74, &H79, &HFF, _
           &H14, &H91, &HA1, &H17, &HA0, &H1E, &H8C, &HBC, &H94, &H77, &H32, &H7D, &HB0, &H51, &H91, &HA, _
           &H9D, &H3B, &HFD, &H5D, &H0, &HDF, &H95, &H5, &HBB, &H43, &H54, &H5A, &H91, &H46, &HD0, &HE7, _
           &H52, &H87, &HA3, &H8B, &H67, &HE, &H1D, &H78, &H78, &H5E, &H3D, &HF, &H32, &H93, &H6E, &H7E, _
           &HF9, &HC1, &H7F, &HCE, &H2B, &HED, &H72, &HE8, &H73, &H96, &H33, &H38, &H2D, &HDC, &HF4, &H6C, _
           &H8B, &H26, &HF8, &H67, &H4B, &H6D, &H34, &H90, &HD4, &HB0, &H4B, &H37, &HE0, &H30, &H28, &HC0, _
           &HE0, &H10, &HB4, &H80, &H96, &H67, &HFB, &H26, &H9D, &HE2, &HC1, &HDA, &HB5, &H14, &H2, &H43, _
           &HE7, &H6D, &HD4, &H96, &HE8, &H16, &H21, &H55, &H37, &HE5, &H35, &HA4, &HF9, &HFC, &HA3, &HA, _
           &H25, &HC9, &HA5, &HAD, &H49, &HCD, &H10, &HEC, &H8D, &HE6, &H3F, &H75, &H49, &HD5, &H4, &HDF, _
           &HD9, &H2, &H81, &H64, &HD7, &H32, &H32, &HFE, &HD4, &H1C, &H42, &H6, &H8, &HBE, &HF1, &HD7, _
           &H3C, &H3B, &HD4, &HC6, &HF5, &HD8, &HCB, &HB6, &HF6, &H50, &HE0, &H46, &H32, &HD6, &H5D, &HE, _
           &HF7, &HFB, &H40, &H2F, &HFD, &H2C, &H38, &HE0, &H42, &HA8, &H5B, &HC9, &HC0, &H76, &HB0, &H2C, _
           &H3C, &H54, &H13, &HA4, &H0, &H6, &HA3, &HAE, &H49, &H34, &H44, &H4E, &H92, &H2D, &HB7, &H91, _
           &HF3, &HD7, &H76, &H8A, &H8, &H28, &HDB, &HE2, &H71, &H8C, &H57, &H48, &H1B, &H1C, &HAA, &H85, _
           &H40, &H1F, &H6E, &H9, &H9, &HA1, &H96, &HAE, &HEC, &H17, &H99, &HD0, &H84, &H21, &HD, &HBE, _
           &HBF, &H66, &H33, &H1F, &H62, &H31, &HFF, &H94, &H88, &HB9, &HDC, &H11, &H68, &H23, &H36, &H11, _
           &H38, &H48, &H76, &H99, &HA2, &HA, &H5F, &H1E, &HA5, &HAA, &H3A, &H7A, &H7, &HDA, &H77, &H1A, _
           &H68, &H9C, &HCC, &H48, &H1D, &H1A, &H94, &H57, &HB, &H63, &H99, &HE1, &H39, &H54, &H7A, &HCB, _
           &H94, &H7F, &H7C, &HE6, &HA4, &HA5, &H62, &H23, &H7F, &HD, &H33, &HA7, &HC7, &H6B, &H43, &HF8, _
           &H97, &HF1, &H8C, &HB5, &HDE, &HD, &HC1, &H26, &H58, &HCF, &HB0, &H94, &H28, &H9, &HC1, &H79, _
           &H90, &HE3, &H1E, &HA9, &H51, &HD, &HC7, &H9, &H3B, &H55, &H9C, &HD1, &H6A, &H38, &HD0, &H4B, _
           &H41, &H2B, &H72, &H32, &H1C, &HC9, &H56, &HA1, &HE0, &H8, &H1E, &H21, &H80, &H96, &H78, &H22, _
           &H5B, &H95, &HE, &H0, &H43, &HEE, &H9C, &HDB, &H5, &H93, &HB6, &H8E, &H46, &HA5, &HD, &HD5}
        

End Module
