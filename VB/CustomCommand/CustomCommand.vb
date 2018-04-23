Imports Microsoft.VisualBasic
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Utils
Imports DevExpress.Xpf.RichEdit
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.Commands
Imports DevExpress.XtraRichEdit.Services

Namespace CustomCommand
	#Region "customsavecommand"
	Public Class CustomSaveDocumentCommand
		Inherits SaveDocumentAsCommand
		Public Sub New(ByVal control As IRichEditControl)
			MyBase.New(control)
		End Sub

		Protected Overrides Sub ExecuteCore()
			If Control.Document.Paragraphs.Count > 7 Then
				MyBase.ExecuteCore()
			Else
				MessageBox.Show("You should type at least 7 paragraphs" & ControlChars.CrLf & "  to be able to save the document.", "Please be creative", MessageBoxButton.OK)
			End If
		End Sub
	End Class
	#End Region ' customsavecommand


	#Region "#iricheditcommandfactoryservice"
	Public Class CustomRichEditCommandFactoryService
		Implements IRichEditCommandFactoryService
		Private ReadOnly service As IRichEditCommandFactoryService
		Private ReadOnly control As RichEditControl

		Public Sub New(ByVal control As RichEditControl, ByVal service As IRichEditCommandFactoryService)
			Guard.ArgumentNotNull(control, "control")
			Guard.ArgumentNotNull(service, "service")
			Me.control = control
			Me.service = service
		End Sub

		#Region "IRichEditCommandFactoryService Members"
        Public Function CreateCommand(ByVal id As RichEditCommandId) As RichEditCommand Implements IRichEditCommandFactoryService.CreateCommand
            If id = RichEditCommandId.FileSaveAs Then
                Return New CustomSaveDocumentCommand(control)
            End If

            Return service.CreateCommand(id)
        End Function
		#End Region
	End Class
	#End Region ' #iricheditcommandfactoryservice


End Namespace
