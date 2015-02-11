Imports System.ComponentModel
Imports System.Globalization
<DefaultProperty("Name")> _
Public Class clsTest
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    <Description("Name of the thing")> _
    Public Property Name() As [String]
        Get
            Return m_Name
        End Get
        Set(ByVal value As [String])
            m_Name = value
        End Set
    End Property
    Private m_Name As [String]

    <Description("Whether activated or not")> _
    Public Property Activated() As Boolean
        Get
            Return m_Activated
        End Get
        Set(ByVal value As Boolean)
            m_Activated = value
        End Set
    End Property
    Private m_Activated As Boolean

    <Description("Rank of the thing")> _
    Public Property Rank() As Integer
        Get
            Return m_Rank
        End Get
        Set(ByVal value As Integer)
            m_Rank = value
        End Set
    End Property
    Private m_Rank As Integer

    <Description("whether to persist the settings...")> _
    Public Property Ephemeral() As Boolean
        Get
            Return m_Ephemeral
        End Get
        Set(ByVal value As Boolean)
            m_Ephemeral = value
        End Set
    End Property
    Private m_Ephemeral As Boolean

    '<Description("extra free-form attributes on this thing.")> _
    '<Editor("System.Windows.Forms.Design.StringCollectionEditor," & "System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", GetType(System.Drawing.Design.UITypeEditor))> _
    '<TypeConverter(GetType(CsvConverter))> _
    'Public ReadOnly Property ExtraStuff() As List(Of [String])
    '    Get
    '        If _attributes Is Nothing Then
    '            _attributes = New List(Of [String])()
    '        End If
    '        Return _attributes
    '    End Get
    'End Property
    Private _attributes As List(Of [String])
End Class
'Public Class CsvConverter
'    Inherits TypeConverter
'    ' Overrides the ConvertTo method of TypeConverter.
'    Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
'        Dim v As List(Of [String]) = TryCast(value, List(Of [String]))
'        If destinationType = GetType(String) Then
'            Return [String].Join(",", v.ToArray())
'        End If
'        Return MyBase.ConvertTo(context, culture, value, destinationType)
'    End Function
'End Class