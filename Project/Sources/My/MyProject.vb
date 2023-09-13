Imports System
Imports System.Collections
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Friend Module MyProject
        Private ReadOnly m_ComputerObjectProvider As ThreadSafeObjectProvider(Of MyComputer)

        Private ReadOnly m_AppObjectProvider As ThreadSafeObjectProvider(Of MyApplication)

        Private ReadOnly m_UserObjectProvider As ThreadSafeObjectProvider(Of Microsoft.VisualBasic.ApplicationServices.User)

        Private m_MyFormsObjectProvider As ThreadSafeObjectProvider(Of MyForms)

        Private ReadOnly m_MyWebServicesObjectProvider As ThreadSafeObjectProvider(Of MyWebServices)

        Friend ReadOnly Property Application As MyApplication
            Get
                Return m_AppObjectProvider.GetInstance
            End Get
        End Property

        Friend ReadOnly Property Computer As MyComputer
            Get
                Return m_ComputerObjectProvider.GetInstance
            End Get
        End Property

        Friend ReadOnly Property Forms As MyForms
            Get
                Return m_MyFormsObjectProvider.GetInstance
            End Get
        End Property

        Friend ReadOnly Property User As Microsoft.VisualBasic.ApplicationServices.User
            Get
                Return m_UserObjectProvider.GetInstance
            End Get
        End Property

        Friend ReadOnly Property WebServices As MyWebServices
            Get
                Return m_MyWebServicesObjectProvider.GetInstance
            End Get
        End Property

        Sub New()
            m_ComputerObjectProvider = New ThreadSafeObjectProvider(Of MyComputer)()
            m_AppObjectProvider = New ThreadSafeObjectProvider(Of MyApplication)()
            m_UserObjectProvider = New ThreadSafeObjectProvider(Of Microsoft.VisualBasic.ApplicationServices.User)()
            m_MyFormsObjectProvider = New ThreadSafeObjectProvider(Of MyForms)()
            m_MyWebServicesObjectProvider = New ThreadSafeObjectProvider(Of MyWebServices)()
        End Sub

        Friend NotInheritable Class MyForms

            Private Shared m_FormBeingCreated As Hashtable

            Public m_Main As Main

            Public Property Main As Main
                Get
                    m_Main = Create__Instance__(m_Main)
                    Return m_Main
                End Get
                Set(value As Main)
                    Dispose__Instance__(m_Main)
                End Set
            End Property

            Public m_Login As Login

            Public Property Login As Login
                Get
                    m_Login = Create__Instance__(m_Login)
                    Return m_Login
                End Get
                Set(value As Login)
                    Dispose__Instance__(m_Login)
                End Set
            End Property

            Public m_loadxml As loadxml

            Public Property loadxml As loadxml
                Get
                    m_loadxml = Create__Instance__(m_loadxml)
                    Return m_loadxml
                End Get
                Set(value As loadxml)
                    Dispose__Instance__(m_loadxml)
                End Set
            End Property

            Public Sub New()
                MyBase.New()
            End Sub

            Private Shared Function Create__Instance__(Of T As {Form, New})(Instance As T) As T
                Dim t1 As T
                If Instance IsNot Nothing AndAlso Not Instance.IsDisposed Then
                    t1 = Instance
                Else
                    If m_FormBeingCreated Is Nothing Then
                        m_FormBeingCreated = New Hashtable()
                    ElseIf m_FormBeingCreated.ContainsKey(GetType(T)) Then
                        Throw New InvalidOperationException(Microsoft.VisualBasic.CompilerServices.Utils.GetResourceString("WinForms_RecursiveFormCreate", New String(-1) {}))
                    End If
                    m_FormBeingCreated.Add(GetType(T), Nothing)
                    Try
                        Try
                            t1 = Activator.CreateInstance(Of T)()
                        Catch targetInvocationException As TargetInvocationException When targetInvocationException.InnerException IsNot Nothing
                            Dim resourceString As String = Microsoft.VisualBasic.CompilerServices.Utils.GetResourceString("WinForms_SeeInnerException", New String() {targetInvocationException.InnerException.Message})
                            Throw New InvalidOperationException(resourceString, targetInvocationException.InnerException)
                        End Try
                    Finally
                        m_FormBeingCreated.Remove(GetType(T))
                    End Try
                End If
                Return t1
            End Function

            Private Sub Dispose__Instance__(Of T As Form)(ByRef instance As T)
                instance.Dispose()
                instance = Nothing
            End Sub


            Public Overrides Function Equals(o As Object) As Boolean
                Return Equals(RuntimeHelpers.GetObjectValue(o))
            End Function


            Public Overrides Function GetHashCode() As Integer
                Return GetHashCode()
            End Function


            Friend Shadows Function [GetType]() As Type
                Return GetType(MyForms)
            End Function


            Public Overrides Function ToString() As String
                Return ToString()
            End Function
        End Class


        <Microsoft.VisualBasic.MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")>
        Friend NotInheritable Class MyWebServices

            Public Sub New()
                MyBase.New()
            End Sub

            Private Shared Function Create__Instance__(Of T As New)(instance As T) As T
                Dim t1 As T
                t1 = If(instance IsNot Nothing, instance, Activator.CreateInstance(Of T)())
                Return t1
            End Function

            Private Sub Dispose__Instance__(Of T)(ByRef instance As T)
                instance = Nothing
            End Sub


            Public Overrides Function Equals(o As Object) As Boolean
                Return Equals(RuntimeHelpers.GetObjectValue(o))
            End Function


            Public Overrides Function GetHashCode() As Integer
                Return GetHashCode()
            End Function


            Friend Shadows Function [GetType]() As Type
                Return GetType(MyWebServices)
            End Function


            Public Overrides Function ToString() As String
                Return ToString()
            End Function
        End Class


        Friend NotInheritable Class ThreadSafeObjectProvider(Of T As New)
            <CompilerGenerated>
            <ThreadStatic>
            Private Shared m_ThreadStaticValue As T

            Friend ReadOnly Property GetInstance As T
                Get
                    If m_ThreadStaticValue Is Nothing Then
                        m_ThreadStaticValue = Activator.CreateInstance(Of T)()
                    End If
                    Return m_ThreadStaticValue
                End Get
            End Property


            Public Sub New()
                MyBase.New()
            End Sub
        End Class
End Module