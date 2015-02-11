Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Xml.Serialization
Imports System.IO
Imports System.Configuration

<Serializable()> _
Public Class clsOutlookControls
    Private _saveOnClose As Boolean = True
    Private _greetingText As String = "Welcome to your application!"
    Private _maxRepeatRate As Integer = 10
    Private _itemsInMRU As Integer = 4

    Private _settingsChanged As Boolean = False
    Private _appVersion As String = "1.0"

    Private _windowSize As Size = New Size(100, 100)
    Private _windowFont As Font = New Font("Arial", 8, FontStyle.Regular)
    Private _toolbarColor As Color = SystemColors.Control
    Private _image As Image = Nothing
    Private _defaultFileName As String

    Public Enum images
        Up
        Down
    End Enum

    Private _icon As images
    <CategoryAttribute("Application"), _
         Browsable(True), _
         [ReadOnly](False), _
         BindableAttribute(False), _
         DefaultValueAttribute(""), _
         DesignOnly(False), _
         DescriptionAttribute("Choose the Image to Button")> _
    Public Property Image() As Image
        Get
            Return _image
        End Get
        Set(ByVal value As Image)
            _image = value
        End Set
    End Property
    Public Function Load() As clsOutlookControls
        Dim serializer As XmlSerializer = New XmlSerializer(GetType(clsOutlookControls))
        Dim retVal As clsOutlookControls
        Dim reader As TextReader = Nothing
        Dim fileNotFound As Boolean

        Try
            reader = New StreamReader("MyAppSettings.xml")
        Catch ex As FileNotFoundException
            ' Take the defaults
            fileNotFound = True
        End Try

        If fileNotFound Then
            retVal = New clsOutlookControls
            retVal.WindowSize = New System.Drawing.Size(600, 600)
        Else
            'Read it from the file
            retVal = serializer.Deserialize(reader)
            reader.Close()
        End If

        Return retVal
    End Function
    Public Sub Save()
        Dim serializer As New XmlSerializer(GetType(clsOutlookControls))
        Dim writer As TextWriter = New StreamWriter("MyAppSettings.xml")
        serializer.Serialize(writer, Me)
        writer.Close()
    End Sub
    <CategoryAttribute("Application"), _
             Browsable(True), _
             [ReadOnly](False), _
             BindableAttribute(False), _
             DefaultValueAttribute(""), _
             DesignOnly(False), _
             DescriptionAttribute("Enter Title for the application")> _
    Public Property DefaultFileName() As String
        Get
            Return _defaultFileName
        End Get
        Set(ByVal value As String)
            _defaultFileName = value
        End Set
    End Property
    <CategoryAttribute("Application"), _
             Browsable(True), _
             [ReadOnly](False), _
             BindableAttribute(False), _
             DefaultValueAttribute(""), _
             DesignOnly(False), _
             DescriptionAttribute("Enter Title for the application")> _
    Public Property SaveOnClose() As Boolean
        Get
            Return _saveOnClose
        End Get
        Set(ByVal Value As Boolean)
            _saveOnClose = Value
        End Set
    End Property
    <UserScopedSettingAttribute(), DefaultSettingValueAttribute("Size"), _
       Browsable(True), [ReadOnly](False), BindableAttribute(True), DescriptionAttribute("Enter Window Size")> _
    Public Property WindowSize() As Size
        Get
            Return _windowSize
        End Get
        Set(ByVal Value As Size)
            _windowSize = Value
        End Set
    End Property
    <CategoryAttribute("Application"), _
             Browsable(True), _
             [ReadOnly](False), _
             BindableAttribute(False), _
             DefaultValueAttribute(""), _
             DesignOnly(False), _
             DescriptionAttribute("Enter Title for the application")> _
    Public Property WindowFont() As Font
        Get
            Return _windowFont
        End Get
        Set(ByVal Value As Font)
            _windowFont = Value
        End Set
    End Property

    <CategoryAttribute("Application"), _
             Browsable(True), _
             [ReadOnly](False), _
             BindableAttribute(False), _
             DefaultValueAttribute(""), _
             DesignOnly(False), _
             DescriptionAttribute("Enter Title for the application")> _
    Public Property ToolbarColor() As Color
        Get
            Return _toolbarColor
        End Get
        Set(ByVal Value As Color)
            _toolbarColor = Value
        End Set
    End Property

    <CategoryAttribute("Application"), _
            Browsable(True), _
            [ReadOnly](False), _
            BindableAttribute(False), _
            DefaultValueAttribute(""), _
            DesignOnly(False), _
            DescriptionAttribute("Enter Title for the application")> _
    Public Property GreetingText() As String
        Get
            Return _greetingText
        End Get
        Set(ByVal Value As String)
            _greetingText = Value
        End Set
    End Property

    <CategoryAttribute("Application"), _
          Browsable(True), _
          [ReadOnly](False), _
          BindableAttribute(False), _
          DefaultValueAttribute(""), _
          DesignOnly(False), _
          DescriptionAttribute("Enter Title for the application")> _
    Public Property ItemsInMRUList() As Integer
        Get
            Return _itemsInMRU
        End Get
        Set(ByVal Value As Integer)
            _itemsInMRU = Value
        End Set
    End Property

    <CategoryAttribute("Application"), _
            Browsable(True), _
            [ReadOnly](False), _
            BindableAttribute(False), _
            DefaultValueAttribute(""), _
            DesignOnly(False), _
            DescriptionAttribute("Enter Title for the application")> _
    Public Property MaxRepeatRate() As Integer
        Get
            Return _maxRepeatRate
        End Get
        Set(ByVal Value As Integer)
            _maxRepeatRate = Value
        End Set
    End Property
    <CategoryAttribute("Application"), _
             Browsable(True), _
             [ReadOnly](False), _
             BindableAttribute(False), _
             DefaultValueAttribute(""), _
             DesignOnly(False), _
             DescriptionAttribute("Enter Title for the application")> _
    Public Property SettingsChanged() As Boolean
        Get
            Return _settingsChanged
        End Get
        Set(ByVal Value As Boolean)
            _settingsChanged = Value
        End Set
    End Property

    <CategoryAttribute("Application"), _
           Browsable(True), _
           [ReadOnly](False), _
           BindableAttribute(False), _
           DefaultValueAttribute(""), _
           DesignOnly(False), _
           DescriptionAttribute("Enter Title for the application")> _
    Public Property AppVersion() As String
        Get
            Return _appVersion
        End Get
        Set(ByVal Value As String)
            _appVersion = Value
        End Set
    End Property



End Class
